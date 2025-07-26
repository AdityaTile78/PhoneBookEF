using System;
using PhoneBookEF;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("📞 Welcome to Phone Book");

        // Call your menu or logic here
        RunMenu();
    }

    static void RunMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Phone Book Menu ---");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    PhoneBookController.AddContact();
                    break;
                case "2":
                    PhoneBookController.ListContacts();
                    break;
                case "3":
                    PhoneBookController.UpdateContact();
                    break;
                case "4":
                    PhoneBookController.DeleteContact();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
