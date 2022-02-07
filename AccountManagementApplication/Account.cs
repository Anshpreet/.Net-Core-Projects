using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagementApplication
{
    class Account
    {
        
        private int accountNo, debitCardNo, pin;
        private string accountType, loginId, password;
        private double balance;

       public Account()
        {

        }
        public Account(int accountNo,int debitCardNo, int pin, string accountType, string loginId, string password, double balance)
        {
            this.accountNo = accountNo;
            this.balance = balance;
            this.debitCardNo = debitCardNo;
            this.pin = pin;
            this.accountType = accountType;
            this.loginId = loginId;
            this.password = password;
        }
        public double Balance { get => balance; set => balance = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public string LoginId { get => loginId; set => loginId = value; }
        public string Password { get => password; set => password = value; }
        public int AccountNo { get => accountNo; set => accountNo = value; }
        public int DebitCardNo { get => debitCardNo; set => debitCardNo = value; }
        public int Pin { get => pin; set => pin = value; }
    }
}
