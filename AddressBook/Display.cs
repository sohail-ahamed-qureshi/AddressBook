using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    /// <summary>
    /// Display options for User.
    /// </summary>
    public class Display
    {
        MultipleAddressBook multipleAddressBook = new MultipleAddressBook();
        /// <summary>
        ///Display user options for AddressBook.
        /// </summary>
        public void DisplayChoiceAddressBook()
        {

            Console.WriteLine("Press 1. to Add New Addressbook");
            Console.WriteLine("Press 2. to View All Addressbooks");
            Console.WriteLine("Press 3. to Exit Program");
            int mainInput = Convert.ToInt32(Console.ReadLine());
            while (mainInput > 3 || mainInput < 0)
            {
                Console.WriteLine("invalid input");
                Console.WriteLine("Enter a valid input ");
                mainInput = Convert.ToInt32(Console.ReadLine());
            }
            switch (mainInput)
            {
                case 1:
                    //add new addressBook
                    Console.WriteLine("Add address book: ");
                    Console.WriteLine("Enter name of addressbook: ");
                    string addressBookName = Console.ReadLine();
                    bool result = multipleAddressBook.AddAddressBook(addressBookName);
                    if (!result)
                        DisplayChoiceAddressBook();
                    //multipleAddressBook.DisplayAddressBook();
                    DisplayChoice();
                    Selection(addressBookName);
                    break;
                case 2:
                    //view addressBook
                    addressBookName = multipleAddressBook.ViewAddressBooks();
                    if(addressBookName == null)
                        DisplayChoiceAddressBook();
                    DisplayChoice();
                    Selection(addressBookName);
                    break;
                case 3:
                    //exit the program
                    Console.WriteLine("Exiting you safely...");
                    Console.WriteLine("Thank you.");
                    break;
                default:
                    Console.WriteLine("Invalid option selected, Try agian!!");
                    break;
            }
        }
        /// <summary>
        /// user input display choice for crud operations in contacts
        /// </summary>
        public void DisplayChoice()
        {
                Console.WriteLine();
                Console.WriteLine("press 1 to view Contact list.");
                Console.WriteLine("press 2 to Add new Contact to list.");
                Console.WriteLine("press 3 to Edit Contact in list.");
                Console.WriteLine("press 4 to Delete a Contact from list.");
                Console.WriteLine("press 5 to go back.");
        }
        /// <summary>
        /// switch case statement process for functionality performs crud operations for contacts
        /// </summary>
        /// <param name="addressBookName"> name of the addressbook</param>
        public void Selection(string addressBookName)
        {
            try
            {
                Dictionary<string, List<Contacts>> addressBook = multipleAddressBook.GetAddressBook();
                //validation for input.
                int input = Convert.ToInt32(Console.ReadLine());
                while (input > 7 || input <= 0)
                {
                    Console.WriteLine("invalid input");
                    Console.WriteLine("Enter a valid input ");
                    DisplayChoice();
                    input = Convert.ToInt32(Console.ReadLine());
                }
                ContactView contactView = new ContactView();
                List<Contacts> contacts;
                switch (input)
                {
                    case 1:
                        //display all contact lists
                        if (addressBook.ContainsKey(addressBookName))
                        {
                            contacts =  addressBook[addressBookName];
                            contactView.Listview(contacts);
                        }
                        //Options for user
                        DisplayChoice();
                        Selection(addressBookName);
                        break;
                    case 2:
                        //Add New Contact
                        Contacts newContact = contactView.NewContact();
                        contacts = addressBook[addressBookName];
                        contacts.Add(newContact);
                        contactView.Listview(contacts);
                        //Options for user
                        DisplayChoice();
                        Selection(addressBookName);
                        break;
                    case 3:
                        //Edit a contact from list
                        Console.WriteLine("Edit a Contact");
                        contacts = addressBook[addressBookName];
                        contactView.EditContact(contacts);
                        DisplayChoice();
                        Selection(addressBookName);
                        break;
                    case 4:
                        //delete a contact from list
                        Console.WriteLine("Delete a Contact");
                        contacts = addressBook[addressBookName];
                        contactView.DeleteContact(contacts);
                        DisplayChoice();
                        Selection(addressBookName);
                        break;
                    case 5:
                        //exit from Contacts
                        DisplayChoiceAddressBook();
                        break;
                    default:
                        //invalid selection
                        Console.WriteLine("Invalid input, please try agian!!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
