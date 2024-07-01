using System;
using System.Collections.Generic;
using System.IO;

namespace ContactManagementSystem
{
    class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Phone: {PhoneNumber}, Email: {Email}, Address: {Address}";
        }
    }

    class ContactManager
    {
        private List<Contact> contacts;
        private string filePath = "contacts.txt";

        public ContactManager()
        {
            contacts = new List<Contact>();
            LoadContacts();
        }

        public void AddContact(string name, string phoneNumber, string email, string address)
        {
            int id = contacts.Count > 0 ? contacts[^1].Id + 1 : 1;
            contacts.Add(new Contact { Id = id, Name = name, PhoneNumber = phoneNumber, Email = email, Address = address });
            SaveContacts();
        }

        public void UpdateContact(int id, string name, string phoneNumber, string email, string address)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                contact.Name = name;
                contact.PhoneNumber = phoneNumber;
                contact.Email = email;
                contact.Address = address;
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DeleteContact(int id)
        {
            contacts.RemoveAll(c => c.Id == id);
            SaveContacts();
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        public void SearchContact(string name)
        {
            var result = contacts.FindAll(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (result.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var contact in result)
            {
                Console.WriteLine(contact);
            }
        }

        private void SaveContacts()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Id}|{contact.Name}|{contact.PhoneNumber}|{contact.Email}|{contact.Address}");
                }
            }
        }

        private void LoadContacts()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        contacts.Add(new Contact
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            PhoneNumber = parts[2],
                            Email = parts[3],
                            Address = parts[4]
                        });
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();
            while (true)
            {
                Console.WriteLine("Contact Management System");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Update Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Contacts");
                Console.WriteLine("5. Search Contact");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        manager.AddContact(name, phoneNumber, email, address);
                        break;
                    case 2:
                        Console.Write("Enter Contact ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Phone Number: ");
                        string newPhoneNumber = Console.ReadLine();
                        Console.Write("Enter New Email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Enter New Address: ");
                        string newAddress = Console.ReadLine();
                        manager.UpdateContact(updateId, newName, newPhoneNumber, newEmail, newAddress);
                        break;
                    case 3:
                        Console.Write("Enter Contact ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        manager.DeleteContact(deleteId);
                        break;
                    case 4:
                        manager.DisplayContacts();
                        break;
                    case 5:
                        Console.Write("Enter Name to search: ");
                        string searchName = Console.ReadLine();
                        manager.SearchContact(searchName);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
