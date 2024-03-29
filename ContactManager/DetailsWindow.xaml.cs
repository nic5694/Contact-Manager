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

            DeleteBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Hidden;
            TitleBox.IsEnabled = false;
            FirstNameBox.IsEnabled = false;
            LastNameBox.IsEnabled = false;
            BirthdayCalender.IsEnabled = false;

            DataBase db = new DataBase();
            contact = db.GetContact(id);
            this.DataContext = contact;
            
            TitleBox.Text = contact.Title;
            FirstNameBox.Text = contact.FirstName;
            LastNameBox.Text = contact.LastName;

            if(contact.Birthday == new DateTime(0001,01,01))
            {
                BirthdayCalender.DisplayDate = DateTime.Now;
            } else
            {
               BirthdayCalender.DisplayDate = contact.Birthday; 
            }
            
            AddressesList.ItemsSource = contact.Addresses;
            EmailsList.ItemsSource = contact.Emails;
            PhonesList.ItemsSource = contact.Phones;
        }

        private void editContactDetails(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Visible;
            saveBtn.Visibility = Visibility.Visible;

            TitleBox.IsEnabled = true;
            FirstNameBox.IsEnabled = true;
            LastNameBox.IsEnabled = true;
            BirthdayCalender.IsEnabled = true;
        }

        private void saveContactDetails(object sender, RoutedEventArgs e)
        { 
            Contact c = new Contact();

            string t = TitleBox.Text;
            string fn = FirstNameBox.Text;
            string ln = LastNameBox.Text;

            DateTime? b ;
            if (BirthdayCalender.SelectedDate.HasValue)
            {
                b = (DateTime)BirthdayCalender.SelectedDate;
                c.Birthday = (DateTime)b;
            }
            List<Address> addresses = new List<Address>();
            List<Phone> phones = new List<Phone>();
            List<Email> emails = new List<Email>();

            foreach(Address a in AddressesList.Items)
            {
                addresses.Add(a);
            }

            foreach (Phone p in PhonesList.Items)
            {
                phones.Add(p);
            }

            foreach (Email em in EmailsList.Items)
            {
                emails.Add(em);
            }

            if (fn == "")
            {
                MessageBox.Show("First  name can not be empty");
            }
            else
            {
                DeleteBtn.Visibility = Visibility.Hidden;
                saveBtn.Visibility = Visibility.Hidden;
                editBtn.Visibility = Visibility.Visible;

                TitleBox.IsEnabled = false;
                FirstNameBox.IsEnabled = false;
                LastNameBox.IsEnabled = false;
                BirthdayCalender.IsEnabled = false;
                
               
                c.Id = contact.Id;
                c.Title = t;
                c.FirstName = fn;
                c.LastName = ln;
                c.Addresses = addresses;
                c.Emails = emails;
                c.Phones = phones;

                DataBase db = new DataBase();
                db.EditExistingContact(c);
            } 

        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            db.DesactivateContact(contact.Id);
            Close();
        }

        private void showEmailInfo(object sender, MouseButtonEventArgs e)
        {
            Email email = EmailsList.SelectedItem as Email;
            EmailInfo emailInfo = new EmailInfo(email.Id);
            emailInfo.Show();
        }

        private void showPhoneInfo(object sender, MouseButtonEventArgs e)
        {
            Phone phone = PhonesList.SelectedItem as Phone;
            PhoneInfo phoneInfo = new PhoneInfo(phone.Id);
            phoneInfo.Show();
        }

        private void showAddressInfo(object sender, MouseButtonEventArgs e)
        {
            Address address = AddressesList.SelectedItem as Address;
            AddressInfo addressInfo = new AddressInfo(address.Id);
            addressInfo.Show();
        }
        private void updateFields(object sender, RoutedEventArgs e)
        {
            DataBase data = new DataBase();
            contact = data.GetContact(contact.Id);
            TitleBox.Text = contact.Title;
            FirstNameBox.Text = contact.FirstName;
            LastNameBox.Text = contact.LastName;
            BirthdayCalender.DisplayDate = contact.Birthday;
            AddressesList.ItemsSource = contact.Addresses;
            EmailsList.ItemsSource = contact.Emails;
            PhonesList.ItemsSource = contact.Phones;
        }
    }
}
