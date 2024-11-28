
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

namespace ABBk_ARP.View
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window  //extend the class userrepesotory b3teli
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();



        }

        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btn_log_Click(object sender, RoutedEventArgs e)

        {
            //if (txtUsername.Text == "youssef" && txtpass.Password=="123456789") //just for testing 
            //{
            Home next = new Home();
            this.Visibility = Visibility.Hidden; //we keep hidding the current window using this line of code 
            next.Show();
            //}

        }

       

    }
}