using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchangeApp
{
    class Currency
    {
        private string _name;
        private int _unit;
        private string _country;
        private string _code;
        private double _rate;
        

        public Currency(string name,int unit,string country,string code,double rate)
        {
            this.Name = name;
            this.Unit = unit;
            this.Country = country;
            this.Code = code;
            this.Rate = rate;
        }

        public static implicit operator double(Currency ob)
        {
            return ob._rate;
        }

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

        

        public override string ToString() 
        {
            return "name = " + _name + ", unit = " + _unit + ", code = " + _code + ", country = " + _country + ", rate = " + _rate;
        }

    }
    
}
