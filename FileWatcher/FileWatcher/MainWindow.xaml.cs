using System;
using System.Windows;
using FileWatcher.MVVM.ViewModel;

namespace FileWatcher
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            var viewModel = DataContext as MainViewModel;
            viewModel?.MinimizeToTrayCommand.Execute(null);
        }
    }
}
