using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TaskManager.Common;

namespace TaskManager.Desktop
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public DelegateCommand NewStorageCommand { get; private set; }
        public DelegateCommand OpenStorageCommand { get; private set; }

        public DelegateCommand UndoCommand { get; private set; }
        public DelegateCommand RedoCommand { get; private set; }

        public Task Task
        {
            get
            {
                return task;
            }
            set
            {
                task = value;
                NotifyPropertyChanged();
            }
        }
        private Task task;

        public MainWindow()
        {
            Tag = new DependencyManager(this, (s, e) => PropertyChanged(s, e));
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task = new DummyTask();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string property = null)
        {
            if (property != null && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}