using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Definitions
{
    abstract class BaseLogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("Base: " + message);
        }
        public void LogCompleted()
        {
            Console.WriteLine("Completed");
        }
    }
    class Logger : BaseLogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
        public new void LogCompleted()
        {
            Console.WriteLine("Finished");
        }
    }
}
