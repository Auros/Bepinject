using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace Bepinject
{
    public class WithBepInBinder : EndInstallBinder
    {
        public void WithLog(ManualLogSource log)
        {
            this.log = log;
        }

        public WithBepInBinder WithConfig(ConfigFile config)
        {
            this.config = config;
            return this;
        }

        public WithBepInBinder WithPlugin(PluginInfo plugin)
        {
            this.plugin = plugin;
            return this;
        }
    }
}