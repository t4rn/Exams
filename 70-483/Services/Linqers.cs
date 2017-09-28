using Exam70_483.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class Linqers
    {
        private static List<Product> products = new List<Product>()
            {
                new Product { Category = "Cars", Name = "Audi" }, new Product { Category = "Cars", Name = "BMW" },
                new Product { Category = "Cars", Name = "Open" },new Product { Category = "Cars", Name = "Mercedes" },
                new Product { Category = "Phones", Name = "Iphone" },new Product { Category = "Phones", Name = "Samsung" },
                new Product { Category = "Phones", Name = "Nokia" },new Product { Category = "Phones", Name = "VeryLongNameOfPhone" },
            };

        private static List<Customer> customers = new List<Customer>()
        {
            new Customer { FullName = "2015,2017",
                Orders = new List<Order> { new Order { OrderDate = new DateTime(2015,1,1) },new Order { OrderDate = new DateTime(2017,1,1) } } },
            new Customer {FullName = "2011,2012",
                Orders = new List<Order> { new Order { OrderDate = new DateTime(2011,1,1) },new Order { OrderDate = new DateTime(2012,1,1) } } },
            new Customer { FullName = "2016,2017",
                Orders = new List<Order> { new Order { OrderDate = new DateTime(2016,1,1) },new Order { OrderDate = new DateTime(2017,1,1) } } },
        };

        public static void GetProductsLongestNameByCategory()
        {
            var longest = products
                .GroupBy(x => x.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Longest = g.Aggregate((max, cur) => max.Name.Length > cur.Name.Length ? max : cur)
                });

            longest.ToList().ForEach(x => { Console.WriteLine($"Longest in {x.Category} -> {x.Longest.Name}"); });
        }

        public static List<Customer> CustomersWithOrdersByYear(int year)
        {
            var result = customers.Where(c => c.Orders.Any(o => o.OrderDate.Year == year)).ToList();
            Console.WriteLine($"Customer with order in year {year}:");
            result.ForEach(c => { Console.WriteLine(c.FullName); });

            return result;
        }
    }
}
