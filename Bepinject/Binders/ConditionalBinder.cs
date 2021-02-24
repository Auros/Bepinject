using System;

namespace Bepinject
{
    public class ConditionalBinder : RootBinder
    {
        public new RootBinder When(Func<bool> when)
        {
            conditionalCallback = when;
            return this;
        }
    }
}