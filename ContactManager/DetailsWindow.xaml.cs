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
            DataBase db = new DataBase();
            contact = db.GetContact(id);
            this.DataContext = contact;
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // Show the calendar when the button is clicked
            birthdayCalendar.Visibility = Visibility.Visible;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            /*
             * here you will take all the fields in the xaml and yhou will .content all fpo the the information
             * from the Conatact that you revceived like i did below
            fName.Content = contact.FirstName;
            */
        }
    }
}
