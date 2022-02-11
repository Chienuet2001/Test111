using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_Demo
{
    class Account
    {
        private string accountName;
        private string passWord;

        public Account()
        {
        }

        public Account(string accountName, string passWord)
        {
            this.accountName = accountName;
            this.passWord = passWord;
        }

        public string AccountName { get => accountName; set => accountName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
    }
}
