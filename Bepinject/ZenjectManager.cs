using ModestTree;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Bepinject
{
    internal class ZenjectManager
    {
        internal static List<Zenjector> zenjectors = new List<Zenjector>(); 

        public static void Install(Context context, Scene scene)
        {
            if (zenjectors.Count() == 0)
                return;

            List<Zenjector> zenjectorsToInstall = new List<Zenjector>();
            bool isDecorator = context is SceneDecoratorContext;
            bool isProject = context is ProjectContext;
            bool isScene = context is SceneContext;

            SceneDecoratorContext sdc = (context as SceneDecoratorContext)!;
            SceneContext sc = (context as SceneContext)!;
            ProjectContext pc = (context as ProjectContext)!;

            foreach (var zenjector in zenjectors)
            {
                if (zenjector.binder.conditionalCallback != null && !zenjector.binder.conditionalCallback.Invoke())
                    continue;

                if (isProject && zenjector.binder.onProject)
                {
                    zenjectorsToInstall.Add(zenjector);
                    continue;
                }

                if (isDecorator && zenjector.binder.contractNames != null && sdc.DecoratedContractName != null && zenjector.binder.contractNames.Contains(sdc.DecoratedContractName))
                {
                    zenjectorsToInstall.Add(zenjector);
                    continue;
                }

                if (zenjector.binder.sceneNames != null && zenjector.binder.sceneNames.Contains(scene.name))
                {
                    zenjectorsToInstall.Add(zenjector);
                    continue;
                }
            }

            if (zenjectorsToInstall.Count == 0)
                return;

            var rootGameObjects = context.GetRootGameObjects();
            var collectiveAdditiveGameObjects = rootGameObjects.SelectMany(go => go.GetComponents<Behaviour>());

            foreach (var zenjector in zenjectorsToInstall)
            {
                if (zenjector.binder.pseudoCallback != null)
                {
                    zenjector.binder.pseudoCallback?.Invoke(context, context.Container);
                }

                if (zenjector.binder.rootInjectionTypes != null && isScene)
                {
                    foreach (var rootObjectType in zenjector.binder.rootInjectionTypes)
                    {
                        var mb = collectiveAdditiveGameObjects.FirstOrDefault(mb => mb != null && mb.GetType() == rootObjectType);
                        if (mb != null)
                        {
                            void PreInstall()
                            {
                                sc.PreInstall -= PreInstall;
                                if (!context.Container!.HasBinding(rootObjectType))
                                    context.Container.Bind(rootObjectType).FromInstance(mb).AsSingle();
                            }
                            sc.PreInstall += PreInstall;
                        }
                        else
                        {
                            Plugin.Log.LogWarning($"While installing an installer from '{zenjector.owner.FullName}', there was no root component with the type of '{rootObjectType.Name}', so it can't be binded to the container.");
                        }
                    }
                }

                List<IInstaller> constructedInstallers = new List<IInstaller>();
                if (zenjector.binder.installerTypes != null)
                {
                    foreach (var installerType in zenjector.binder.installerTypes)
                    {
                        if (installerType.IsSubclassOf(typeof(MonoInstallerBase)))
                        {
                            var monoInstallers = context.Installers.ToList();
                            monoInstallers.Add(context.gameObject.AddComponent(installerType) as MonoInstaller);
                            context.Installers = monoInstallers;
                        }
                        else if (installerType.IsSubclassOf(typeof(InstallerBase)))
                        {
                            context!.AddNormalInstallerType(installerType);
                        }
                        else
                        {
                            Assert.CreateException($"Provided type is not an installer type '{installerType.FullName}'.");
                        }
                    }
                }
            }
        }
    }
}