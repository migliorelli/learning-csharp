using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing;
using FileWatcher.Core;

namespace FileWatcher.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        private NotifyIcon notifyIcon;

        private bool _watching = false;
        public bool Watching
        {
            get { return _watching; }
            set { _watching = value; OnPropertyChanged(); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectFileCommand { get; set; }
        public RelayCommand StopWatchingCommand { get; set; }
        public RelayCommand MinimizeToTrayCommand { get; set; }


        public MainViewModel()
        {

            ConfigureTrayIcon();

            SelectFileCommand = new RelayCommand(o => SelectFile());
            StopWatchingCommand = new RelayCommand(o => StopWatching());
            MinimizeToTrayCommand = new RelayCommand(o => MinimizeToTray());
        }

        private void ConfigureTrayIcon()
        {

            notifyIcon = new NotifyIcon
            {
                Visible = false,
                Text = "File Watcher",
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon("Icons/eye.ico"),
            };

            notifyIcon.ContextMenuStrip.Items.Add("Watch another file", null, (sender, args) => SelectFile());
            notifyIcon.ContextMenuStrip.Items.Add("Stop watching", null, (sender, args) => StopWatching());
            notifyIcon.ContextMenuStrip.Items.Add("Quit", null, (sender, args) => CloseApplication());

            notifyIcon.DoubleClick += (sender, args) => RestoreFromTray();
        }

        private void RestoreFromTray()
        {
            notifyIcon.Visible = true;
            System.Windows.Application.Current.MainWindow.Show();
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
            System.Windows.Application.Current.MainWindow.Activate();
        }

        private void SelectFile()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FilePath = dialog.SelectedPath;
                StartWatching();
            }
        }

        private void CloseApplication()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            System.Windows.Application.Current.Shutdown();
        }

        private void MinimizeToTray()
        {
            notifyIcon.Visible = true;
            System.Windows.Application.Current.MainWindow.Hide();
        }

        private void StartWatching()
        {
            Watching = true;
        }

        private void StopWatching()
        {
            Watching = false;
            FilePath = null;
        }

    }
}
