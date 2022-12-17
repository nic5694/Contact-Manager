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
        Email e;
        public EmailInfo(int emailId)
        {
            InitializeComponent();
            e = db.getEmail(emailId);
            string type;

            if(e.Type_Code == 'P')
            {
                type = "Personal";
            } else if (e.Type_Code == 'B')
            {
                type = "Business";
            } else
            {
                type = "Other";
            }


            typeLabel.Content = type;
            emailBox.Text = e.EmailAddress;
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
        }

        private void Edit_Email(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            emailBox.IsEnabled = true;
            saveBtn.Visibility = Visibility.Visible;
        }

        private void Save_Email(object sender, RoutedEventArgs e)
        {
            //update contact email
            editBtn.Visibility = Visibility.Visible;
            emailBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
        }
    }
}
