﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace exchangeApp
{
    class BankIsraelParser : IBankIsraelParser
    {

        public Dictionary<string, Currency> GetCurrenciesFromWS()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("http://boi.org.il/currency.xml");
                XDocument ob = XDocument.Parse(doc.OuterXml);
                var currencies = from x in ob.Descendants("CURRENCY")
                                 select new
                                 {
                                     Name = x.Descendants("NAME").First().Value,
                                     Unit = x.Descendants("UNIT").First().Value,
                                     Country = x.Descendants("COUNTRY").First().Value,
                                     Code = x.Descendants("CURRENCYCODE").First().Value,
                                     Rate = x.Descendants("RATE").First().Value,
                                 };
                Dictionary<string, Currency> currenciesDictionary = new Dictionary<string, Currency>();
                foreach (var currency in currencies)
                {
                    currenciesDictionary.Add(currency.Code,
                        new Currency(currency.Name, Int32.Parse(currency.Unit), currency.Country, currency.Code, Double.Parse(currency.Rate)));
                }
                return currenciesDictionary;
            }
            catch (XmlException e)
            {
                throw new ExchangeAppException("problem loading XML file");
            }

        }

        public double Convert(Currency from, Currency to, double amount)
        {
            return (amount * from.Rate / from.Unit) / (to.Rate / to.Unit);
        }
    }
}
