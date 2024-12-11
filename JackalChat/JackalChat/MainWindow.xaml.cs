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

namespace JackalChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /* we need this because only checking if the click count is two cause some bugs when dragmoving */
        private DateTime lastClickTime = DateTime.MinValue;
        private readonly int doubleClickThreshold = 300;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            bool validDoubleClick = (currentTime - lastClickTime).TotalMilliseconds <= doubleClickThreshold;

            if (lastClickTime != DateTime.MinValue && validDoubleClick)
            {
                HandleMaximize();
            }
            else
            {
                DragMove();
            }

            lastClickTime = currentTime;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            HandleMaximize();
        }

        private void HandleMaximize()
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

    }
}
