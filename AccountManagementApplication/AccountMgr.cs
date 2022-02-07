using System;

namespace AccountManagementApplication
{
    class AccountMgr 
    {
        static void Main(string[] args)
        {
            Account[] account = new Account[0];
            bool condition = true;
            do
            {
                int menuInput=printMenu();
                switch (menuInput)
                {
                    case 1:
                        account=storeData(account);
                        break;

                    case 2:
                        int index = displayData(account);
                        if (index == -1)
                            Console.WriteLine("This account Number does not exist.");
                        else
                        {
                            Console.WriteLine("Account Number= "+account[index].AccountNo);
                            Console.WriteLine("Account Type= "+ account[index].AccountType);
                            Console.WriteLine("Balance= "+ account[index].Balance);
                        }
                        break;

                    case 3:
                        condition = false; break;
                    default:
                        Console.WriteLine("Invalid input"); break;

                }
            } while (condition);
        }

        private static int displayData(Account[] account)
        {
            int index = -1;
            Console.WriteLine("Enter Account number.");
            int accountNo = Convert.ToInt32(Console.ReadLine());
            if (account == null)
                return index;
            for(int i = 0; i < account.Length; i++)
            {
                if (accountNo == account[i].AccountNo)
                {
                    index = i; break;
                }
            }
            return index;
        }

        private static Account[] storeData(Account[] account)
        {
            Account user;
            int accountNo=0, debitCardNo=0, pin=0;
            string accountType=null, loginId=null, password=null;
            double balance=0.0;

            //account number validation.....
            Console.WriteLine("Enter Account Number");
            bool accountNoValid = false;
            do
            {
                accountNo = Convert.ToInt32(Console.ReadLine());
                accountNoValid = validateAccountNo(accountNo, account);
            } while (!accountNoValid);

            // account Type validation.....
            Console.WriteLine("Enter account type (Savings/Current):");
            bool accountTypeValid = false;
            do
            {
                accountType = Console.ReadLine();
                accountTypeValid = validateAccountType(accountType);
            } while (!accountTypeValid);

            //debit card number validation
            Console.WriteLine("Enter your 10 digit Debit card Number:");
            bool debitCardNoValid = false;
            do
            {
                debitCardNo = Convert.ToInt32(Console.ReadLine());
                debitCardNoValid = validateDebitCardNo(debitCardNo, account);
            } while (!debitCardNoValid);


            //pin validation
            Console.WriteLine("Enter your 4 digit PIN:");
            bool pinValid = false;
            do
            {
                pin = Convert.ToInt32(Console.ReadLine());
                pinValid = validatePin(pin);
            } while (!pinValid);

            //Login Id validation
            Console.WriteLine("Enter Login Id:");
            bool idValid = false;
            do
            {
                loginId = Console.ReadLine();
                idValid = validateLoginId(loginId, account);
            } while (!idValid);

            //password validation
            Console.WriteLine("Enter password:");
            password = Console.ReadLine();
            // bool passwordValid = false;
            //do
            //{
            //    password = Console.ReadLine();
            //    passwordValid = validatePassword(password);
            //} while (!passwordValid);

            //balance validation
            Console.WriteLine("Enter account balance:");
            balance = Convert.ToDouble(Console.ReadLine());

            user = new Account(accountNo, debitCardNo, pin, accountType, loginId, password, balance);
            account = addElement(account, user);
            return account;
        }

        private static Account[] addElement(Account[] account, Account user)
        {
            Account[] array = new Account[account.Length + 1];
            for(int i=0; i < account.Length; i++)
            {
                array[i] = account[i];
            }
            array[account.Length] = user;
            return array;
        }

        private static bool validateLoginId(string loginId, Account[] account)
        {
            if (account == null)
            {
                return true;
            }

            for(int i = 0; i < account.Length; i++)
            {
                if (loginId.Equals(account[i].LoginId))
                {
                    Console.WriteLine("This Login Id is already registered with another account. Kindly enter another id:");
                    return false;
                }
            }
            return true;
        }

        private static bool validatePin(int pin)
        {
            if (pin.ToString().Length != 4)
            {
                Console.WriteLine("PIN should contain 4 digits. Try again...");
                return false;
            }
            else
                return true; 
        }

        private static bool validateDebitCardNo(int debitCardNo, Account[] account)
        {
            if (debitCardNo.ToString().Length !=10)
            {
                Console.WriteLine("Card Number should contain 10 digits. Try again...");
                return false;
            }
            else if (account == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < account.Length; i++)
                {
                    if (debitCardNo == account[i].DebitCardNo)
                    {
                        Console.WriteLine("This debit card number is already occupied. Kindly enter another debit card number.");
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool validateAccountType(string accountType)
        {
            accountType.ToLower();
            if (accountType.Equals("savings") || accountType.Equals("current"))
                return true;
            else
            {
                Console.WriteLine("Account Type can only be Savings or Current");
                return false;
            }
        }

        private static bool validateAccountNo(int accountNo, Account[] account)
        {
            if (accountNo == 0)
            {
                Console.WriteLine("Account Number should be greater than zero. Try again...");
                return false;
            }
            else if(account==null)
            {
                return true;
            }
            else
            {
                for(int i=0; i < account.Length; i++)
                {
                    if (accountNo == account[i].AccountNo)
                    {
                        Console.WriteLine("This account number is already occupied. Kindly enter another account number.");
                        return false;
                    }
                }
            }
            return true;
        }

        private static int printMenu()
        {
            Console.WriteLine("                   MENU                   ");
            Console.WriteLine("1. Create User Account.");   //option for showData method
            Console.WriteLine("2.Display User details.");      //option for displayData method
            Console.WriteLine("3.Exit.");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
