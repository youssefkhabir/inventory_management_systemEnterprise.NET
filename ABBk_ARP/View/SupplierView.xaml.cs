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
    /// Logique d'interaction pour SupplierView.xaml
    /// </summary>
    public partial class SupplierView : UserControl
    {
        public SupplierView()
        {
            InitializeComponent();
        }
        private void Clean(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Search...")
            {
                textBox.Text = string.Empty;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddSuppliere Add = new AddSuppliere();
            Add.Show();
        }
    }
}
