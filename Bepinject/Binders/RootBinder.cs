using System;

namespace Bepinject
{
    public class RootBinder : WithBepInBinder
    {
        public WithBepInBinder BindFromRoot(params Type[] typesToBind)
        {
            rootInjectionTypes = typesToBind;
            return this;
        }

        public WithBepInBinder BindFromRoot<T>()
        {
            rootInjectionTypes = new Type[1] { typeof(T) };
            return this;
        }

        public RootBinder When(Func<bool> when)
        {
            conditionalCallback = when;
            return this;
        }
    }
}