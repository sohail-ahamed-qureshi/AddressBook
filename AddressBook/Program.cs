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
            //display selection for User.
            Display display = new Display();
            display.DisplayChoice();
            display.Selection();
        }
    }
}
