using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApp
{
    public class ContactManager
    {
        private List<ContactInfo> contactList;
        private const string fileName = "contacts.json";
        public void LoadData()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                contactList = JsonConvert.DeserializeObject<List<ContactInfo>>(json);
            }
            else
            {
                contactList = new List<ContactInfo>();
            }
        }

        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(contactList, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public void AddData()
        {
            int newId = contactList.Count + 1;
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter email address: ");
            string emailAddress = Console.ReadLine();
            Console.Write("Enter address information: ");
            string address = Console.ReadLine();

            ContactInfo newContact = new ContactInfo
            {
                Id=newId,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress,
                Address = address
            };

            contactList.Add(newContact);
        }

      
        public void ListAllData()
        {
            Console.WriteLine("All Contacts:");
            foreach (var contact in contactList)
            {
                Console.WriteLine($"Id:{contact.Id}, Name: {contact.FirstName} {contact.LastName}, Email: {contact.EmailAddress}");
            }
            Console.WriteLine();
        }

        public void DisplayData()
        {
            Console.Write("Enter email address to display details: ");
            string emailAddress = Console.ReadLine();

            ContactInfo contact = contactList.Find(c => c.EmailAddress == emailAddress);

            if (contact != null)
            {
                Console.WriteLine($"Id: {contact.Id}");
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email Address: {contact.EmailAddress}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DeleteData()
        {
            Console.Write("Enter email address to delete contact: ");
            string emailAddress = Console.ReadLine();

            ContactInfo contactToRemove = contactList.Find(c => c.EmailAddress == emailAddress);

            if (contactToRemove != null)
            {
                contactList.Remove(contactToRemove);
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
