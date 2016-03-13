using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TaskManager.Common;

namespace TaskManager.Desktop
{
    public partial class MainForm : Form
    {
        private Task currentTask;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateCurrentTask(Task task = null)
        {
            if (task != null)
                currentTask = task;

            // Common
            TaskName.Text = currentTask.Name;
            TaskDescription.Text = currentTask.Description;

            // Children
            ChildrenPanel.Controls.Clear();
            foreach (Task childTask in currentTask.Children)
            {
                ChildTaskControl taskControl = new ChildTaskControl();
                taskControl.UpdateTask(childTask);

                ChildrenPanel.Controls.Add(taskControl);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateCurrentTask(new DummyTask());
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            TasksSizer.Width = ClientSize.Width;
        }
    }
}