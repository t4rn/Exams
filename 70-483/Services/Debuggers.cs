#define DEBUG

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
    }
}
