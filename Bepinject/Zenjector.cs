using System;
using System.Reflection;
using Zenject;

namespace Bepinject
{
    public class Zenjector
    {
        internal readonly Assembly owner;
        internal readonly EndInstallBinder binder;

        internal Zenjector(Assembly owningAssembly, EndInstallBinder binder)
        {
            this.binder = binder;
            owner = owningAssembly;
            ZenjectManager.zenjectors.Add(this);
        }

        public static OnBinder Install<T>() where T : InstallerBase
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

        public static OnBinder Pseudo(Action<Context, DiContainer>? callback = null)
        {
            var asm = Assembly.GetCallingAssembly();
            var pseudoBinder = new PseudoBinder();

            new Zenjector(asm, pseudoBinder);
            return pseudoBinder.Pseudo(callback);
        }
    }
}