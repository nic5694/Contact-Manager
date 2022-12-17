using ContactManager.DB;
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
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            contact = db.GetContact(contact.Id);
            this.DataContext = contact;

            TitleBox.Text = contact.Title;
            FirstNameBox.Text = contact.FirstName;
            LastNameBox.Text = contact.LastName;
            BirthdayCalender.DataContext = contact.Birthday;

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
            DeleteBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Hidden;
            editBtn.Visibility = Visibility.Visible;

            TitleBox.IsEnabled = false;
            FirstNameBox.IsEnabled = false;
            LastNameBox.IsEnabled = false;
            BirthdayCalender.IsEnabled = false;

            DataBase db = new DataBase();
            db.EditExistingContact(contact);

        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            db.DesactivateContact(contact.Id);
            Close();
        }

    }
}
