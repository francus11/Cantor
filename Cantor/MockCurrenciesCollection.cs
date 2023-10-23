using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    internal class MockCurrenciesCollection
    {
        private HashSet<Currency> _currencies;

        public HashSet<Currency> Currencies
        {
            get { return _currencies; }
        }
        public MockCurrenciesCollection()
        {
            Currency var1 = new Currency("Polski złoty", "PLN", 1, 1);
            Currency var2 = new Currency("Euro", "EUR", 4.50M, 1);
            Currency var3 = new Currency("Korona Czeska", "CZK", 0.18M , 100);
            _currencies = new HashSet<Currency>
            {
                var1,
                var2,
                var3
            };
        }
    }
}
