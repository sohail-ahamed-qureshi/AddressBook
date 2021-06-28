using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    /// <summary>
    /// Create multiple addressbooks
    /// </summary>
    class MultipleAddressBook
    {
        Dictionary<string, ContactView> dtAddressbook = new Dictionary<string, ContactView>();

        public MultipleAddressBook()
        {
            dtAddressbook = new Dictionary<string, ContactView>();
        }

        /// <summary>
        /// create a new address book check for name,
        /// if already exists then, wont create new.
        /// </summary>
        /// <param name="name"></param>
        public void AddAddressBook(string name)
        {
            //check for addressbook name
            if (dtAddressbook.ContainsKey(name))
            {
                Console.WriteLine("Name already exists!!");
            }
            else
            {
                ContactView contactView = new ContactView();
                dtAddressbook.Add(name, contactView);
                Console.WriteLine("address book created successfully....");
            } 
        }

        /// <summary>
        /// view all addressbooks present.
        /// </summary>
        public void ViewAddressBooks()
        {
            if(dtAddressbook.Count == 0)
            {
                Console.WriteLine("No AddressBook(s) to Show.");
            }
            if(dtAddressbook.Count >= 1)
            {
                foreach (var item in dtAddressbook.Keys)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public ContactView GetAddressBook(string name)
        {
                return dtAddressbook[name];
        }
        /// <summary>
        /// view the contacts present in addressbook
        /// </summary>
        public void DisplayAddressBook()
        {
            foreach (KeyValuePair<string, ContactView> item in dtAddressbook)
            {
                Console.WriteLine("AddressBook:  "+item.Key );
                ContactView contactView = item.Value;
                contactView.Listview();
            }
        }
    }
}
