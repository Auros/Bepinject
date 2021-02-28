using BepInEx;
using ModestTree;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bepinject
{
    internal class BepInPluginManager
    {
        private readonly Dictionary<Assembly, PluginContext> _pluginAssemblies = new Dictionary<Assembly, PluginContext>();

        internal PluginContext PluginFromAssembly(Assembly assembly)
        {
            if (!_pluginAssemblies.ContainsKey(assembly))
            {
                var zenjector = ZenjectManager.zenjectors.First(z => z.owner == assembly);
                Assert.IsNotNull(zenjector.binder.log);
                _pluginAssemblies.Add(assembly, new PluginContext(zenjector.binder.plugin!));
            }
            return _pluginAssemblies[assembly];
        }

        internal struct PluginContext
        {
            public PluginInfo plugin;

            public PluginContext(PluginInfo plugin)
            {
                this.plugin = plugin;
            }
        }
    }
}