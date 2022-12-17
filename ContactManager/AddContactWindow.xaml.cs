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
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        private int emailCount = 0;
        private int phoneCount = 0;
        static List<Email> emails = new List<Email>();
        static List<Phone> phones = new List<Phone>();
        static List<Address> addresses = new List<Address>();

        public AddContactWindow()
        {
            InitializeComponent();
        }

        private void AddContact_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            emailCount = 0;
            emails.Clear();
            this.Hide();
        }

        private void AddContact(object sender, RoutedEventArgs e)
        {

            if(FirstNameBox.Text == "" || LastNameBox.Text == "")
            {
                MessageBox.Show("The first name or the last name is missing !","Info Missing",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            DataBase db = new DataBase();
     
            String FirstName = FirstNameBox.Text;
            var birthday = calender1.SelectedDate;
            String lastname = LastNameBox.Text;
            String title = TitleBox.Text;

            Contact contact = new Contact();

            contact.FirstName = FirstName;
            contact.Title = title;
            contact.LastName = lastname;
            contact.Birthday = (DateTime)birthday;
            

            db.AddNewContact(contact);

            FirstNameBox.Clear();
            LastNameBox.Clear();
            TitleBox.Clear();
            calender1.SelectedDate = DateTime.Now;
            emails.Clear();
            emailCount = 0;

        }

        private void clearFields(object sender, RoutedEventArgs e)
        {
            FirstNameBox.Clear();
            LastNameBox.Clear();
            TitleBox.Clear();
            calender1.SelectedDate = DateTime.Now;
            emailCount = 0;
            emails.Clear();
        }

        private void newEmailWindow(object sender, RoutedEventArgs e)
        {
            emailCount++;
            if(emailCount < 4)
            {
                NewEmail newEmail = new NewEmail(emailCount);
                newEmail.Show();

            } else
            {
                MessageBox.Show("3 E-mails is the max !");
            }
            
        }

        public void addEmailToList(object e)
        {
            Email contactEmail = e as Email;
            emails.Add(contactEmail);
        }

        private void newPhoneWindow(object sender, RoutedEventArgs e)
        {
            phoneCount++;
            if (phoneCount < 4)
            {
                NewPhone newPhone = new NewPhone(phoneCount);
                newPhone.Show();

            }
            else
            {
                MessageBox.Show("3 Phone Numbers is the max !");
            }
        }

        public void addPhoneToList(object p)
        {
            Phone phone = p as Phone;
            phones.Add(phone);
        }


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
    }
}
