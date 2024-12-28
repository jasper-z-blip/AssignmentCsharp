using ContactApp.Services;
using ContactApp.Models;

namespace ContactApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "contacts.json";
            var jsonService = new JsonService(filePath);
            var contactService = new ContactService(jsonService);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ContactApp - Main Menu");
                Console.WriteLine("1. Add new contact");
                Console.WriteLine("2. List of all contacts");
                Console.WriteLine("3. Exit program");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        AddNewContact(contactService);
                        break;

                    case "2":
                        ListOfAllContacts(contactService);
                        break;

                    case "3":
                        Console.WriteLine("Closing program..");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option, press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void AddNewContact(ContactService contactService)
        {
            Console.Clear();
            Console.WriteLine("Add new contact");

            var contact = new Contact
            {
                FirstName = ReadValidInput("First Name", ValidationService.IsValidName, "Name must contain only letters and be at least 2 characters long."
                ),
                LastName = ReadValidInput("Last Name", ValidationService.IsValidName, "Name must contain only letters and be at least 2 characters long."
                ),
                Email = ReadValidInput("Email", ValidationService.IsValidEmail, "Email must be valid, example of valid email: jasper@domain.com"
                ),
                PhoneNumber = ReadValidInput("PhoneNumber (10 digits)", ValidationService.IsValidPhone, "Phonenumber must be exactly 10 digits and contain only numbers."
                ),
                PostalCode = ReadValidInput("Postalcode (5 digits)", ValidationService.IsValidPostalCode, "Postalcode must be exactly 5 digits and contain only numbers."
                ),
                Address = ReadNonEmptyInput("Street Adress"),
                City = ReadNonEmptyInput("City")
            };
          
            contactService.AddContact(contact);

            Console.WriteLine("Contact was successfully added! Press any key to return to the Main Menu.");
            Console.ReadKey();
        }

        public static void ListOfAllContacts(ContactService contactService)
        {
            Console.Clear();
            Console.WriteLine("List of All Contacts:");

            var contacts = contactService.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts have been added");
            }
            else
            {
                int counter = 1;
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"{counter}. {contact}");
                    counter++;
                }
            }

            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadKey();
        }

        private static string ReadNonEmptyInput(string fieldName)
        {
            while (true)
            {
                Console.Write($"{fieldName}: ");
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }

                Console.WriteLine($"{fieldName} can't be empty");
            }
        }

        private static string ReadValidInput(string fieldName, Func<string, bool> validationFunction, string errorMessage)
        {
            while (true)
            {
                Console.Write($"{fieldName}: ");
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && validationFunction(input))
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
