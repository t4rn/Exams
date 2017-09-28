using Exam70_483.Definitions;
using Exam70_483.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
    class Program
    {
        public interface IDataContainer
        {
            string Data { get; set; }
        }


        static void Main(string[] args)
        {
            Trace.Write("START");
            Formaters.DateAndTime(DateTime.Now, 10.23456D);
            Debuggers.Start();
            var customers = Linqers.CustomersWithOrdersByYear(2017);
            Linqers.GetProductsLongestNameByCategory();

            string asyncResult;
            Task.Run(async () =>
            {
                asyncResult = await Threads.StartAsync();
            }).GetAwaiter().GetResult();

            
            Threads.RunTimer();
            var publicTypes = new Reflections().GetPublicTypes();
            var assemblyName = new Reflections().GetAssemblyName();
            var isPositiveDecimal = Regexes.PositiveWithTwoDecimalPlaces(5.666M);

            Console.WriteLine("Available memory: " + new PerformanceCounter("Memory", "Available MBytes").NextValue());

            var assemblies = new Reflections().GetTypesFromCurrentDomain();

            Product productForSerialization = new Product() { CategoryId = 1, Id = 2, IsValid = true };

            Serializators.SerializeWithBinaryFormatter(productForSerialization, "bin.dat");
            Serializators.SerializeWithDataContractToFile(productForSerialization, "datacontract.dat");


            string userSerialized = Serializators.SerializeWithBinaryWriter(new Product { Id = 10 });
            DateTime? nullableDateTime = null;
            bool isDateNotNull = nullableDateTime.HasValue;

            RateCollection rateCollection = new RateCollection(new Rate[] { new Rate { Value = 1 } });
            foreach (var item in rateCollection)
            {
                Console.WriteLine(item);
            }

            var currentAssembly = Assembly.GetExecutingAssembly();

            var sb = new StringBuilder();
            sb.Append("First");
            sb.AppendLine();
            sb.Append("Second");
            Console.WriteLine(sb);

            SortedList<string, string> sortedList = new SortedList<string, string>() { { "asd", "dsa" } };

            Debug.Assert(false, "stop");
            float amount = 1.6F;
            object amountObj = amount;
            int amountInt = (int)(float)amountObj;

            new Product().Add("book1");

            User newUser = new User() { UserGroup = Group.Supervisors | Group.Users };
            bool isTrue = newUser.UserGroup < Group.Administrator;
            var userGroup = newUser.UserGroup;
            Console.WriteLine(userGroup);

            string stringNull = null;
            string stringNotNull = "asd";

            Comparers.AreEqual(stringNull, stringNotNull);

            Rate rate1 = new Rate() { Value = 1, Category = "cat" };
            string xml = Serializators.SerializeWithDataContract(rate1);
            string json = Serializators.SerializeWithDataContractJson(rate1);

            Console.WriteLine("xml:\r\n" + xml);
            Console.WriteLine("json:\r\n" + json);

            Subscriber sub = new Subscriber();
            sub.Subscribe();
            sub.Execute();


            Console.Read();
            return;


            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Rate));
            Console.WriteLine(string.Format("{0} asdasd {1:000#} asd", 4, 159));
            Console.WriteLine(123.ToString("000#"));

            Rate ratenull = null;
            int wynik;
            int.TryParse(ratenull.Category, out wynik);

            Console.Read();

            BaseLogger logger = new Logger();
            logger.Log("Log started");
            logger.Log("Base: Log contiuniug");
            ((Logger)logger).LogCompleted();


            Console.Read();
            return;


            Reflections.SetPropertiesOnObject(new Rate() { MyInt = 10 }, "MyInt", "MyIntSpecified");
            float mojfloat = 1.6F;
            double dable = (double)mojfloat;
            var hashed = Hashers.HashByAlgName(@"C:\windows-version.txt", "SHA");

            Threads.ConcurrentDict();
            var x = from i in new List<int> { 1, 2 }
                    group i by i into grouped
                    where grouped.Key > 1
                    select grouped.Key;


            string xmlInput = "<xml><RateSheet><rate category=\"boutou\" date=\"2012-12-12\"><value>0.03</value></rate><rate category=\"druga\" date=\"2011-11-11\"><value>0.04</value></rate></RateSheet></xml>";

            var result = Serializators.ReadFromXml(xmlInput);

            SHA1Managed SHhash = new SHA1Managed();

            //new Class2().Method1();
            Class1 class1 = new Class1();
            INewInterface interf = class1;
            interf.Method1();

            IEnumerable<Person> people = new List<Person>() {
                new Person { PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "1" }, new PhoneNumber { Number = "2" } } },
                new Person { PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "2" }, new PhoneNumber { Number = "3" } } },
            };

            IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);
            IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

        }
    }

    public class Alert
    {
        public event EventHandler<EventArgs> SendMessage;
        public void Execute()
        {
            SendMessage(this, new EventArgs());
        }
    }

    public class Subscriber
    {
        Alert alert = new Alert();
        public void Subscribe()
        {
            alert.SendMessage += (sender, e) => { Console.WriteLine("First"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Second"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Third"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Third"); };
        }

        public void Execute()
        {
            alert.Execute();
        }
    }

    public interface INewInterface
    {
        void Method1();
    }
    public class Class2 : INewInterface
    {
        void INewInterface.Method1()
        {
            throw new NotImplementedException();
        }
    }

    public class Class1 : Class2
    {
    }

    public class Comp : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDupable<out T> where T : class, new()
    {
    }
}
