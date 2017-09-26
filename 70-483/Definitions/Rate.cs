using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Definitions
{
    [DataContract(Name = "Indywidual")]
    public class Rate : IRate
    {
        [DataMember(EmitDefaultValue = false)]
        public int MyInt { get; set; }
        public bool MyIntSpecified { get; set; }

        [DataMember(Order = 10)]
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }

        [DataMember]
        public string Name { get; set; }
        public Rate GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Rate GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public event MaximumTerm OnMaximumTerm;

        public int Term
        {
            set
            {
                if (value < 10)
                {
                    if (OnMaximumTerm != null)
                    {
                        OnMaximumTerm(this, new EventArgs());
                    }
                }
            }
        }
        public delegate void MaximumTerm(object source, EventArgs e);
    }

    public interface IRate
    {
        Rate GetById(int id);
        Rate GetById(int? id);
    }

    public class RateCollection : IEnumerable
    {
        private readonly Rate[] _rateCollection;

        public RateCollection(Rate[] rateArray)
        {
            _rateCollection = new Rate[rateArray.Length];
            for (int i = 0; i < rateArray.Length; i++)
            {
                _rateCollection[i] = rateArray[i];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return _rateCollection.GetEnumerator();
        }
    }
}
