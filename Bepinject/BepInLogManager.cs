using BepInEx.Logging;
using ModestTree;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bepinject
{
    internal class BepInLogManager
    {
        private readonly Dictionary<Assembly, LoggerContext> _loggerAssemblies = new Dictionary<Assembly, LoggerContext>();

        internal LoggerContext LoggerFromAssembly(Assembly assembly)
        {
            if (!_loggerAssemblies.ContainsKey(assembly))
            {
                var zenjector = ZenjectManager.zenjectors.First(z => z.owner == assembly);
                Assert.IsNotNull(zenjector.binder.log);
                _loggerAssemblies.Add(assembly, new LoggerContext(zenjector.binder.log!));
            }
            return _loggerAssemblies[assembly];
        }

        internal struct LoggerContext
        {
            public ManualLogSource logger;

            public LoggerContext(ManualLogSource logger)
            {
                this.logger = logger;
            }
        }
    }
}