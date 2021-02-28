using BepInEx;

namespace Bepinject
{
    public class BepInPluginInfo
    {
        public PluginInfo PluginInfo = null!;

        internal void Setup(PluginInfo pluginInfo)
        {
            PluginInfo = pluginInfo;
        }
    }
}