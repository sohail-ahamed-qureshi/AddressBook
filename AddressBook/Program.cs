using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {/// <summary>
     /// Address book program - UC3 able to delete a contact from addressbook
     /// deleting contact using index of list
     /// </summary>
     /// <param name="args"></param>

        static void Main(string[] args)
        {
            ContactView contactView = new ContactView();
            //hard coded contacts initializing.
            contactView.ContactViewMethod();
            //display selection for User.
            Display display = new Display();
            display.DisplayChoice();
            display.Selection();
        }
    }
}
