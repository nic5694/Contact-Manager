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
    /// Interaction logic for NewEmail.xaml
    /// </summary>
    public partial class NewEmail : Window
    {

        
        
        public NewEmail(int count)
        {
            InitializeComponent();

            if(count == 1)
            {
                typeLabel.Content = "Personal";
            } else if(count == 2)
            {
                typeLabel.Content = "Business";
            } else if (count == 3)
            {
                typeLabel.Content = "Other";
            }
        }

        private void saveNewEmail(object sender, RoutedEventArgs e)
        {
            AddContactWindow aCW = new AddContactWindow();
            Email email = new Email();

            String type = typeLabel.Content.ToString();
            String contactEmail = emailBox.Text;

            if (contactEmail == "")
            {
                MessageBox.Show("You must enter an email to save");
                return;
            } else
            {
                email.EmailAddress = contactEmail;

                if(type == "Personal")
                {
                    email.Type_Code = 'P';

                } else if (type == "Business")
                {
                    email.Type_Code = 'B';

                } else
                {
                    email.Type_Code = 'O';
                }

                aCW.addEmailToList(email);
                
                Close();
            }

            
        }
    }
}
