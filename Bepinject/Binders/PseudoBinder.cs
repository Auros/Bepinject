using System;
using Zenject;

namespace Bepinject.Binders
{
    public class PseudoBinder : OnBinder
    {
        internal OnBinder Pseudo(Action<Context, DiContainer> callback)
        {
            pseudoCallback = callback;
            return this;
        }
    }
}