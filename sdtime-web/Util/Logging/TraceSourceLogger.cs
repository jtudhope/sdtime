using System.Diagnostics;
using Microsoft.Practices.Unity;

namespace GA.Core.Util
{
    public class TraceSourceLogger : ILogger
    {
        private TraceSource traceSource;

        public TraceSourceLogger(string traceSourceName)
            : this(new TraceSource(traceSourceName, SourceLevels.All))
        {
            this.AutoFlush = true;
        }

        [InjectionConstructor]
        public TraceSourceLogger(TraceSource traceSource)
        {
            this.traceSource = traceSource;
        }

        public bool AutoFlush { get; set; }

        public void Flush()
        {
            this.traceSource.Flush();
        }

        public void Log(TraceEventType eventType, string message)
        {
            WriteToDebugWindow(eventType, message);
            this.traceSource.TraceEvent(eventType, 0, message);
            if (this.AutoFlush) this.Flush();
        }

        public void Log(TraceEventType eventType, string format, params object[] args)
        {
            Log(eventType, string.Format(format, args));
        }

        public void Log(string format, params object[] args)
        {
            Log(TraceEventType.Information, format, args);
        }

        [Conditional("DEBUG")]
        private void WriteToDebugWindow(TraceEventType eventType, string message)
        {
            Debug.WriteLine(string.Format("{2}-{0}-{1}", eventType, message, traceSource.Name));
        }

        public void Dispose()
        {

        }
    }
}
