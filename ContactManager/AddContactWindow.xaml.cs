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
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public AddContactWindow()
        {
            InitializeComponent();
            calender1.SelectedDate = DateTime.Now;
        }

        private void AddContact_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void AddContact(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            
            String FirstName = FirstNameBox.Text;
            String title = TitleBox.Text;
            String lastname = LastNameBox.Text;
            var birthday = calender1.SelectedDate;

            Contact contact = new Contact();

            contact.FirstName = FirstName;
            contact.Title = title;
            contact.LastName = lastname;
            contact.Birthday = birthday.ToString();

            db.addNewContact(contact);

            FirstNameBox.Clear();
            LastNameBox.Clear();
            TitleBox.Clear();
            calender1.SelectedDate = DateTime.Now;

        }

        private void clearFields(object sender, RoutedEventArgs e)
        {
            FirstNameBox.Clear();
            LastNameBox.Clear();
            TitleBox.Clear();
            calender1.SelectedDate = DateTime.Now;
        }
    }
}
