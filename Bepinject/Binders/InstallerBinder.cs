using System;

namespace Bepinject
{
    public class InstallerBinder : OnBinder
    {
        internal OnBinder Install(params Type[] types)
        {
            installerTypes = types;
            return this;
        }
    }
}