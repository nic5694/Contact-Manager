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
    /// Interaction logic for EmailInfo.xaml
    /// </summary>
    public partial class EmailInfo : Window
    {
        DataBase db = new DataBase();
        Email email;
        public EmailInfo(int emailId)
        {
            InitializeComponent();
            email = db.GetEmail(emailId);
            string type;

            if(email.Type_Code == 'P')
            {
                type = "Personal";
            } else if (email.Type_Code == 'B')
            {
                type = "Business";
            } else
            {
                type = "Other";
            }


            typeLabel.Content = type;
            emailBox.Text = email.EmailAddress;
            lastUpdatedBox.Content = email.LastUpdated;
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emailBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void Edit_Email(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            emailBox.IsEnabled = true;
            saveBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;
        }

        private void SaveNewEmail(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Visible;
            emailBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
            email.EmailAddress = emailBox.Text;
            //could add validation
            db.UpdateEmailExistingContact(email);
            Close();
        }

        private void DeleteEmail(object sender, RoutedEventArgs e)
        {
            email.EmailAddress = "N/A";
            email.LastUpdated = "N/A";
            db.UpdateEmailExistingContact(email);
            Close();
        }
    }
}
