using BepInEx.Logging;

namespace Bepinject
{
    public class WithLogBinder : EndInstallBinder
    {
        public void WithLog(ManualLogSource log)
        {
            this.log = log;
        }
    }
}