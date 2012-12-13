using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GA.Core.Util
{
    public interface ILogger : IDisposable
    {
        bool AutoFlush { get; set; }
        void Flush();
        void Log(TraceEventType eventType, string message);
        void Log(TraceEventType eventType, string format, params object[] args);
        void Log(string format, params object[] args);
    }

    public static class LoggerExtensions
    {
        public static void WriteLine(this ILogger log, string message)
        {
            log.Log(TraceEventType.Information, message);
        }
        public static void WriteLine(this ILogger log, string format, params object[] args)
        {
            log.Log(TraceEventType.Information, format, args);
        }
        public static void Error(this ILogger log, Exception ex, string message = "")
        {
            log.Log(TraceEventType.Critical, string.Format("{1} Failure {0}", ex, message));
        }
    }
}
