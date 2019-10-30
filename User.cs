using System;
using System.Collections.Generic;
using System.Text;

namespace RevatureProject0
{
    class User
    {
        public string name;
        public string password;
        public List<Account> accounts = new List<Account>();
    }
}