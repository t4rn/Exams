using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Definitions
{
    [Serializable]
    public class Product : IValidatableObject
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        protected string Name { get; private set; }
        public bool IsValid { get; set; }

        public delegate void AddProductCallback(int i);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public void Add(string name)
        {
            AddProduct(name, delegate (int i)
            {
                Console.WriteLine($"From delegate with i = {i}");
            });
        }
        private void AddProduct(string name, AddProductCallback callback)
        {
            callback(15);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Save<T>(T target) where T : Product, new()
        {
        }
    }
}
