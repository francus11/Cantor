using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor
{
    public interface ICurrenciesProvider
    {
        public List<Currency> DownloadData(string url);
    }
}
