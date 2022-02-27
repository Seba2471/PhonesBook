
namespace PhonesBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Contact> contactsBook = new Dictionary<string, Contact>();

            int userPick = UserSelectionMenu();


            while (userPick != 5)
            {
                switch (userPick)
                {
                    case 1:
                        Contact newContact = Contact.GetContactFromUser();
                        Contact.AddPhoneNumberToPhonesBook(contactsBook, newContact);
                        Console.WriteLine();
                        break;
                    case 2:
                        string phoneNumber = Contact.GetPhoneNumberFromUser();
                        Contact.DisplayContactByPhoneNumber(contactsBook, phoneNumber);
                        break;
                    case 3:
                        Contact.DisplayDirectoryContacts(contactsBook);
                        break;
                    case 4:
                        string name = Contact.GetNameFromUser();
                        var result = Contact.SearchContactsByName(contactsBook, name);
                        Contact.DisplayListContacts(result);
                        break;
                }

                userPick = UserSelectionMenu();
            }


        }

        public static int UserSelectionMenu()
        {
            Console.WriteLine("Choose option from menu:");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. Get contact based on phone number");
            Console.WriteLine("3. Get all contact");
            Console.WriteLine("4. Search contact for a given name");
            Console.WriteLine("5. Exit");

            return int.Parse(Console.ReadLine());
        }
    }
}