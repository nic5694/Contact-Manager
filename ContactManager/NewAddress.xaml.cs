using ContactManager.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for NewAddress.xaml
    /// </summary>
    public partial class NewAddress : Window
    {
        public NewAddress()
        {
            InitializeComponent();
        }

        private void saveNewAddress(object sender, RoutedEventArgs e)
        {
            string type = typesComboBox.Text;

            if (type == "")
            {
                MessageBox.Show("You must select a type from the dropdown ", "Select type", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AddContactWindow aCW = new AddContactWindow();
            char t;

            if (type == "Personal")
            {
                t = 'P';

            }
            else if (type == "Business")
            {
                t = 'B';

            }
            else
            {
                t = 'O';
            }

            bool validate = aCW.addressTypeExistAlready(t);

            if (validate)
            {
                MessageBox.Show(type + " address already exist, there must be only one address per type ! ", "Duplicate info", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Address address = new Address();
            string streetAddress = streetAddressBox.Text;
            string city = cityBox.Text;
            string province = provinceBox.Text;
            string postalCode = postalCodeBox.Text;
            string country = countryBox.Text;
            string appNumber = appNumberBox.Text;

            if (type == "Personal")
            {
                address.Type_Code = 'P';

            }
            else if (type == "Business")
            {
                address.Type_Code = 'B';

            }
            else
            {
                address.Type_Code = 'O';
            }

            if(appNumber != "")
            {
               address.ApartmentNumber = int.Parse(appNumber);
            }
            
            address.StreetAddress = streetAddress;
            address.City = city;
            address.Province = province;
            address.PostalCode = postalCode;
            address.Country = country;

            aCW.addAddressToList(address);

            Close();
        }
    }
}
