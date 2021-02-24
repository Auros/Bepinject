using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Zenject;

namespace Bepinject
{
    [BepInPlugin(Constants.ID, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;

        protected void Awake()
        {
            Log = Logger;
            Harmony.CreateAndPatchAll(typeof(Patches), Constants.ID);
        }
    }
}