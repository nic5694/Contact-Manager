using ContactManager.DB;
using ContactManager.DB.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        static List<Email> emails = new List<Email>();
        static List<Phone> phones = new List<Phone>();
        static List<Address> addresses = new List<Address>();

        public AddContactWindow()
        {
            InitializeComponent();
        }

        public void AddContact_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            emails.Clear();
            phones.Clear();
            addresses.Clear();
            this.Hide();
        }

        public void AddContact(object sender, RoutedEventArgs e)
        {

            if(FirstNameBox.Text == "")
            {
                MessageBox.Show("The first name is missing !","Info Missing",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            DataBase db = new DataBase(); 
            Contact contact = new Contact();
     
            string FirstName = FirstNameBox.Text;
            var birthday = calender1.SelectedDate;
            if(birthday != null)
            {
                birthday = calender1.SelectedDate;
                contact.Birthday = (DateTime)birthday;
            }
            string lastname = LastNameBox.Text;
            string title = TitleBox.Text;

            contact.FirstName = FirstName;
            contact.Title = title;
            contact.LastName = lastname;

            char[] types = { 'P', 'B', 'O' };
            string empty = "N/A";
            
            // add empty object where info is missing 
            if(emails.Count == 0)
            {
                for(int i = 0; i < types.Length; i++)
                {
                    Email email = new Email();
                    email.EmailAddress = empty;
                    email.Type_Code = types[i];
                    emails.Add(email);
                }
                
            }
            else if (emails.Count == 1)
            {
                
                for (int i = 0; i < types.Length; i++)
                {

                    if (emails[0].Type_Code != types[i])
                    {
                        Email em = new Email();
                        em.EmailAddress = empty;
                        em.Type_Code = types[i];
                        emails.Add(em);
                        break;
                    }
                }

                for (int i = 0; i < types.Length; i++)
                {

                    if (emails[0].Type_Code != types[i] && emails[1].Type_Code != types[i])
                    {
                        Email em = new Email();
                        em.EmailAddress = empty;
                        em.Type_Code = types[i];
                        emails.Add(em);
                    }
                }

            }
            else if(emails.Count == 2)
            {
                
                for (int i = 0; i < types.Length; i++)
                {

                    if (emails[0].Type_Code != types[i] && emails[1].Type_Code != types[i])
                    {
                        Email em = new Email();
                        em.EmailAddress = empty;
                        em.Type_Code = types[i];
                        emails.Add(em);
                    }
                }
                
            }

            if (phones.Count == 0)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    Phone phone = new Phone();
                    phone.PhoneNumber = empty;
                    phone.Type_Code = types[i];
                    phone.CountryCode = empty;
                    phones.Add(phone);
                }

            }
            else if (phones.Count == 1)
            {

                for (int i = 0; i < types.Length; i++)
                {

                    if (phones[0].Type_Code != types[i])
                    {
                        Phone phone = new Phone();
                        phone.PhoneNumber = empty;
                        phone.Type_Code = types[i];
                        phone.CountryCode = empty;
                        phones.Add(phone);
                        break;
                    }
                }

                for (int i = 0; i < types.Length; i++)
                {

                    if (phones[0].Type_Code != types[i] && phones[1].Type_Code != types[i])
                    {
                        Phone phone = new Phone();
                        phone.PhoneNumber = empty;
                        phone.Type_Code = types[i];
                        phone.CountryCode = empty;
                        phones.Add(phone);
                    }
                }

            }
            else if (phones.Count == 2)
            {

                for (int i = 0; i < types.Length; i++)
                {

                    if (phones[0].Type_Code != types[i] && phones[1].Type_Code != types[i])
                    {
                        Phone phone = new Phone();
                        phone.PhoneNumber = empty;
                        phone.Type_Code = types[i];
                        phone.CountryCode = empty;
                        phones.Add(phone);
                    }
                }

            }

            if (addresses.Count == 0)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    Address address = new Address();
                    address.Type_Code = types[i];
                    address.StreetAddress = empty;
                    address.City = empty;
                    address.Country = empty;
                    address.Province = empty;
                    address.PostalCode = empty;

                    addresses.Add(address);
                }

            }
            else if (addresses.Count == 1)
            {

                for (int i = 0; i < types.Length; i++)
                {

                    if (addresses[0].Type_Code != types[i])
                    {
                        Address address = new Address();
                        address.Type_Code = types[i];
                        address.StreetAddress = empty;
                        address.City = empty;
                        address.Country = empty;
                        address.Province = empty;
                        address.PostalCode = empty;

                        addresses.Add(address);
                        break;
                    }
                }

                for (int i = 0; i < types.Length; i++)
                {

                    if (addresses[0].Type_Code != types[i] && addresses[1].Type_Code != types[i])
                    {
                        Address address = new Address();
                        address.Type_Code = types[i];
                        address.StreetAddress = empty;
                        address.City = empty;
                        address.Country = empty;
                        address.Province = empty;
                        address.PostalCode = empty;

                        addresses.Add(address);
                    }
                }

            }
            else if (addresses.Count == 2)
            {

                for (int i = 0; i < types.Length; i++)
                {

                    if (addresses[0].Type_Code != types[i] && addresses[1].Type_Code != types[i])
                    {
                        Address address = new Address();
                        address.Type_Code = types[i];
                        address.StreetAddress = empty;
                        address.City = empty;
                        address.Country = empty;
                        address.Province = empty;
                        address.PostalCode = empty;

                        addresses.Add(address);
                    }
                }

            }

            contact.Addresses = addresses;
            contact.Emails = emails;
            contact.Phones = phones;
            

            db.AddNewContact(contact);

            FirstNameBox.Clear();
            LastNameBox.Clear();
            TitleBox.Clear();
            calender1.SelectedDate = DateTime.Now;
            emails.Clear();
            phones.Clear();
            addresses.Clear();
            Close();

        }

        public void clearFields(object sender, RoutedEventArgs e)
        {
            FirstNameBox.Clear();
            LastNameBox.Clear();
            TitleBox.Clear();
            calender1.SelectedDate = DateTime.Now;
            emails.Clear();
            phones.Clear();
            addresses.Clear();
        }


        // Email section
        public void newEmailWindow(object sender, RoutedEventArgs e)
        {
            
            NewEmail newEmail = new NewEmail();
            newEmail.Show();
            
        }

        public void addEmailToList(object e)
        {
            Email contactEmail = e as Email;
            emails.Add(contactEmail);
        }

        public bool emailTypeExistAlready(char type)
        {

            if (emails == null)
            {
                return false;
            }
            else
            {
                foreach (Email email in emails)
                {
                    if (email.Type_Code.ToString().ToCharArray()[0] == type)
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        // Phone Section
        public void newPhoneWindow(object sender, RoutedEventArgs e)
        {
            
                NewPhone newPhone = new NewPhone();
                newPhone.Show();

        }

        public void addPhoneToList(object p)
        {
            Phone phone = p as Phone;
            phones.Add(phone);
        }

        public bool phoneTypeExistAlready(char type)
        {
            if (phones == null)
            {
                return false;
            }
            else
            {
                foreach (Phone phone in phones)
                {
                    if (phone.Type_Code.ToString().ToCharArray()[0] == type)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        
        // Address Section
        private void newAddressWindow(object sender, RoutedEventArgs e)
        {
                NewAddress newAddress = new NewAddress();
                newAddress.Show();
        }

        public void addAddressToList(object a)
        {
            Address address = a as Address;
            addresses.Add(address);
        }

        public bool addressTypeExistAlready(char type)
        {
            if (addresses == null)
            {
                return false;
            }
            else
            {
                foreach (Address address in addresses)
                {
                    if (address.Type_Code.ToString().ToCharArray()[0] == type)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /*
        private void showPhones(object sender, RoutedEventArgs e)
        {
            foreach(Phone phone in phones)
            {
                MessageBox.Show(phone.Type_Code.ToString() + " : " + phone.CountryCode + phone.PhoneNumber);
            }
        }

        private void showEmails(object sender, RoutedEventArgs e)
        {
            foreach (Email email in emails)
            {
                MessageBox.Show(email.Type_Code.ToString() + " : " + email.EmailAddress);
            }
        }

        private void showAddresses(object sender, RoutedEventArgs e)
        {
            foreach (Address address in addresses)
            {
                MessageBox.Show(address.Type_Code.ToString() + " : " + address.ApartmentNumber + " " + address.StreetAddress + " " + address.Province);
            }
        }
        */

    }
}
