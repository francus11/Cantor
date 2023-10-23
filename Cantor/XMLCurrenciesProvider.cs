using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Cantor
{
    public class XMLCurrenciesProvider : ICurrenciesProvider
    {
        public List<Currency> DownloadData(string url)
        {
            string xml = LoadXMLFromWeb(url);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Encoding iso8859Encoding = Encoding.GetEncoding("ISO-8859-2");
            byte[] isoBytes = iso8859Encoding.GetBytes(xml);

            // Konwertuj tablicę bajtów na UTF-8
            Encoding utf8Encoding = Encoding.UTF8;
            byte[] utf8Bytes = Encoding.Convert(iso8859Encoding, utf8Encoding, isoBytes);

            // Dekoduj tablicę bajtów na tekst UTF-8
            string decodedXml = utf8Encoding.GetString(utf8Bytes);

            /*Encoding encoding = Encoding.UTF8;

            byte[] encodedBytes = encoding.GetBytes(xml);
            string decodedXml = encoding.GetString(encodedBytes);*/
            List<Currency> result = new List<Currency>();

            XDocument xdoc = XDocument.Parse(decodedXml);



            foreach (XElement pozycja in xdoc.Element("tabela_kursow").Elements("pozycja"))
            {
                string currencyName = pozycja.Element("nazwa_waluty").Value;
                long multiplier;
                long.TryParse(pozycja.Element("przelicznik").Value, out multiplier);
                string code = pozycja.Element("kod_waluty").Value;
                decimal currencyValue;
                decimal.TryParse(pozycja.Element("kurs_sredni").Value, out currencyValue);

                result.Add(new Currency(currencyName, code, currencyValue, multiplier));

            }

            return result;
        }

        private string LoadXMLFromWeb(string url)
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(url);
                return xmlContent;
            }
        }
    }
}
