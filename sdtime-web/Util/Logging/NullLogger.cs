using System.Diagnostics;

namespace GA.Core.Util
{
    public class NullLogger : ILogger
    {
        public void Log(TraceEventType eventType, string message) { }

        public void Log(TraceEventType eventType, string format, params object[] args) { }

        public void Log(string format, params object[] args) { }

        public bool AutoFlush { get; set; }

        public void Flush() { }

        public void Dispose() { }
    }
}