using Zenject;
using HarmonyLib;
using UnityEngine.SceneManagement;
using System;

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
            context.Run();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ProjectContext), "InstallBindings")]
        internal static void InstallProject(ref ProjectContext __instance)
        {
            ZenjectManager.Install(__instance, __instance.gameObject.scene);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Context), "InstallInstallers", argumentTypes: new Type[] { })]
        internal static void RunContext(ref Context __instance)
        {
            if (__instance is ProjectContext)
                return;
            ZenjectManager.Install(__instance, __instance.gameObject.scene);
        }
    }
}