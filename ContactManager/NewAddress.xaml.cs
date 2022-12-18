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
        public NewAddress(int count)
        {
            InitializeComponent();

            if (count == 1)
            {
                typeLabel.Content = "Personal";
            }
            else if (count == 2)
            {
                typeLabel.Content = "Business";
            }
            else if (count == 3)
            {
                typeLabel.Content = "Other";
            }
        }

        private void saveNewAddress(object sender, RoutedEventArgs e)
        {
            AddContactWindow aCW = new AddContactWindow();
            Address address = new Address();

            string type = typeLabel.Content.ToString();
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
