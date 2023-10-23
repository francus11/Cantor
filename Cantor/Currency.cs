using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    public class Currency
    {
        private string _fullName;
        private string _code;
        private decimal _value;
        private long _multiplier;

        public string Fullname
        {
            get { return _fullName; }
            private set { _fullName = value; }
        }

        public string Code
        {
            get { return _code; }
            private set { _code = value; }
        }

        public decimal Value
        {
            get { return _value; }
            private set { _value = value; }
        }

        public long Multiplier
        {
            get { return _multiplier; }
            private set { _multiplier = value; }
        }

        public Currency(string fullName, string code, decimal value, long multiplier)
        {
            if (fullName is null)
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            Fullname = fullName;
            Code = code;
            Value = value;
            Multiplier = multiplier;
        }

        public Currency(Currency other)
        {
            Fullname = other.Fullname;
            Code = other.Code;
            Value = other.Value;
            Multiplier = other.Multiplier;
        }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
