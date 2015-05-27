using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    /// <summary>
    /// this class holds the data of the currencies
    /// </summary>
    class CurrenciesModel
    {
        private Dictionary<string, Currency> _currencies = new Dictionary<string, Currency>();
        private Currency _shekel = new Currency("Shekel", 1, "Israel", "NIS", 1);
        private IBankIsraelParser _parser = new BankIsraelParser();
        delegate Dictionary<string, Currency> GetDictionary();

        /// <summary>
        /// this method activate the GetCurrenciesFromWS and assign the dictionary to the model
        /// </summary>
        public void LoadCurrencies()
        {
            GetDictionary ob = _parser.GetCurrenciesFromWS;
            IAsyncResult asyncCall = ob.BeginInvoke(null, null);
            _currencies = ob.EndInvoke(asyncCall);
        }

        /// <summary>
        /// get enumeretor so the model can e use in foreach statement
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Currency> GetEnumerator()
        {
            List<Currency> list = _currencies.Values.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }


        /// <summary>
        /// this property refers to the model currencies values
        /// </summary>
        public List<Currency> Currencies
        {
            get
            {
                return _currencies.Values.ToList();
            }
        }

        /// <summary>
        /// this property refers to the model currencies codes
        /// </summary>
        public List<string> Codes
        {
            get
            {
                return _currencies.Keys.ToList();
            }
        }

        /// <summary>
        /// this property refers to the shekel currency
        /// </summary>
        public Currency Shekel
        {
            get
            {
                return _shekel;
            }
        }

        /// <summary>
        /// this method get a single currency by its key
        /// </summary>
        /// <param name="code">this string refers to the currency code</param>
        /// <returns>a currency object</returns>
        public Currency GetCurrencyByCode(string code)
        {
            return _currencies[code];
        }

        /// <summary>
        /// this method activate the convertion method
        /// </summary>
        /// <param name="from">the currency from which we need to convert</param>
        /// <param name="to">the currency to which we need to convert</param>
        /// <param name="amount">the amount of money to be converted</param>
        /// <returns>the amount of money after convertion</returns>
        public double Convert(Currency from, Currency to, double amount)
        {
            return _parser.Convert(from, to, amount);
        }
    }
}
