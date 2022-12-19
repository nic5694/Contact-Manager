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

        
        
        public NewEmail()
        {
            InitializeComponent();
        }

        private void saveNewEmail(object sender, RoutedEventArgs e)
        {
            
            string type = typesComboBox.Text;
            
            if(type == "")
            {
                MessageBox.Show("You must select a type from the dropdown ");
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

            bool validate = aCW.emailTypeExistAlready(t);

            if (validate)
            {
                MessageBox.Show(type + " Email already exist, there must be only one email per type ! ", "Info Missing", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            Email email = new Email();

            string contactEmail = emailBox.Text;

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
