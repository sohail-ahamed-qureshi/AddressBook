using System;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// Address book program - UC6 able to Add multiple addressbook with unique name for addressBook
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Display display = new Display();
            display.DisplayChoiceAddressBook();
        }
    }
}
