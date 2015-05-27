using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    /// <summary>
    /// this interface has two method for the exchange app
    /// </summary>
    interface IBankIsraelParser
    {
        /// <summary>
        /// get a dictionary of currencies from a web server
        /// </summary>
        /// <returns>a dictionary conatining all the currencies</returns>
        Dictionary<string, Currency> GetCurrenciesFromWS();

        /// <summary>
        /// this method convert any amount from one currency to another
        /// </summary>
        /// <param name="from">the currency from which we need to convert</param>
        /// <param name="to">the currency to which we need to convert</param>
        /// <param name="amount">the amount of money to be converted</param>
        /// <returns>the amount of money after convertion</returns>
        double Convert(Currency from, Currency to, double amount);

    }
}
