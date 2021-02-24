using System;
using Zenject;

namespace Bepinject
{
    public class PseudoBinder : OnBinder
    {
        internal OnBinder Pseudo(Action<Context, DiContainer>? callback = null)
        {
            pseudoCallback = callback;
            return this;
        }
    }
}