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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace ABBk_ARP.View
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {


        public Home()
        {
            InitializeComponent();

        }
        // Import the SendMessage function from user32.dll to be qble to drag qnd drop the window 
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);



        // Event handler for the MouseLeftButtonDown event on the control bar panel
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);// 161 is WM_NCLBUTTONDOWN, 2 is HTCAPTION
            //This is the message identifier. In this case, 161 corresponds to the WM_NCLBUTTONDOWN message. WM_NCLBUTTONDOWN is a Windows message that is sent when the left mouse button is pressed while the cursor is within the non-client area of a window. The non-client area includes elements such as the title bar, borders, and scroll bars of a window.


        }




        // Event handler for the MouseEnter event on the control bar panel
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}


