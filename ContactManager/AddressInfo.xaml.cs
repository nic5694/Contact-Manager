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
        
        public AddressInfo()
        {
            InitializeComponent();
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
        }

        private void Save_Address(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Visible;
            appNumberBox.IsEnabled = false;
            addressBox.IsEnabled = false;
            cityBox.IsEnabled = false;
            provinceBox.IsEnabled = false;
            countryBox.IsEnabled = false;
            postalCodeBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;

            
        }
    }
}
