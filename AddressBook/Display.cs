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
        public void DisplayChoice()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("press 1 to view Contact list.");
                Console.WriteLine("press 2 to Add new Contact to list.");
                Console.WriteLine("press 3 to Edit Contact in list.");
                Console.WriteLine("press 4 to Delete a Contact from list.");
                Console.WriteLine("press 5 to Exit.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Selection()
        {
            try
            {
                //validation for input.
                int input = Convert.ToInt32(Console.ReadLine());
                while (input > 5 || input <= 0)
                {
                    Console.WriteLine("invalid input");
                    Console.WriteLine("Enter a valid input ");
                    DisplayChoice();
                    input = Convert.ToInt32(Console.ReadLine());
                }
                ContactView contactView = new ContactView();
                switch (input)
                {
                    case 1:
                        //display all contact lists
                        contactView.Listview();
                        //Options for user
                        DisplayChoice();
                        Selection();
                        break;
                    case 2:
                        //Add new Contact to list.
                        Console.WriteLine("case 2:");
                        //Add New Contact
                        contactView.NewContact();
                        //display contacts count
                        Console.WriteLine($" Contacts: {ContactView.contactsList.Count}");
                        //display list
                        contactView.Listview();
                        //Options for user
                        DisplayChoice();
                        Selection();
                        break;
                    case 3:
                        //Edit a contact from list
                        Console.WriteLine("Edit a Contact");
                        contactView.EditContact();
                        DisplayChoice();
                        Selection();
                        break;
                    case 4:
                        //delete a contact from list
                        Console.WriteLine("Delete a Contact");
                        contactView.DeleteContact();
                        DisplayChoice();
                        Selection();
                        break;
                    case 5:
                        //exit from program
                        Console.WriteLine("Exiting you safely...");
                        Console.WriteLine("Thank you.");
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
