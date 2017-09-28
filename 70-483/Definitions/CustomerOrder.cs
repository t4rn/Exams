using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Definitions
{
    public class Customer
    {
        public string FullName { get; set; }
        public List<Order> Orders { get; set; }
    }
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
    }
}
