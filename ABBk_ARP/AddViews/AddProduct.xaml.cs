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
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ABBk_ARP.AddViews
{
    /// <summary>
    /// Logique d'interaction pour AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
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
            this.Close();



        }

        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btn_Brows_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";

            
            bool? result = openFileDialog.ShowDialog();

            
            if (result == true)
            {
                // Load the image
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));


                UploadedImage.Source = bitmap;
            }
    }
    }
}

