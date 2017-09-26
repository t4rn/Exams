using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public static class Comparers
    {
        public static bool AreEqual(object o1, object o2)
        {
            return object.Equals(o1, o2);
        }
    }
}
