using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    class ExchangeAppException : ApplicationException
    {
        public ExchangeAppException(String str)
            : base(str)
        {

        }

    }
}
