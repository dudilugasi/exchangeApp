using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    interface IBankIsraelParser
    {
        Dictionary<string, Currency> GetCurrenciesFromWS();

        double Convert(Currency from, Currency to, double amount);

    }
}
