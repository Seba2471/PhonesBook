using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhonesBook
{
    internal class Contact
    {

        public Contact(string phoneNumber, string name)
        {
            if (phoneNumber.Length < 9)
            {
                Console.WriteLine("Phone number is too short");
            }
            else if (phoneNumber.Length > 9)
            {
                Console.WriteLine("Phone number is too long");
            }
            else
            {
                this.Name = name;
                this.PhoneNumber = phoneNumber;
            }
        }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public static string GetPhoneNumberFromUser()
        {
            Console.WriteLine("Insert phone number:");
            string phoneNumber = Console.ReadLine();
            while (!Contact.PhoneNumberIsValid(phoneNumber))
            {
                Console.WriteLine("Phone number is incorrect, insert phone number again:");
                phoneNumber = Console.ReadLine();
            }


            return phoneNumber;
        }
        public static string GetNameFromUser()
        {
            Console.WriteLine("Insert contact name:");
            string name = Console.ReadLine();
            while (name == "")
            {
                Console.WriteLine("Name don't be empty, Insert contact name again:");
                name = Console.ReadLine();
            }

            return name;
        }

        public static Contact GetContactFromUser()
        {
            string phoneNumber = GetPhoneNumberFromUser();
            string name = GetNameFromUser();
            return new Contact(phoneNumber, name);
        }

        public static bool PhoneNumberIsValid(string phoneNumber)
        {
            Regex regex = new Regex(@"^[0-9]{9}$");

            return regex.IsMatch(phoneNumber);
        }
        public static void DisplayDirectoryContacts(Dictionary<string, Contact> contactsBook)
        {
            Console.WriteLine("Contact list:");
            foreach (Contact contact in contactsBook.Values)
            {
                Console.WriteLine($"{contact.Name} {contact.PhoneNumber}");
            }

            Console.WriteLine();
        }

        public static void DisplayContactByPhoneNumber(Dictionary<string, Contact> contactsBook, string phoneNumber)
        {
            Contact contact = null;
            if (contactsBook.TryGetValue(phoneNumber, out contact))
            {
                Console.WriteLine("Contact: ");
                Console.WriteLine($"{contact.Name} {contact.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("This contact not exists");
            }
        }

        public static List<Contact> SearchContactsByName(Dictionary<string, Contact> contactsBook, string name)
        {
            var searchedContacts = contactsBook.Values.Where((Contact c) => c.Name.Contains(name));

            return new List<Contact>(searchedContacts);
        }

        public static void DisplayListContacts(List<Contact> contactsList)
        {
            Console.WriteLine("Contact list:");
            foreach (Contact contact in contactsList)
            {
                Console.WriteLine($"{contact.Name} {contact.PhoneNumber}");
            }

            Console.WriteLine();
        }

        public static Dictionary<string, Contact> AddPhoneNumberToPhonesBook(Dictionary<string, Contact> contactsBook,
            Contact contact)
        {
            if (!contactsBook.TryAdd(contact.PhoneNumber, contact))
            {
                Console.WriteLine("This phone number exists in phones book");
            }

            Console.WriteLine("Contact added");

            return contactsBook;
        }
    }
}
