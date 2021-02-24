using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Bepinject
{
    [BepInPlugin(Constants.ID, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log = null!;

        protected void Awake()
        {
            Log = Logger;
            Harmony.CreateAndPatchAll(typeof(Patches), Constants.ID);
        }
    }
}