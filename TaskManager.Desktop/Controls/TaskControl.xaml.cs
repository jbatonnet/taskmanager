using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace TaskManager.Desktop
{
    public partial class TaskControl : UserControl, INotifyPropertyChanged
    {
        public bool NameEdition
        {
            get
            {
                return nameEdition;
            }
            set
            {
                nameEdition = value;
                NotifyPropertyChanged();
            }
        }
        [DependsOn(nameof(NameEdition))]
        public Visibility NameBoxVisibility
        {
            get
            {
                return nameEdition ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        [DependsOn(nameof(NameEdition))]
        public Visibility NameBlockVisibility
        {
            get
            {
                return nameEdition ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private bool nameEdition = false;

        public TaskControl()
        {
            Tag = new DependencyManager(this, (s, e) => PropertyChanged(s, e));
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string property = null)
        {
            if (property != null && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}