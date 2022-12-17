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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        Contact contact;
        public DetailsWindow(int id)
        {
            InitializeComponent();

            DeleteBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Hidden;
            TitleBox.IsEnabled = false;
            FirstNameBox.IsEnabled = false;
            LastNameBox.IsEnabled = false;
            BirthdayCalender.IsEnabled = false;

            DataBase db = new DataBase();
            contact = db.GetContact(id);
            this.DataContext = contact;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            contact = db.GetContact(contact.Id);
            this.DataContext = contact;

            TitleBox.Text = contact.Title;
            FirstNameBox.Text = contact.FirstName;
            LastNameBox.Text = contact.LastName;





            //here you will assign all the data to the list views
            List<Address> addrs = new List<Address>();
            addrs = contact.Addresses;


            //PhoneListView.ItemsSource = contact.Addresses;
            //email
            //(emailListView)(example name).ItemsSources = contact.Emails;
            //(phoneListView)(Example name).ItemsSources = contact.phones;
            //names of the first name field
            //fieldnameisforName.content = contact.firstname
            //fieldsnameforlastName.content = contact.lastname
            //fiedlsnamefortitle.content = contect.title
           //bithday.content = contact.birthday maybe need to do .toString();
        }

        private void editContactDetails(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Visible;
            saveBtn.Visibility = Visibility.Visible;

            TitleBox.IsEnabled = true;
            FirstNameBox.IsEnabled = true;
            LastNameBox.IsEnabled = true;
            BirthdayCalender.IsEnabled = true;
        }

        private void saveContactDetails(object sender, RoutedEventArgs e)
        {
            DeleteBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Hidden;
            editBtn.Visibility = Visibility.Visible;

            TitleBox.IsEnabled = false;
            FirstNameBox.IsEnabled = false;
            LastNameBox.IsEnabled = false;
            BirthdayCalender.IsEnabled = false;
        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            //DataBase db = new DataBase();
            //db.desactivateContact(contact.Id);
            //Close();
        }
        /*
* the edit will undo the text boxes where their isenabled so you take the elements .isenabled = true.
* for the double click of an address you will use the xaml that youssef created and you just bind the data needed
* for the delete button that youssef will put in the xaml you will use the remove function that is in the database class
*/

    }
}
