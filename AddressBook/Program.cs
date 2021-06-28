﻿using System;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// Address book program - UC5 able to Add multiple persons to addressbook
        /// using temporary list to add multiple persons and adding back list to main contactlist.
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
