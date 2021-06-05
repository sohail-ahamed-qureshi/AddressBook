using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{/// <summary>
 /// OOP's concepts for saving user details
 /// using Encapsulation, properties, Interface, Exceptions
 /// getting contacts from user 
 /// </summary>
    interface IContactDetails
    {
        void ValidateContactDetails();
    }
    class Contacts : IContactDetails
    {
        //variables
        readonly private string firstName;
        readonly private string lastName;
        readonly private string address;
        readonly private string city;
        readonly private string state;
        readonly private int zipCode;
        readonly private long phoneNumber;
        readonly private string email;

        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        private bool ValidateFullName(string firstName, string lastName)
        {
            try
            {
                if (firstName != " " && lastName != " ")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Full Name");
            }
            return false;
        }

        private bool ValidateAddress(string address, string city, string state, int zipCode)
        {
            try
            {
                if (address != " " && city != " " && state != " " && zipCode != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Address");
            }
            return false;
        }
        private bool ValidateContactNumbers(long phoneNumber, string email)
        {
            try
            {
                if (phoneNumber != 0 && email != " ")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Contact Numbers");
            }
            return false;
        }
        public void ValidateContactDetails()
        {
            try
            {
                bool full_Name = ValidateFullName(FirstName, LastName);
                bool addr = ValidateAddress(Address, City, State, ZipCode);
                bool contact = ValidateContactNumbers(PhoneNumber, Email);
                if (full_Name == true && addr == true && contact == true)
                    Console.WriteLine("Contact Details Saved Successfully");
                else
                    Console.WriteLine("Contact Save Failed!!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Saving Details");
            }
        }
    }
}
