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
    /// Interaction logic for NewPhone.xaml
    /// </summary>
    public partial class NewPhone : Window
    {
        public NewPhone()
        {
            InitializeComponent();
            
        }

        private void saveNewPhone(object sender, RoutedEventArgs e)
        {
            string type = typesComboBox.Text;

            if (type == "")
            {
                MessageBox.Show("You must select a type from the dropdown ", "Select Type", MessageBoxButton.OK, MessageBoxImage.Error);

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

            bool validate = aCW.phoneTypeExistAlready(t);

            if (validate)
            {
                MessageBox.Show(type + " phone already exist, there must be only one phone per type ! ", "Duplicate Info", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            
            Phone phone = new Phone();

            string countryCode = countryCodeBox.Text;
            string contactPhone = phoneBox.Text.ToString();

            if (contactPhone == "")
            {
                MessageBox.Show("You must enter a phone number to save", "Info Missing", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else
            {
                phone.PhoneNumber = contactPhone;
                phone.CountryCode = countryCode;

                if (type == "Personal")
                {
                    phone.Type_Code = 'P';

                }
                else if (type == "Business")
                {
                    phone.Type_Code = 'B';

                }
                else
                {
                    phone.Type_Code = 'O';
                }

                aCW.addPhoneToList(phone);

                Close();
            }
        }
    }
}
