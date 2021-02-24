using System;
using System.Reflection;

namespace Bepinject
{
    public class Zenjector
    {
        internal readonly Assembly owner;
        internal readonly EndInstallBinder binder;

        internal Zenjector(Assembly owningAssembly, InstallerBinder binder)
        {
            this.binder = binder;
            owner = owningAssembly;
            ZenjectManager.zenjectors.Add(this);
        }

        public static OnBinder Install<T>()
        {
            var asm = Assembly.GetCallingAssembly();
            var installerBinder = new InstallerBinder();

            new Zenjector(asm, installerBinder);
            return installerBinder.Install(typeof(T));
        }

        public static OnBinder Install(params Type[] types)
        {
            var asm = Assembly.GetCallingAssembly();
            var installerBinder = new InstallerBinder();

            new Zenjector(asm, installerBinder);
            return installerBinder.Install(types);
        }
    }
}