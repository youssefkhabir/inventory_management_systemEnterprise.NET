using ABBk_ARP.AddViews;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABBk_ARP.View
{
    /// <summary>
    /// Logique d'interaction pour CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

       private void Clean(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox != null && textBox.Text== "Search...")
            {
                textBox.Text = string.Empty;   

            }

        }

        private void Add_Customer(object sender, RoutedEventArgs e)
        {
             AddCustomer Add = new AddCustomer();

            Add.Show();
        }
    }
}
