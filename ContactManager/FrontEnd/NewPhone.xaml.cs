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
        public NewPhone(int count)
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

        private void saveNewPhone(object sender, RoutedEventArgs e)
        {
            AddContactWindow aCW = new AddContactWindow();
            Phone phone = new Phone();

            String type = typeLabel.Content.ToString();
            String countryCode = countryCodeBox.Text;
            String contactPhone = phoneBox.Text.ToString();

            if (contactPhone == "")
            {
                MessageBox.Show("You must enter a phone number to save");
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
