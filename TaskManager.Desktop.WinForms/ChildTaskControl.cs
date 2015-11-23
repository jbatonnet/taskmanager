using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TaskManager.Common;

namespace TaskManager.Desktop
{
    public partial class ChildTaskControl : UserControl
    {
        public ChildTaskControl()
        {
            InitializeComponent();
        }

        public void UpdateTask(Task childTask)
        {
            TaskName.Text = childTask.Name;
        }
    }
}