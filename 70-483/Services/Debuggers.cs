#define DEBUG

using System;
using System.Diagnostics;

namespace Exam70_483.Services
{
    public class Debuggers
    {
        public static void Start()
        {
            LogData();
#if (DEBUG)
            Trace.Write("Log2");
#endif
        }

        [Conditional("DEBUG")]
        private static void LogData()
        {
            Trace.Write("Log1");
        }

        public static void LogError(string errorMsg)
        {
            XmlWriterTraceListener listener = new XmlWriterTraceListener("./Error.log");
            listener.WriteLine(errorMsg);
            listener.Flush();
            listener.Close();
        }

        public static void LogError(Exception ex)
        {
            using (XmlWriterTraceListener log = new XmlWriterTraceListener("./TraceEvent.log"))
            {
                log.TraceEvent(new TraceEventCache(), ex.Message, TraceEventType.Error, ex.HResult);
                log.Flush(); 
            }
        }
    }
}
