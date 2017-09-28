using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class Formaters
    {
        public static void DateAndTime(DateTime date, double value)
        {
            Console.WriteLine("Result on {0:hh:mm} at {0:MM/dd/yy} is {1:N2}", date, value);
        }
    }
}
