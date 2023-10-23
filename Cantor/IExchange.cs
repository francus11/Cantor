using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    public interface IExchange
    {
        public decimal Calculate(Currency primaryCurrency, decimal primaryAmount, Currency secondaryCurrency);
    }
}
