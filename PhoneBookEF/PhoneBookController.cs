using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookEF
{
    public class PhoneBookController
    {
        public static void AddContact() 
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            if (!Validator.IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format.");
                return;
            }
            Console.WriteLine("Enter Phone Number (10 digits): ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            if (!Validator.IsValidPhone(phoneNumber))
            {
                Console.WriteLine("Invalid phone number format. It should be 10 digits.");
                return;
            }

            var contact = new Contact
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber
            };
            using (var context = new PhoneBookContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
                Console.WriteLine("Contact added successfully.");
            }
        }

        public static void ListContacts() 
        { 
            using var db = new PhoneBookContext();
            var contacts = db.Contacts.ToList();

            if (contacts.Count == 0) 
            { 
                Console.WriteLine("No contacts found.");
                return;
            }
            Console.WriteLine("List of Contacts:");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("{0,-5} {1,-20} {2,-25} {3,-15}", "ID", "Name", "Email", "Phone");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach (var contact in contacts)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-25} {3,-15}", 
                    contact.Id, 
                    contact.Name, 
                    contact.Email, 
                    contact.PhoneNumber);
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public static void UpdateContact() 
        { 
            using var db = new PhoneBookContext();
            ListContacts();
            if (db.Contacts.Count() == 0)
            {
                Console.WriteLine("❌ No contacts available to update.");
                return;
            }

            Console.WriteLine("Enter the ID of the contact to update: ");
           
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            var contact = db.Contacts.Find(id);
         
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
           
            Console.WriteLine("Enter new Name (leave empty to keep current): ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter new Email (leave empty to keep current): ");
            string email = Console.ReadLine() ?? string.Empty;
          
            if (!string.IsNullOrEmpty(email) && !Validator.IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format.");
                return;
            }
            Console.WriteLine("Enter new Phone Number (leave empty to keep current): ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;
          
            if (!string.IsNullOrEmpty(phoneNumber) && !Validator.IsValidPhone(phoneNumber))
            {
                Console.WriteLine("Invalid phone number format. It should be 10 digits.");
                return;
            }   
            if (!string.IsNullOrEmpty(name)) 
            {
                contact.Name = name;
            }
            if (!string.IsNullOrEmpty(email)) 
            {
                contact.Email = email;
            }
            if (!string.IsNullOrEmpty(phoneNumber)) 
            {
                contact.PhoneNumber = phoneNumber;
            }
            db.SaveChanges();
            Console.WriteLine("Contact updated successfully.");

        }

        public static void DeleteContact() 
        {
            using var db = new PhoneBookContext();
            ListContacts();
            if (db.Contacts.Count() == 0)
            {
                Console.WriteLine("No contacts available to delete.");
                return;
            }
            Console.WriteLine("Enter the ID of the contact to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            var contact = db.Contacts.Find(id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
            db.Contacts.Remove(contact);
            db.SaveChanges();
            Console.WriteLine("Contact deleted successfully.");
        }
    }
}
