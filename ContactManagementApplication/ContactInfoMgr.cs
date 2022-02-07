using System;

namespace ContactManagementApplication
{
    class ContactInfoMgr 
    {
        static void Main(string[] args)
        {
            ContactInfo[] contact= new ContactInfo[0];
            bool condition = true;
            do
            {
                int menuInput = printMenu();
                switch (menuInput)
                {
                    case 1:
                        contact = storeData(contact);
                        break;

                    case 2:
                        int index = displayData(contact);
                        if (index == -1)
                            Console.WriteLine("This email id does not exist.");
                        else
                        {
                            Console.WriteLine("Email id= " + contact[index].EmailId);
                            Console.WriteLine("Address= " + contact[index].Address +", "+contact[index].City
                                +", "+contact[index].State+", "+contact[index].Country);
                        }
                        break;

                    case 3:
                        condition = false; break;
                    default:
                        Console.WriteLine("Invalid input"); break;

                }
            } while (condition);
        }

        private static int displayData(ContactInfo[] contact)
        {
            int index = -1;
            Console.WriteLine("Enter email id.");
            String emailId = Console.ReadLine();
            if (contact == null)
                return index;
            for (int i = 0; i < contact.Length; i++)
            {
                if (emailId.Equals(contact[i].EmailId))
                {
                    index = i; break;
                }
            }
            return index;
        }

        private static ContactInfo[] storeData(ContactInfo[] contact)
        {
            ContactInfo user;
            string address=null, city=null, country=null, state=null, mobileNo=null, emailId=null;
            Console.WriteLine("Enter email Id: ");
            emailId = Console.ReadLine();
            Console.WriteLine("Enter mobile no: ");
            mobileNo = Console.ReadLine();
            Console.WriteLine("Enter address Line 1: ");
            address = Console.ReadLine();
            Console.WriteLine("Enter city: ");
            city = Console.ReadLine();
            Console.WriteLine("Enter state: ");
            state = Console.ReadLine();
            Console.WriteLine("Enter country: ");
            country = Console.ReadLine();

            user = new ContactInfo(address, city, country, state, mobileNo, emailId);
            contact = addElement(contact, user);
            return contact;

        }

        private static ContactInfo[] addElement(ContactInfo[] contact, ContactInfo user)
        {
            ContactInfo[] array = new ContactInfo[contact.Length + 1];
            for (int i = 0; i < contact.Length; i++)
            {
                array[i] = contact[i];
            }
            array[contact.Length] = user;
            return array;
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
