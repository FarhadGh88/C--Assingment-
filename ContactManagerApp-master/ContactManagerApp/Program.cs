using System;
using System.Collections.Generic;
using System.Linq;
using System.Tex;
using System.Threading.Tasks;

namespace ContactManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();

            contactManager.LoadData();
            contactManager.ListAllData();

            while (true)
            {
                Console.WriteLine("1. Add a contact");
                Console.WriteLine("2. List all contacts");
                Console.WriteLine("3. Display detailed information about a contact");
                Console.WriteLine("4. Delete a contact");
                Console.WriteLine("5. Exit an SaveData");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        contactManager.AddData();
                        break;
                    case "2":
                        contactManager.ListAllData();
                        break;
                    case "3":
                        contactManager.DisplayData();
                        break;
                    case "4":
                        contactManager.DeleteData();
                        break;
                    case "5":
                        contactManager.SaveData();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
