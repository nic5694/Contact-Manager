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
        string name { get; set; }
        int age { get; set; }
        DetailsWindow detailsWindow = new DetailsWindow();
        AddContactWindow addwindow = new AddContactWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddContact(object sender, RoutedEventArgs e)
        {
            addwindow.Show();
        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            Contact c = new Contact();
            c = db.GetContact(1);
            MessageBox.Show(c.FirstName, "Contact");
            MessageBox.Show("Are you sure you want to delete that Contact ?","Delete",MessageBoxButton.YesNo);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            /*
            List<Contact> contacts = new List<Contact>();
            DataBase db = new DataBase();
            contacts = db.getAllContacts();
            lvDataBinding.ItemsSource = contacts;*/
        }
    }
}

