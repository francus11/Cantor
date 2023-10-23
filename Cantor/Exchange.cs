using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    class Exchange : IExchange
    {
        public decimal Calculate(Currency primaryCurrency, decimal primaryAmount, Currency secondaryCurrency)
        {
            if (primaryCurrency is null)
            {
                throw new ArgumentNullException(nameof(primaryCurrency));
            }

            if (secondaryCurrency is null)
            {
                throw new ArgumentNullException(nameof (secondaryCurrency));
            }

            if (primaryAmount <= 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(primaryAmount), "Amount can't be less or equal zero");
            }

            return (primaryCurrency.Value / primaryCurrency.Multiplier) / (secondaryCurrency.Value / secondaryCurrency.Multiplier) * primaryAmount;
        }

    }
}
