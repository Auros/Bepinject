using BepInEx.Configuration;

namespace Bepinject
{
    public class BepInConfig
    {
        public ConfigFile Config = null!;

        internal void Setup(ConfigFile conf)
        {
            Config = conf;
        }
    }
}