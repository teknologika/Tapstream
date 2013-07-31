using System;

namespace TapstreamMetrics.Sdk
{
    public enum LogLevel
    {
        INFO = 0,
        WARN,
        ERROR
    }

    public sealed class Logging
    {
        private class DefaultLogger : ILogger
        {
            public void Log(LogLevel level, string msg)
            {
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        private static ILogger logger = new DefaultLogger();
        private static Object thisLock = new Object();


        public static void SetLogger(ILogger logger)
        {
            lock (thisLock)
            {
                Logging.logger = logger;
            }
        }

        public static void Log(LogLevel level, string format, params Object[] args)
        {
            lock (thisLock)
            {
                if (logger != null)
                {
                    string msg = String.Format(format, args);
                    logger.Log(level, msg);
                }
            }
        }
    }
}
