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
    /// Interaction logic for PhoneInfo.xaml
    /// </summary>
    public partial class PhoneInfo : Window
    {
        DataBase db = new DataBase();
        Phone phone;
        public PhoneInfo(int phoneId)
        {
            InitializeComponent();
            phone = db.GetPhone(phoneId);

            string type;

            if (phone.Type_Code == 'P')
            {
                type = "Personal";
            }
            else if (phone.Type_Code == 'B')
            {
                type = "Business";
            }
            else
            {
                type = "Other";
            }

            typeLabel.Content = type;

            countryCodeBox.Text = phone.CountryCode;
            phoneBox.Text = phone.PhoneNumber;
                
        }

        private void Edit_Phone(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;
            phoneBox.IsEnabled = true;
            countryCodeBox.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
            phoneBox.IsEnabled = false;
            countryCodeBox.IsEnabled = false;
        }

        private void DeletePhone(object sender, RoutedEventArgs e)
        {

            db.DeletePhone(phone);
            Close();
        }

        private void SaveNewPhone(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Hidden;
            phoneBox.IsEnabled = false;
            editBtn.Visibility = Visibility.Visible;
            countryCodeBox.IsEnabled = false;
            phone.PhoneNumber = phoneBox.Text;
            phone.CountryCode = countryCodeBox.Text;
            db.AddPhoneToExistingContact(phone);
            Close();
        }
    }
}
