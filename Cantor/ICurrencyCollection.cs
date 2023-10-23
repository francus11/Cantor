using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    public class CustomCurrencyCollection : Collection<Currency>
    {
        // Dodaj dodatkową logikę do klasy, jeśli to konieczne.
    }
    internal interface ICurrencyCollection<U> where U : CustomCurrencyCollection
    {
        public U Currencies { get; }
    }
}
