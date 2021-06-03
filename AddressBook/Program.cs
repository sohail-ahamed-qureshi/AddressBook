using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {/// <summary>
    /// Address book program - UC2 able to Add new contact to addressbook
    /// storing name address phone number email
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
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
            List<Contacts> contactsList = new List<Contacts>();
            contactsList.Add(Person1);
            contactsList.Add(Person2);
            //display Contacts stored in List
            foreach (Contacts i in contactsList)
            {
                Console.WriteLine();
                Console.WriteLine("Full name is :{0} {1} ", i.FirstName, i.LastName);
                Console.WriteLine("Address is :{0}, {1}, {2} {3}", i.Address,i.City,i.State,i.ZipCode);
                Console.WriteLine("Phone Number :{0}", i.PhoneNumber);
                Console.WriteLine("Email :{0}", i.Email);
               
            }
        }
    }
}
