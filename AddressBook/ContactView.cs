using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class ContactView
    {
       private List<Contacts> contactsList = new List<Contacts>();
        public void ContactViewMethod()
        {
            Contacts Person1 = new Contacts
            {
                FirstName = "John",
                LastName = "Ben",
                Address = "Noida",
                City = "Ghazipur",
                State = "Delhi",
                ZipCode = 110096,
                PhoneNumber = 1234567890,
                Email = "John123@mail.com"
            };
            Contacts Person2 = new Contacts
            {
                FirstName = "Joseph",
                LastName = "Joe",
                Address = "Juhu",
                City = "Mumbai",
                State = "Maharastra",
                ZipCode = 400049,
                PhoneNumber = 1234567890,
                Email = "123Joe@mail.com"
            };
            Person1.ValidateContactDetails();
            Person2.ValidateContactDetails();

            //storing contact details to List
         
            contactsList.Add(Person1);
            contactsList.Add(Person2);
        }

        public void Listview()
        {
            try
            {
                foreach (Contacts i in contactsList)
                {
                    Console.WriteLine();
                    Console.WriteLine("Contacts");
                    Console.WriteLine($"Full Name: {i.FirstName} {i.LastName}");
                    Console.WriteLine($"Phone Number: {i.PhoneNumber}");
                    Console.WriteLine($"Email: {i.Email}");
                    Console.WriteLine($"Address: {i.Address}, \n \t{i.City}, {i.State}, {i.ZipCode}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
