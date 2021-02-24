using System;

namespace Bepinject
{
    public class RootBinder : WithLogBinder
    {
        public WithLogBinder BindFromRoot(params Type[] typesToBind)
        {
            rootInjectionTypes = typesToBind;
            return this;
        }

        public WithLogBinder BindFromRoot<T>()
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