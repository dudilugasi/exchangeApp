using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    /// <summary>
    /// this class describes a currency
    /// </summary>
    class Currency
    {
        private string _name;
        private int _unit;
        private string _country;
        private string _code;
        private double _rate;
        
        /// <summary>
        /// currency constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="unit"></param>
        /// <param name="country"></param>
        /// <param name="code"></param>
        /// <param name="rate"></param>
        public Currency(string name,int unit,string country,string code,double rate)
        {
            this.Name = name;
            this.Unit = unit;
            this.Country = country;
            this.Code = code;
            this.Rate = rate;
        }

        /// <summary>
        /// an implicit casting operator from currency to its double valued rate
        /// </summary>
        /// <param name="ob"> the currency to be cast to double</param>
        /// <returns> a double value</returns>
        public static implicit operator double(Currency ob)
        {
            return ob._rate;
        }

        /// <summary>
        /// this property refers to the currency name
        /// </summary>
        public string Name
        {
            get {return _name;}
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    throw new ExchangeAppException("name is null");
                }
            }
        }

        /// <summary>
        /// this property refers to the currency unit
        /// </summary>
        public int Unit
        {
            get {return _unit;}
            set
            {
                if (value > 0)
                {
                    _unit = value;
                }
                else
                {
                    throw new ExchangeAppException("unit is non-positive value");
                }
            }
        }

        /// <summary>
        /// this property refers to the currency country
        /// </summary>
        public string Country
        {
            get {return _country;}
            set
            {
                if (value != null)
                {
                    _country = value;
                }
                else
                {
                    throw new ExchangeAppException("country value is null");
                }
            }
        }

        /// <summary>
        /// this property refers to the currency country code
        /// </summary>
        public string Code
        {
            get {return _code;}
            set
            {
                if (value != null)
                {
                    _code = value;
                }
                else
                {
                    throw new ExchangeAppException("code value is null");
                }
            }
        }

        /// <summary>
        /// this property refers to the currency rate
        /// </summary>
        public double Rate
        {
            get {return _rate;}
            set
            {
                if (value > 0)
                {
                    _rate = value;
                }
                else
                {
                    throw new ExchangeAppException("rate is non-positive value");
                }
            }
        }


        /// <summary>
        /// override the ToString method 
        /// </summary>
        /// <returns>string describing the currency</returns>
        public override string ToString() 
        {
            return "name = " + _name + ", unit = " + _unit + ", code = " + _code + ", country = " + _country + ", rate = " + _rate;
        }

    }
    
}
