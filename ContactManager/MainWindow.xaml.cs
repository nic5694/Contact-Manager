﻿using System;
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

        private void ShowAddress(object sender, RoutedEventArgs e)
        {
            AddressInfo addressinfo = new AddressInfo();
            addressinfo.Show();
        }

        private void ShowEmail(object sender, RoutedEventArgs e)
        {
            EmailInfo emailinfo = new EmailInfo();
            emailinfo.Show();
        }

        private void ShowPhone(object sender, RoutedEventArgs e)
        {
            PhoneInfo phoneinfo = new PhoneInfo(); 
            phoneinfo.Show();
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Contact contact = (Contact)lvDataBinding.SelectedItem;
        }
    }
}

