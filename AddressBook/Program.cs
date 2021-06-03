using System;

namespace AddressBook
{
    class Program
    {/// <summary>
    /// Address book program - UC1 creating contact in addressbook
    /// storing name address phone number email
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Contacts contacts = new Contacts
            {
                FirstName = "Sohail",
                LastName = "Ahamed",
                Address = "SR nagar",
                City = "Hospet",
                State = "Karnataka",
                ZipCode = 583201,
                PhoneNumber = 1234567890,
                Email = "sohailqureshi82@gmail.com"
            };
            contacts.ValidateContactDetails();
            Console.WriteLine("Contact Details: ");
            Console.WriteLine($"Full Name: {contacts.FirstName + contacts.LastName} ");
            Console.WriteLine($"Phone Number: {contacts.PhoneNumber} ");
            Console.WriteLine($"Address: {contacts.Address} \n \t{contacts.City} {contacts.State} \n \t{contacts.ZipCode} ");
            Console.WriteLine($"Email: {contacts.Email} ");

        }
    }
}
