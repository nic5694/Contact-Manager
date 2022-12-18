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
    /// Interaction logic for AddressInfo.xaml
    /// </summary>
    public partial class AddressInfo : Window
    {
        DataBase db = new DataBase();
        Address address;
        
        public AddressInfo(int addressId)
        {
            InitializeComponent();
            address = db.GetAddress(addressId);

            string type;

            if (address.Type_Code == 'P')
            {
                type = "Personal";
            }
            else if (address.Type_Code == 'B')
            {
                type = "Business";
            }
            else
            {
                type = "Other";
            }

            typeLabel.Content = type;
            appNumberBox.Text = address.ApartmentNumber.ToString();
            addressBox.Text = address.StreetAddress.ToString();
            cityBox.Text = address.City.ToString();
            provinceBox.Text = address.Province.ToString();
            countryBox.Text = address.Country.ToString();
            postalCodeBox.Text = address.PostalCode.ToString();

        }

        private void AddressWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            appNumberBox.IsEnabled = false;
            addressBox.IsEnabled = false;
            cityBox.IsEnabled = false;
            provinceBox.IsEnabled = false;
            countryBox.IsEnabled = false;
            postalCodeBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void Edit_Address(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            appNumberBox.IsEnabled = true;
            addressBox.IsEnabled = true;
            cityBox.IsEnabled = true;
            provinceBox.IsEnabled = true;
            countryBox.IsEnabled = true;
            postalCodeBox.IsEnabled = true;
            saveBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;
        }

        private void DeleteAddress(object sender, RoutedEventArgs e)
        {
            db.DeleteAddress(address);
            Close();
        }

        private void SaveNewAddress(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Visible;
            appNumberBox.IsEnabled = false;
            addressBox.IsEnabled = false;
            cityBox.IsEnabled = false;
            provinceBox.IsEnabled = false;
            countryBox.IsEnabled = false;
            postalCodeBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
            //address.ApartmentNumber = appNumberBox.Text;
            int num;
            if(int.TryParse(appNumberBox.Text, out num))
            {
                address.ApartmentNumber = num;
                address.StreetAddress = addressBox.Text;
                address.City = cityBox.Text;
                address.Province = provinceBox.Text;
                address.Country = countryBox.Text;
                address.PostalCode = postalCodeBox.Text;
                db.UpdateAddressContact(address);
                Close();
            }
            else
            {
                MessageBox.Show("You have not entered a valid entry for the apartment number please try again");
            }
            
        }
    }
}
