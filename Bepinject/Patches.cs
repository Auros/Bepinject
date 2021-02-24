using Zenject;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace Bepinject
{
    internal class Patches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SceneManager), "Internal_SceneLoaded")]
        internal static void CreateSceneContextForScene(Scene scene)
        {
            if (!ProjectContext.HasInstance)
            {
                _ = ProjectContext.Instance;
            }

            var context = SceneContext.Create();
            context.name = $"SceneContext ({scene.name})";
            ZenjectManager.Install(context, scene);
            context.Run();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ProjectContext), "Initialize")]
        internal static void InstallProject(ref ProjectContext __instance)
        {
            ZenjectManager.Install(__instance, __instance.gameObject.scene);
        }
    }
}