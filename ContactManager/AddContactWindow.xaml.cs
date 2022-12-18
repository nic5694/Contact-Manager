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
     
            String FirstName = FirstNameBox.Text;
            var birthday = calender1.SelectedDate;
            if(birthday != null)
            {
                birthday = calender1.SelectedDate;
                contact.Birthday = (DateTime)birthday;
            }
            String lastname = LastNameBox.Text;
            String title = TitleBox.Text;

            contact.FirstName = FirstName;
            contact.Title = title;
            contact.LastName = lastname;
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
