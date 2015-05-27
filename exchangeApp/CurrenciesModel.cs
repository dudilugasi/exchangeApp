using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    class CurrenciesModel
    {
        private Dictionary<string, Currency> _currencies = new Dictionary<string, Currency>();
        private Currency _shekel = new Currency("Shekel", 1, "Israel", "NIS", 1);
        private IBankIsraelParser _parser = new BankIsraelParser();
        delegate Dictionary<string, Currency> GetDictionary();

        public void LoadCurrencies()
        {
            GetDictionary ob = _parser.GetCurrenciesFromWS;
            IAsyncResult asyncCall = ob.BeginInvoke(null, null);
            _currencies = ob.EndInvoke(asyncCall);
        }

        public IEnumerator<Currency> GetEnumerator()
        {
            List<Currency> list = _currencies.Values.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        public List<Currency> Currencies
        {
            get
            {
                return _currencies.Values.ToList();
            }
        }

        public List<string> Codes
        {
            get
            {
                return _currencies.Keys.ToList();
            }
        }

        public Currency Shekel
        {
            get
            {
                return _shekel;
            }
        }

        public Currency GetCurrencyByCode(string code)
        {
            return _currencies[code];
        }

        public double Convert(Currency from, Currency to, double amount)
        {
            return _parser.Convert(from, to, amount);
        }
    }
}
