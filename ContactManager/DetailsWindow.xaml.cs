﻿using ContactManager.DB;
using ContactManager.DB.Entities;
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
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        Contact contact;
        public DetailsWindow(int id)
        {
            InitializeComponent();
            DataBase db = new DataBase();
            contact = db.GetContact(id);
            this.DataContext = contact;
        }
        

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            fName.Content = contact.FirstName;
        }
    }
}
