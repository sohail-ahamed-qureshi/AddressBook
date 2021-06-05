using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {/// <summary>
     /// Address book program - UC5 able to Add multiple persons to addressbook
     /// 
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

            //--------UC5-------------//
            // adding multiple persons to a contact book//
            //first create a temporary list which add multiple persons details
            //then temporary list is added to main contact book.
            //----------UC5----------//


        }
    }
}
