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
            Plugin.Log.LogMessage(Constants.LogBreak);
            Plugin.Log.LogMessage($"Creating context on scene {scene.name}.");
            Plugin.Log.LogMessage(Constants.LogBreak);
            SceneContext.Create().Run();
        }
    }
}