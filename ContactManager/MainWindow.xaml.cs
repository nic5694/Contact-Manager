using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Configuration;
using ContactManager.DB;
using System.Security.Cryptography.X509Certificates;
using ContactManager.DB.Entities;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddContact(object sender, RoutedEventArgs e)
        {
            AddContactWindow addwindow = new AddContactWindow();
            addwindow.Show();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Contact> contacts = new List<Contact>();
            List<Contact> displayedContacts = new List<Contact>();
            DataBase db = new DataBase();
            contacts = db.GetAllContacts();

            foreach (Contact contact in contacts)
            {
                if (contact.Active == true)
                {
                    displayedContacts.Add(contact);
                }
            }
            lvDataBinding.ItemsSource = displayedContacts;

            
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Contact contact = lvDataBinding.SelectedItem as Contact;
            DetailsWindow details = new DetailsWindow(contact.Id);
            details.Show();
        }

        private void Export_Contacts(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to export all contacts to a csv file","Export Contacts",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                DataBase db = new DataBase();
                List<Contact> contacts = db.GetAllContacts();

                string csv = "";

                csv +=
                    "First Name,Last Name,Birthday,Last Updated,Created,Active," +
                    "Type,Email,Type,Email,Type,Email," +
                    "Type,Phone,Type,Phone,Type,Phone," +
                    "Type, Address,Country,Postal code,Type, Address,Country,Postal code,Type, Address,Country,Postal code\n";

                foreach (Contact contact in contacts)
                {
                    string b;
                    if(contact.Birthday == new DateTime(0001, 01, 01))
                    {
                        b = "N/A";
                    } else
                    {
                        b = contact.Birthday.ToString("d");
                    }

                    List<Email> emails = db.getAllEmails(contact.Id);
                    List<Phone> phones = db.getAllPhones(contact.Id);
                    List<Address> addresses = db.getAllAddresses(contact.Id);


                    csv +=
                        contact.FirstName + "," +
                        contact.LastName + "," +
                        b + "," +
                        contact.LastUpdated.ToString() + "," +
                        contact.Created.ToString() + "," +
                        contact.Active.ToString() + "," +

                        emails[0].Type_Code.ToString() + "," +
                        emails[0].EmailAddress.ToString() + "," +
                        emails[1].Type_Code.ToString() + "," +
                        emails[1].EmailAddress.ToString() + "," +
                        emails[2].Type_Code.ToString() + "," +
                        emails[2].EmailAddress.ToString() + "," +

                        phones[0].Type_Code.ToString() + "," +
                        displayPhoneNumber(phones[0]) + "," +
                        phones[1].Type_Code.ToString() + "," +
                        displayPhoneNumber(phones[1]) + "," +
                        phones[2].Type_Code.ToString() + "," +
                        displayPhoneNumber(phones[2]) + "," +

                        addresses[0].Type_Code.ToString() + "," +
                        displayAddress(addresses[0]) + "," +
                        addresses[0].Country + "," +
                        addresses[0].PostalCode + "," +
                        addresses[1].Type_Code.ToString() + "," +
                        displayAddress(addresses[1]) + "," +
                        addresses[1].Country + "," +
                        addresses[1].PostalCode + "," +
                        addresses[2].Type_Code.ToString() + "," +
                        displayAddress(addresses[2]) + "," +
                        addresses[2].Country + "," +
                        addresses[2].PostalCode
                        + "\n";
                }

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog();

                saveFileDialog.DefaultExt = ".csv";

                if (saveFileDialog.ShowDialog() == true)
                {
                   
                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv);
                }

            }
            else
            {
                return;
            }
            
        }

        private void ResfreshList(object sender, RoutedEventArgs e)
        {
            refreshList();
        }

        private void DesactivateContact(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            Contact selecteditem = lvDataBinding.SelectedItem as Contact;
            if(selecteditem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to desactivate this Contact ?", "",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    db.DesactivateContact(selecteditem.Id);
                    refreshList();

                } else
                {
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("No Contact has been selected", "Selection Not Found",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        public void refreshList()
        {
            List<Contact> contacts = new List<Contact>();
            List<Contact> displayedContacts = new List<Contact>();
            DataBase db = new DataBase();
            contacts = db.GetAllContacts();

            foreach (Contact contact in contacts)
            {
                if (contact.Active == true)
                {
                    displayedContacts.Add(contact);
                }
            }

            lvDataBinding.ItemsSource = displayedContacts;
        }

        public string displayPhoneNumber(object obj)
        {
            Phone p = obj as Phone;

            if (p.CountryCode == "N/A" && p.PhoneNumber == "N/A")
            {
                return "N/A";

            } else
            {
                return "(+"+p.CountryCode+ ")" + p.PhoneNumber;
            }
        }

        public string displayAddress(object obj)
        {
            Address a = obj as Address;

            if(a.StreetAddress == "N/A")
            {
                return "N/A";
            } else
            {
                return a.ApartmentNumber.ToString() + " rue " + a.StreetAddress + " " + a.City + " " + a.Province ;
            }
        }

    }
}

