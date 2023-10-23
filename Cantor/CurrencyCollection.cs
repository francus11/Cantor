using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    class CurrencyCollection
    {
        private List<Currency> _currencies;

        static private CurrencyCollection instance;

        public HashSet<Currency> Currencies
        { 
            get { return new HashSet<Currency>(_currencies); } 
        }

        private CurrencyCollection()
        {
            XMLCurrenciesProvider xMLCurrenciesProvider = new XMLCurrenciesProvider();
            List<Currency> currencies = xMLCurrenciesProvider.DownloadData("https://www.nbp.pl/kursy/xml/lasta.xml");
            Currency pln = new Currency("Polski złoty nowy", "PLN", 1, 1);
            currencies.Add(pln);
            _currencies = currencies;
        }


        public Currency GetCurrencyByCode(string code) 
        { 
            foreach (Currency cur in _currencies)
            {
                if (cur.Code == code)
                {
                    return cur;
                }
            }

            throw new ArgumentException("Currency with that code doesn't exist");
        }

        static public CurrencyCollection Instance()
        {
            if (instance == null)
            {
                instance = new CurrencyCollection();
            }

            return instance;
        }
    }
}
