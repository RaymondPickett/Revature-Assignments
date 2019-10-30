using System;
using System.Collections.Generic;
using System.Text;

namespace RevatureProject0
{
    class Account
    {
        public string name;
        public double money;
        public string type;
        public bool mature;
        public int yearsUntillMaturity;
        public List<string> transactions = new List<string>();
    }
}