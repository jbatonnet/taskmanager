using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TaskManager.Common;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using TaskManager.Shared;

namespace TaskManager.Desktop
{
    public partial class RawMainForm : Form
    {
        private bool modified = false;

        private Dictionary<Task, List<TreeNode>> taskNodes = new Dictionary<Task, List<TreeNode>>();
        private Dictionary<string, Attachment> openAttachements = new Dictionary<string, Attachment>();

        private TreeNode selectedNode;
        private Task selectedTask;

        public RawMainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshTree();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified && MessageBox.Show("There are unsaved modification. Do you want to quit ?", "TaskManager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void RefreshTree()
        {
            taskNodes.Clear();

            // Build task tree
            TaskTree.Nodes.Clear();
            foreach (Task task in Program.Database.Where(t => t.Parents.Count == 0))
            {
                TreeNode node = TaskTree.Nodes.Add(task.Name);
                taskNodes.Add(task, new List<TreeNode>() { node });

                BuildNode(node, task);
            }

            // Expand first 2 levels
            foreach (TreeNode node in TaskTree.Nodes)
            {
                node.Expand();

                foreach (TreeNode subNode in node.Nodes)
                    subNode.Expand();
            }

            selectedNode = TaskTree.Nodes[0];
            selectedTask = selectedNode.Tag as Task;
        }
        private void RefreshTask()
        {
            SuspendLayout();

            if (selectedTask == null)
                return;

            TaskNameBox.Text = selectedTask.Name;
            TaskDescriptionBox.Text = selectedTask.Description ?? "";

            TaskDateBox.Checked = selectedTask.Date != null;
            if (selectedTask.Date != null)
                TaskDateBox.Value = selectedTask.Date.Value;

            TaskTagsPanel.Controls.Clear();
            foreach (Tag tag in selectedTask.Tags)
            {
                Label label = new Label();
                label.Text = tag.Name;
                label.Tag = tag;
                label.Padding = new Padding(2);
                label.Margin = new Padding(3, 3, 0, 0);
                TaskTagsPanel.Controls.Add(label);
            }

            TaskAttachementsList.Items.Clear();
            foreach (Attachment attachement in selectedTask.Attachements)
            {
                ListViewItem item = TaskAttachementsList.Items.Add(attachement.Name);
                item.Tag = attachement;
            }

            TaskMetadataList.Items.Clear();
            foreach (string key in selectedTask.Metadata.Keys)
            {
                ListViewItem item = TaskMetadataList.Items.Add(key);
                item.SubItems.Add(selectedTask.Metadata[key].ToString());
            }

            ResumeLayout();
        }

        private void BuildNode(TreeNode node, Task task)
        {
            node.Tag = task;

            foreach (Task subTask in task.Children)
            {
                TreeNode subNode = node.Nodes.Add(subTask.Name);

                List<TreeNode> nodes;
                if (!taskNodes.TryGetValue(subTask, out nodes))
                    taskNodes.Add(subTask, nodes = new List<TreeNode>());
                nodes.Add(subNode);

                BuildNode(subNode, subTask);
            }
        }
        private void RemoveNode(TreeNode node)
        {
            foreach (TreeNode subNode in node.Nodes)
                RemoveNode(subNode);

            foreach (Task task in taskNodes.Keys.ToArray())
            {
                List<TreeNode> nodes = taskNodes[task];
                if (!nodes.Contains(node))
                    continue;

                // Remove the node
                nodes.Remove(node);

                // If the task is no longer referenced
                if (nodes.Count == 0)
                {
                    foreach (Task parent in task.Parents)
                        parent.Children.Remove(task);
                    foreach (Task child in task.Children)
                        child.Parents.Remove(task);

                    Program.Database.Objects.Remove(task);
                    taskNodes.Remove(task);
                }
            }
        }

        private void TaskTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshTask();
        }
        private void TaskTree_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo hitTest = TaskTree.HitTest(e.X, e.Y);

            selectedNode = hitTest.Node;
            selectedTask = selectedNode?.Tag as Task;

            DeleteTaskButton.Enabled = selectedTask != null;
        }

        private void TaskNameBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedTask == null)
                return;

            string value = TaskNameBox.Text;
            if (selectedTask.Name == value)
                return;

            selectedTask.Name = value;
            modified = true;

            foreach (TreeNode node in taskNodes[selectedTask])
                node.Text = value;
        }
        private void TaskDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedTask == null)
                return;

            string value = TaskDescriptionBox.Text;
            if (selectedTask.Description == value)
                return;

            selectedTask.Description = value;
            modified = true;
        }
        private void TaskDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (selectedTask == null)
                return;

            DateTime? value = TaskDateBox.Checked ? TaskDateBox.Value : (DateTime?)null;
            if (selectedTask.Date == value)
                return;

            selectedTask.Date = value;
            modified = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Program.Database.Save();
            modified = false;
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.Id = taskNodes.Select(t => t.Key.Id).Max() + 1;
            task.Name = "New task";

            if (selectedTask != null)
            { 
                task.Parents.Add(selectedTask);
                selectedTask.Children.Add(task);
            }

            TreeNodeCollection nodeCollection = selectedNode == null ? TaskTree.Nodes : selectedNode.Nodes;

            TreeNode node = nodeCollection.Add(task.Name);
            node.Tag = task;

            modified = true;
            Program.Database.Objects.Add(task);
            taskNodes.Add(task, new List<TreeNode>() { node });

            if (selectedNode != null)
                selectedNode.Expand();

            selectedNode = node;
            selectedTask = task;

            TaskTree.SelectedNode = node;
        }
        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
                return;

            if (selectedTask.Children.Count > 0)
            {
                if (MessageBox.Show("Do you really want to remove task \"" + selectedTask.Name + "\" and all its children ?", "TaskManager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            modified = true;
            RemoveNode(selectedNode);
            selectedNode.Remove();
        }

        private void TaskTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            selectedNode = e.Item as TreeNode;
            selectedTask = selectedNode.Tag as Task;

            RefreshTask();

            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void TaskTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void TaskTree_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = TaskTree.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = TaskTree.GetNodeAt(targetPoint);
            Task targetTask = targetNode?.Tag as Task;

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            Task draggedTask = draggedNode.Tag as Task;
            Task draggedTaskParent = draggedNode.Parent?.Tag as Task;

            if (!draggedNode.Equals(targetNode))
            {
                modified = true;
                draggedNode.Remove();

                if (draggedTaskParent != null)
                {
                    draggedTask.Parents.Remove(draggedTaskParent);
                    draggedTaskParent.Children.Remove(draggedTask);
                }

                if (targetNode != null)
                    targetNode.Nodes.Add(draggedNode);
                else
                    TaskTree.Nodes.Add(draggedNode);

                if (targetTask != null)
                {
                    targetTask.Children.Add(draggedTask);
                    draggedTask.Parents.Add(targetTask);
                }

                if (targetNode != null)
                    targetNode.Expand();
            }
        }

        private void TaskAttachementsList_DragEnter(object sender, DragEventArgs e)
        {
            if (selectedTask == null)
                return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
        private void TaskAttachementsList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!fileInfo.Exists)
                    continue;

                Attachment attachement = new Attachment();
                attachement.Type = AttachmentType.File;
                attachement.Name = fileInfo.Name;
                attachement.Data = File.ReadAllBytes(fileInfo.FullName);

                selectedTask.Attachements.Add(attachement);
                modified = true;

                RefreshTask();
            }
        }

        private void OpenAttachementButton_Click(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();
            string tempDirectory = Path.GetRandomFileName();

            string path = Path.Combine(tempPath, tempDirectory);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            ListViewItem selectedItem = TaskAttachementsList.SelectedItems[0];
            Attachment attachement = selectedItem.Tag as Attachment;

            path = Path.Combine(path, attachement.Name);
            File.WriteAllBytes(path, attachement.Data);

            openAttachements.Add(path.ToLower(), attachement);

            FileSystemWatcher fsWatcher = new FileSystemWatcher(Path.GetDirectoryName(path));
            fsWatcher.Filter = Path.GetFileName(path);
            fsWatcher.Changed += FsWatcher_Changed;
            fsWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.Attributes;
            fsWatcher.EnableRaisingEvents = true;

            Process.Start(path);
        }
        private void DeleteAttachementButton_Click(object sender, EventArgs e)
        {
            if (TaskAttachementsList.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem selectedItem in TaskAttachementsList.SelectedItems)
            {
                Attachment attachement = selectedItem.Tag as Attachment;
                selectedTask.Attachements.Remove(attachement);
            }

            RefreshTask();
        }

        private void FsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            Attachment attachement = openAttachements[path.ToLower()];
            attachement.Data = File.ReadAllBytes(path);
        }
    }
}