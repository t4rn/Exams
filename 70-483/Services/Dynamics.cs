using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class Dynamics
    {
        public void SendAnonymous(string from)
        {
            var message = new { author = from };
            SendMessage(message);
        }

        public void SendExpandoObject(string from)
        {
            dynamic message = new ExpandoObject();
            message.From = from;
            SendMessage(message);
        }

        private void SendMessage(dynamic message)
        {
            Console.WriteLine($"Message: {message}");

            var ct = new CodeTypeDeclaration("asd");
            ct.IsClass = true;
            ct.Attributes = MemberAttributes.Public;
        }
    }
}
