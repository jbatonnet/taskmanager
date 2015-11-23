using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class SingleTaskGraphView : UserControl
    {
        public static DependencyProperty TaskProperty = DependencyProperty.Register(nameof(Task), typeof(Task), typeof(SingleTaskGraphView), new PropertyMetadata(TaskProperty_Changed));

        public Task Task
        {
            get
            {
                return GetValue(TaskProperty) as Task;
            }
            set
            {
                SetValue(TaskProperty, value);
            }
        }

        public SingleTaskGraphView()
        {
            InitializeComponent();
        }

        private void Children_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }
        private void AddChild_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private static void TaskProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SingleTaskGraphView graphView = d as SingleTaskGraphView;
            Task task = e.NewValue as Task;

            graphView.Root.DataContext = task;
        }
    }
}