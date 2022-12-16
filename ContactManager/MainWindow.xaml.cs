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
            contacts = db.getAllContacts();

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
            /*Contact contact = new Contact();
            contact = (Contact)lvDataBinding.SelectedItem;
            DetailsWindow details = new DetailsWindow(contact.Id);
            details.Show();*/
        }

        private void Export_Contacts(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to export all contacts to a csv file","Export Contacts",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                DataBase db = new DataBase();
                List<Contact> contacts = db.getAllContacts();

                string csv = "";

                csv += "ID,FirstName,LastName,LastUpdated,Created\n";

                foreach(Contact contact in contacts)
                {
                    csv += contact.Id.ToString() + "," + contact.FirstName + "," + contact.LastName + "," + contact.LastUpdated.ToString() + "," + contact.Created.ToString() + "\n";
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
                    db.desactivateContact(selecteditem.Id);
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
            contacts = db.getAllContacts();

            foreach (Contact contact in contacts)
            {
                if (contact.Active == true)
                {
                    displayedContacts.Add(contact);
                }
            }
            lvDataBinding.ItemsSource = displayedContacts;
        }
    }
}

