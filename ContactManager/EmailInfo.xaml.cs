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
    /// Interaction logic for EmailInfo.xaml
    /// </summary>
    public partial class EmailInfo : Window
    {
        public EmailInfo()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emailBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
        }

        private void Edit_Email(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            emailBox.IsEnabled = true;
            saveBtn.Visibility = Visibility.Visible;
        }

        private void Save_Email(object sender, RoutedEventArgs e)
        {
            //update contact email
            editBtn.Visibility = Visibility.Visible;
            emailBox.IsEnabled = false;
            saveBtn.Visibility = Visibility.Hidden;
        }
    }
}
