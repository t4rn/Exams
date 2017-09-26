using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Definitions
{
    public class Employee
    {
        readonly Func<int, char> suffix = arg => arg % 2 == 0 ? 't' : 'n';
        protected string Type
        {
            get;
            private set;
        }

        private void Calculate()
        {
            char result = suffix(10);
        }

    }
}
