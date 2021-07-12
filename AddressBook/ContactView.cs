using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using static AddressBook.Contacts;

namespace AddressBook
{
    interface IOperationalMethods
    {
        public void Listview(List<Contacts> contactsList);
        public Contacts NewContact(List<Contacts> contactsList);
        public void DeleteContact(List<Contacts> contactsList);
        public void EditContact(List<Contacts> contactsList);
    }
    class ContactView : IOperationalMethods
    {
        public Contacts Person3 = new Contacts();
        /// <summary>
        /// Display Contact details template.
        /// </summary>
        public void Listview(List<Contacts> contactsList)
        {
            try
            {
                if (contactsList.Count == 0)
                    Console.WriteLine("No Contacts to Display");
                else
                {
                    foreach (Contacts i in contactsList)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Contacts");
                        Console.WriteLine($"Full Name: {i.FirstName} {i.LastName}");
                        Console.WriteLine($"Phone Number: {i.PhoneNumber}");
                        Console.WriteLine($"Email: {i.Email}");
                        Console.WriteLine($"Address: {i.Address}, \n \t{i.City}, {i.State}, {i.ZipCode}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// New contact method - ask user to enter all details. using console
        /// </summary>
        public Contacts NewContact(List<Contacts> contactsList)
        {
            try
            {
                //global object 'Person3' is used.//
                CustomInput(Person3, contactsList);
                //validating contact details
                Person3.ValidateContactDetails();
                //adding contact to list
                //contactsList.Add(Person3);
                return Person3;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("New contact entry aborted.");
            }
            return null;
        }

        /// <summary>
        /// delete a contact method using an index of list entered by user.
        /// check for contacts available in list
        /// if no contacts display message and end.
        /// else ask for delete using index of list.
        /// </summary>
        public void DeleteContact(List<Contacts> contactsList)
        {
            try
            {
                if (contactsList.Count == 0)
                {
                    Console.WriteLine("No Contacts available to Delete");
                }
                else
                {
                    int i = 0;
                    Console.WriteLine("Select the contact you want to Delete : ");
                    foreach (Contacts contacts in contactsList)
                    {
                        Console.WriteLine($" press {i} for {contacts.FirstName}");
                        i++;
                    }
                    int sel = Convert.ToInt32(Console.ReadLine());
                    while (sel >= i || sel < 0)
                    {
                        Console.WriteLine("invalid choice made,");
                        Console.WriteLine("enter a valid choice");
                        sel = Convert.ToInt32(Console.ReadLine());
                    }
                    contactsList.RemoveAt(sel);
                    Console.WriteLine("Contact deleted successfully!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// edit a contact using a index ask ask for details and replace
        /// the details with appropriate details.
        /// </summary>
        public void EditContact(List<Contacts> contactsList)
        {
            try
            {
                if (contactsList.Count == 0)
                {
                    Console.WriteLine("No Contacts available to Edit");
                }
                else
                {
                    int i = 0;
                    Console.WriteLine("Select the contact you want to Edit : ");
                    foreach (Contacts contacts in contactsList)
                    {

                        Console.WriteLine($" press {i} for {contacts.FirstName}");
                        i++;
                    }
                    int sel = Convert.ToInt32(Console.ReadLine());
                    while (sel >= i || sel < 0)
                    {
                        Console.WriteLine("invalid choice made,");
                        Console.WriteLine("enter a valid choice");
                        sel = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("-------Before editing-------");
                    CustomView(sel, contactsList);
                    //recording the name to be updated in database
                    string name = contactsList[sel].FirstName;
                    Console.WriteLine("Enter new Details");
                    //global object 'Person3' is used.//
                    CustomInput(Person3, contactsList);
                    //validating contact details
                    Person3.ValidateContactDetails();
                    //removing contact
                    contactsList.RemoveAt(sel);
                    //adding new details of contact at list
                    contactsList.Insert(sel, Person3);
                    //passing name and the contact to be updated
                    EditContactDatabase(name, Person3);
                    Console.WriteLine();
                    Console.WriteLine("Contact edit successful!!");
                    Console.WriteLine("-------After editing-------");
                    CustomView(sel, contactsList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// ability to update contact in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contact"></param>
        private void EditContactDatabase(string name, Contacts contact)
        {
            string connectionString = @"Data Source=s;Initial Catalog=AddressBookDatabase;Integrated Security=True;Pooling=False";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpUpdateContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@firstName", contact.FirstName);
                    command.Parameters.AddWithValue("@lastName", contact.LastName);
                    command.Parameters.AddWithValue("@address", contact.Address);
                    command.Parameters.AddWithValue("@city", contact.City);
                    command.Parameters.AddWithValue("@state", contact.State);
                    command.Parameters.AddWithValue("@zip", contact.ZipCode);
                    command.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@email", contact.Email);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    string outputMessage = result == 1 ? "Contact Updaeted SuccessFully" : "Contact Update failed";
                    Console.WriteLine(outputMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// custom display template for edit contact 
        /// sel- is parameter that passes appropriate selected contact index.
        /// </summary>
        /// <param name="sel"></param>
        private void CustomView(int sel, List<Contacts> contactsList)
        {
            Console.WriteLine();
            Console.WriteLine("Contacts");
            Console.WriteLine($"Full Name: {contactsList[sel].FirstName} {contactsList[sel].LastName}");
            Console.WriteLine($"Phone Number: {contactsList[sel].PhoneNumber}");
            Console.WriteLine($"Email: {contactsList[sel].Email}");
            Console.WriteLine($"Address: {contactsList[sel].Address}, \n \t{contactsList[sel].City}, {contactsList[sel].State}, {contactsList[sel].ZipCode}");
            Console.WriteLine();
        }

        public void CustomInput(Contacts Person, List<Contacts> contactsList)
        {
            Console.WriteLine("Add a new contact.");
            Console.WriteLine("Enter First Name: ");
            Person.FirstName = Console.ReadLine();
            //ability to check for duplicate entry of same person in particular addressBook
            foreach (Contacts contacts in contactsList)
            {
                while (contacts.FirstName.Contains(Person.FirstName))
                {
                    Console.WriteLine("Name already exists in Contacts \n enter new name: ");
                    Person.FirstName = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Last Name: ");
            Person.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            Person.Address = Console.ReadLine();
            Console.WriteLine("Enter City: ");
            Person.City = Console.ReadLine();
            Console.WriteLine("Enter State: ");
            Person.State = Console.ReadLine();
            Console.WriteLine("Enter ZipCode: ");
            var input = Console.ReadLine();
            while (true)
            {
                if (Int32.TryParse(input, out _))
                {
                    Person.ZipCode = Convert.ToInt32(input);
                    break;
                }
                else
                {
                    Console.WriteLine("invalid Input!! try again.");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Phone Number: ");
            input = Console.ReadLine();
            while (true)
            {
                if (Int64.TryParse(input, out _))
                {
                    Person.PhoneNumber = Convert.ToInt64(input);
                    break;
                }
                else
                {
                    Console.WriteLine("invalid Input!! try again.");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Email: ");
            Person.Email = Console.ReadLine();
        }
        /// <summary>
        /// ability to import contacts from a csv file
        /// </summary>
        /// <param name="addressBookName"></param>
        /// <param name="addressBook"></param>
        public void ImportContacts(string addressBookName, Dictionary<string, List<Contacts>> addressBook)
        {
            List<Contacts> contactsList = addressBook[addressBookName];
            string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\AddressBook\AddressBook\AddressBook\ContactsCSVFile.csv";
            if (filepath.EndsWith(".csv") && File.Exists(filepath))
            {
                string[] contactsArray = File.ReadAllLines(filepath);
                for (int i = 1; i < contactsArray.Length; i++)
                {
                    Contacts contact = new Contacts();
                    string[] data = contactsArray[i].Split(',');
                    contact.FirstName = data[0];
                    contact.LastName = data[1];
                    contact.Address = data[2];
                    contact.City = data[3];
                    contact.State = data[4];
                    contact.ZipCode = Convert.ToInt32(data[5]);
                    contact.PhoneNumber = Convert.ToInt64(data[6]);
                    contact.Email = data[7];
                    contact.ValidateContactDetails();
                    contactsList.Add(contact);
                }
                addressBook[addressBookName] = contactsList;
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }
        /// <summary>
        /// ability to Export contacts to a csv file
        /// </summary>
        /// <param name="contactsList"></param>
        public void ExportContacts(List<Contacts> contactsList)
        {
            string[] contactArray = new string[contactsList.Count];
            string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\AddressBook\AddressBook\AddressBook\ContactsCSVFile.csv";
            if (filepath.EndsWith(".csv") && File.Exists(filepath))
            {
                for (int i = 0; i < contactsList.Count; i++)
                {
                    Contacts contact = contactsList[i];
                    contactArray[i] = contact.FirstName + ',' + contact.LastName + ',' + contact.Address + ',' + contact.City + ',' + contact.State + ',' + Convert.ToString(contact.ZipCode) + ',' + Convert.ToString(contact.PhoneNumber) + ',' + contact.Email;
                }

                File.WriteAllLines(filepath, contactArray, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("File not found");
            }

        }

        /// <summary>
        /// ability to read contacts list from json file
        /// </summary>
        /// <param name="contactlist"></param>
        public void GetJsonData(List<Contacts> contactlist)
        {
            string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\AddressBook\AddressBook\AddressBook\json1.json";
            string jObject = File.ReadAllText(filepath);
            Root root = JsonConvert.DeserializeObject<Root>(jObject);
            contactlist.AddRange(root.contacts);
            Console.WriteLine("Import successfull");
        }
        /// <summary>
        /// ability to write contacts list to json file
        /// </summary>
        /// <param name="contactlist"></param>
        public void SetJsonData(List<Contacts> contactlist)
        {
            string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\AddressBook\AddressBook\AddressBook\json1.json";
            Contacts contact = NewContact(contactlist);
            contactlist.Add(contact);
            Root root = new Root
            {
                contacts = contactlist
            };
            string contactdata = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(filepath, contactdata);
            Console.WriteLine("Emport successfull");
        }
        /// <summary>
        /// ability to retireve contacts from database
        /// </summary>
        /// <param name="contactList"></param>
        public void GetContactsFromDataBase(List<Contacts> contactList)
        {
            string connectionString = @"Data Source=s;Initial Catalog=AddressBookDatabase;Integrated Security=True;Pooling=False";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpRetrieveContacts";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Contacts contact = new Contacts
                        {
                            FirstName = dr.GetString(0),
                            LastName = dr.GetString(1),
                            Address = dr.GetString(2),
                            City = dr.GetString(3),
                            State = dr.GetString(4),
                            ZipCode = dr.GetInt32(5),
                            PhoneNumber = dr.GetInt64(6),
                            Email = dr.GetString(7)
                        };
                        contactList.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// ability to get count by city from database
        /// </summary>
        public void GetCountByCity()
        {
            string connectionString = @"Data Source=s;Initial Catalog=AddressBookDatabase;Integrated Security=True;Pooling=False";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpGetCountByCity";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    int count = 0; string city;
                    while (dr.Read())
                    {
                        count = dr.GetInt32(0);
                        city = dr.GetString(1);
                        Console.WriteLine($"City: {city}, No of Contacts: {count}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// ability to view contacts that were added to database at particular period
        /// </summary>
        /// <param name="date"></param>
        public void GetContactsFromDataBase(string date)
        {
            string connectionString = @"Data Source=s;Initial Catalog=AddressBookDatabase;Integrated Security=True;Pooling=False";
            SqlConnection connection = new SqlConnection(connectionString);
            List<Contacts> contactList = new List<Contacts>();
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpGetContactByDate";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@date", date);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Contacts contact = new Contacts
                        {
                            FirstName = dr.GetString(0),
                            LastName = dr.GetString(1),
                            Address = dr.GetString(2),
                            City = dr.GetString(3),
                            State = dr.GetString(4),
                            ZipCode = dr.GetInt32(5),
                            PhoneNumber = dr.GetInt64(6),
                            Email = dr.GetString(7)
                        };
                        contactList.Add(contact);
                    }
                    Console.WriteLine($"Contacts added within {date}: ");
                    Console.WriteLine();
                    if(contactList.Count == 0)
                    {
                        Console.WriteLine("no records found");
                    }
                    if (contactList.Count >= 1)
                    {
                        Console.WriteLine($"{contactList.Count} records found");
                        Listview(contactList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
