using BepInEx.Configuration;
using ModestTree;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bepinject
{
    internal class BepInConfigManager
    {
        private readonly Dictionary<Assembly, ConfigContext> _configAssemblies = new Dictionary<Assembly, ConfigContext>();

        internal ConfigContext ConfigFromAssembly(Assembly assembly)
        {
            if (!_configAssemblies.ContainsKey(assembly))
            {
                var zenjector = ZenjectManager.zenjectors.First(z => z.owner == assembly);
                Assert.IsNotNull(zenjector.binder.log);
                _configAssemblies.Add(assembly, new ConfigContext(zenjector.binder.config!));
            }
            return _configAssemblies[assembly];
        }

        internal struct ConfigContext
        {
            public ConfigFile config;

            public ConfigContext(ConfigFile config)
            {
                this.config = config;
            }
        }
    }
}