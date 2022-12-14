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
    /// Interaction logic for PhoneInfo.xaml
    /// </summary>
    public partial class PhoneInfo : Window
    {
        public PhoneInfo()
        {
            InitializeComponent();
        }

        private void Save_Phone(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Hidden;
            phoneBox.IsEnabled = false;
            editBtn.Visibility = Visibility.Visible;
        }

        private void Edit_Phone(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Visible;
            phoneBox.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Hidden;
            phoneBox.IsEnabled = false;
        }
    }
}
