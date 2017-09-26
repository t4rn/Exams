using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Definitions
{
    public class Person
    {
        [DataMember(Order = 10)]
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }

    }

    public class PhoneNumber
    {
        public string Number { get; set; }
    }
}
