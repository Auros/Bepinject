using BepInEx.Logging;

namespace Bepinject
{
    public class BepInLog
    {
        /// <summary>
        /// The logger that's being wrapped around.
        /// </summary>
        public ManualLogSource? Logger { get; private set; }

        internal void Setup(ManualLogSource logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Log with a <see cref="LogLevel.Info"/> of info.
        /// </summary>
        /// <param name="obj">The object to log.</param>
        public void Info(object obj)
        {
            Logger?.LogInfo(obj);
        }

        /// <summary>
        /// Log with a <see cref="LogLevel.Warning"/> of warning.
        /// </summary>
        /// <param name="obj">The object to log.</param>
        public void Warning(object obj)
        {
            Logger?.LogWarning(obj);
        }

        /// <summary>
        /// Log with a <see cref="LogLevel.Error"/> of error.
        /// </summary>
        /// <param name="obj">The object to log.</param>
        public void Error(object obj)
        {
            Logger?.LogError(obj);
        }

        /// <summary>
        /// Log with a <see cref="LogLevel.Debug"/> of debug.
        /// </summary>
        /// <param name="obj">The object to log.</param>
        public void Debug(object obj)
        {
            Logger?.LogDebug(obj);
        }

        /// <summary>
        /// Log with a <see cref="LogLevel.Fatal"/> of debug.
        /// </summary>
        /// <param name="obj">The object to log.</param>
        public void Fatal(object obj)
        {
            Logger?.LogFatal(obj);
        }

        /// <summary>
        /// Log with a <see cref="LogLevel.Message"/> of debug.
        /// </summary>
        /// <param name="obj">The object to log.</param>
        public void Message(object obj)
        {
            Logger?.LogMessage(obj);
        }

        /// <summary>
        /// Quickly perform a null check on an object and log the results.
        /// </summary>
        /// <param name="obj">The object to null check.</param>
        public void Null(object obj)
        {
            Info(obj != null ? $"{obj.GetType().Name} is not null." : $"Object is null");
        }
    }
}
