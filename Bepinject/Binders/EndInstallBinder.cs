using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using System;
using Zenject;

namespace Bepinject
{
    public class EndInstallBinder
    {
        internal Action<Context, DiContainer>? pseudoCallback;
        internal Func<bool>? conditionalCallback;
        internal Type[]? rootInjectionTypes;
        internal Type[]? installerTypes;

        internal string[]? contractNames;
        internal string[]? sceneNames;
        internal bool onProject;
        
        internal ManualLogSource? log;
        internal ConfigFile? config;
        internal PluginInfo? plugin;
    }
}