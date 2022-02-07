using System;

namespace UserManagementApplication
{
    class UserManager
    {
        static void Main(string[] args)
        {
            User[] user = new User[0];
            bool condition = true;
            do
            {
                int menuInput = printMenu();
                switch (menuInput)
                {
                    case 1:
                        user = storeData(user);
                        break;

                    case 2:
                        int index = displayData(user);
                        if (index == -1)
                            Console.WriteLine("This email id does not exist.");
                        else
                        {
                            Console.WriteLine("User name= " + user[index].UserName);
                            Console.WriteLine("User Id= " + user[index].UserId);
                            Console.WriteLine("Date of Birth= " + user[index].Dob);
                            Console.WriteLine("Gender= " + user[index].Gender);
                            Console.WriteLine("Guardian Name= " + user[index].GuardianName);
                        }
                        break;

                    case 3:
                        condition = false; break;
                    default:
                        Console.WriteLine("Invalid input"); break;

                }
            } while (condition);
        }

        private static int displayData(User[] user)
        {
            int index = -1;
            Console.WriteLine("Enter user id.");
            int userId = Convert.ToInt32(Console.ReadLine());
            if (user == null)
                return index;
            for (int i = 0; i < user.Length; i++)
            {
                if (userId==user[i].UserId)
                {
                    index = i; break;
                }
            }
            return index;
        }

        private static User[] storeData(User[] user)
        {
            int userId=0;
            string userName=null, dob=null, guardianName=null;
            char gender='\u0000';
            User user1 = new User();

            //user ID validation.....
            Console.WriteLine("Enter User ID:");
            bool condition = false;
            do
            {
                userId = Convert.ToInt32(Console.ReadLine());
                condition = validateUserId(user, userId);
            } while (!condition);

            //user name......
            Console.WriteLine("Enter user name:");
            userName = Console.ReadLine();

            //date of birth validation.....
            Console.WriteLine("Enter Date of birth (DD MM YYYY):");
            condition = false;
            
                int date = Convert.ToInt32(Console.ReadLine());
                int month = Convert.ToInt32(Console.ReadLine());
                int year = Convert.ToInt32(Console.ReadLine());
                //condition = checkDate(date, month, year);
                    dob = "" + date +"/ "+ month +"/ "+ year;
                    condition = true;
            


            //guardian name......
            Console.WriteLine("Enter guardian name:");
            guardianName = Console.ReadLine();

            //gender validation....
            Console.WriteLine("Enter Gender (F- female/ M- male/ O- others):");
            condition = false;
            do
            {
                gender = Convert.ToChar(Console.ReadLine());
                if (Char.IsUpper(gender))
                    gender = Char.ToUpper(gender);
                if (gender == 'f' || gender == 'm' || gender == 'o')
                    condition = true;
                else
                    Console.WriteLine("Invalid entry. Try again...");

            } while (!condition);

            user1 = new User(userId, userName, dob, guardianName, gender);
            user = addElement(user, user1);
            return user;
        }

        private static User[] addElement(User[] user, User user1)
        {
            User[] array = new User[user.Length + 1];
            for (int i = 0; i < user.Length; i++)
            {
                array[i] = user[i];
            }
            array[user.Length] = user1;
            return array;
        }

        static bool checkDate(int date, int month, int year)
        {
            bool check = false;
            short count = 0;
            if (date > 31 || month > 12 || date <= 0 || month <= 0 )
            {
                count++;
            }
            else
            {
                // ..........check leap year
                bool isLeap = false;
                if (year % 4 == 0)
                {
                    if (year % 100 == 0)
                    {
                        if (year % 400 == 0)
                            isLeap = true;
                        else
                            isLeap = false;

                    }
                    else
                        isLeap = true;
                }
                else
                    isLeap = false;

                if (month == 2 && isLeap == true && date < 1 && date > 29)
                    count++;
                else if (month == 2 && isLeap == false && date > 28)
                    count++;
                else if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 10 || month == 8 || month == 12)
                        && date > 31)
                    count++;
                else if ((month == 4 || month == 6 || month == 9 || month == 11) && date > 30)
                    count++;
                else
                    count = 0;
            }
            if (count != 0)
            {
                check = false;
            }
            else
                check = true;

            return check;
        }


        private static bool validateUserId(User[] user, int userId)
        {
            if (userId == 0)
            {
                Console.WriteLine("User Id should be greater than zero. Try again...");
                return false;
            }
            else if (user == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < user.Length; i++)
                {
                    if (userId == user[i].UserId)
                    {
                        Console.WriteLine("This user id is already occupied. Kindly enter another user id.");
                        return false;
                    }
                }
            }
            return true;
        }

        private static int printMenu()
        {
            Console.WriteLine("                   MENU                   ");
            Console.WriteLine("1. Create user contact.");   //option for showData method
            Console.WriteLine("2.Display user contact information.");      //option for displayData method
            Console.WriteLine("3.Exit.");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
