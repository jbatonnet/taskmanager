namespace TaskManager.Desktop
{
    partial class RawMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawMainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Drivers");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Interface");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("System", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("FlowTomator");
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Document");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("File");
            this.MenuBar = new System.Windows.Forms.ToolStrip();
            this.NewButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.UndoButton = new System.Windows.Forms.ToolStripButton();
            this.RedoButton = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTaskButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTaskButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AttachementsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenAttachementButton = new System.Windows.Forms.ToolStripMenuItem();
            this.renameAttachementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAttachementButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.TaskTree = new System.Windows.Forms.MyTreeView();
            this.TablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TaskNameBox = new System.Windows.Forms.TextBox();
            this.TaskDescriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskDateBox = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TaskTagsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TaskMetadataList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TaskAttachementsList = new System.Windows.Forms.ListView();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.AttachementsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.TablePanel.SuspendLayout();
            this.TaskTagsPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.OpenButton,
            this.SaveButton,
            this.toolStripSeparator,
            this.UndoButton,
            this.RedoButton});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(841, 25);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "toolStrip1";
            // 
            // NewButton
            // 
            this.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewButton.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Image")));
            this.NewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(23, 22);
            this.NewButton.Text = "&New";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(23, 22);
            this.OpenButton.Text = "&Open";
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "&Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // UndoButton
            // 
            this.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoButton.Enabled = false;
            this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
            this.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(23, 22);
            this.UndoButton.Text = "Undo";
            this.UndoButton.ToolTipText = "Undo last action";
            // 
            // RedoButton
            // 
            this.RedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoButton.Enabled = false;
            this.RedoButton.Image = ((System.Drawing.Image)(resources.GetObject("RedoButton.Image")));
            this.RedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(23, 22);
            this.RedoButton.Text = "Redo";
            this.RedoButton.ToolTipText = "Redo last action";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 555);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(841, 22);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(26, 17);
            this.StatusLabel.Text = "Idle";
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskButton,
            this.DeleteTaskButton});
            this.TreeContextMenu.Name = "ContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(132, 48);
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(131, 22);
            this.AddTaskButton.Text = "Add task";
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // DeleteTaskButton
            // 
            this.DeleteTaskButton.Name = "DeleteTaskButton";
            this.DeleteTaskButton.Size = new System.Drawing.Size(131, 22);
            this.DeleteTaskButton.Text = "Delete task";
            this.DeleteTaskButton.Click += new System.EventHandler(this.DeleteTaskButton_Click);
            // 
            // AttachementsContextMenu
            // 
            this.AttachementsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenAttachementButton,
            this.renameAttachementToolStripMenuItem,
            this.DeleteAttachementButton});
            this.AttachementsContextMenu.Name = "AttachementsContextMenu";
            this.AttachementsContextMenu.Size = new System.Drawing.Size(118, 70);
            // 
            // OpenAttachementButton
            // 
            this.OpenAttachementButton.Name = "OpenAttachementButton";
            this.OpenAttachementButton.Size = new System.Drawing.Size(117, 22);
            this.OpenAttachementButton.Text = "Open";
            this.OpenAttachementButton.Click += new System.EventHandler(this.OpenAttachementButton_Click);
            // 
            // renameAttachementToolStripMenuItem
            // 
            this.renameAttachementToolStripMenuItem.Name = "renameAttachementToolStripMenuItem";
            this.renameAttachementToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameAttachementToolStripMenuItem.Text = "Rename";
            // 
            // DeleteAttachementButton
            // 
            this.DeleteAttachementButton.Name = "DeleteAttachementButton";
            this.DeleteAttachementButton.Size = new System.Drawing.Size(117, 22);
            this.DeleteAttachementButton.Text = "Delete";
            this.DeleteAttachementButton.Click += new System.EventHandler(this.DeleteAttachementButton_Click);
            // 
            // SplitContainer
            // 
            this.SplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer.Location = new System.Drawing.Point(0, 25);
            this.SplitContainer.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.TaskTree);
            this.SplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.SplitContainer.Panel1MinSize = 192;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.TablePanel);
            this.SplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.SplitContainer.Size = new System.Drawing.Size(841, 530);
            this.SplitContainer.SplitterDistance = 250;
            this.SplitContainer.TabIndex = 4;
            // 
            // TaskTree
            // 
            this.TaskTree.AllowDrop = true;
            this.TaskTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskTree.ContextMenuStrip = this.TreeContextMenu;
            this.TaskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskTree.FullRowSelect = true;
            this.TaskTree.HideSelection = false;
            this.TaskTree.Location = new System.Drawing.Point(0, 1);
            this.TaskTree.Name = "TaskTree";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Drivers";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Interface";
            treeNode3.Name = "Node0";
            treeNode3.Text = "System";
            treeNode4.Name = "Node1";
            treeNode4.Text = "FlowTomator";
            this.TaskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.TaskTree.PathSeparator = "/";
            this.TaskTree.Size = new System.Drawing.Size(250, 529);
            this.TaskTree.TabIndex = 3;
            this.TaskTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TaskTree_ItemDrag);
            this.TaskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TaskTree_AfterSelect);
            this.TaskTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskTree_DragDrop);
            this.TaskTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaskTree_DragEnter);
            this.TaskTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TaskTree_MouseUp);
            // 
            // TablePanel
            // 
            this.TablePanel.AutoSize = true;
            this.TablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TablePanel.BackColor = System.Drawing.SystemColors.Control;
            this.TablePanel.ColumnCount = 4;
            this.TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.TablePanel.Controls.Add(this.label1, 1, 1);
            this.TablePanel.Controls.Add(this.label2, 1, 2);
            this.TablePanel.Controls.Add(this.TaskNameBox, 2, 1);
            this.TablePanel.Controls.Add(this.TaskDescriptionBox, 2, 2);
            this.TablePanel.Controls.Add(this.label3, 1, 3);
            this.TablePanel.Controls.Add(this.TaskDateBox, 2, 3);
            this.TablePanel.Controls.Add(this.label4, 1, 4);
            this.TablePanel.Controls.Add(this.label5, 1, 5);
            this.TablePanel.Controls.Add(this.TaskTagsPanel, 2, 4);
            this.TablePanel.Controls.Add(this.label7, 1, 6);
            this.TablePanel.Controls.Add(this.tabControl1, 2, 6);
            this.TablePanel.Controls.Add(this.TaskAttachementsList, 2, 5);
            this.TablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePanel.Location = new System.Drawing.Point(0, 1);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.RowCount = 7;
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanel.Size = new System.Drawing.Size(587, 529);
            this.TablePanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // TaskNameBox
            // 
            this.TaskNameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskNameBox.Location = new System.Drawing.Point(86, 6);
            this.TaskNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.TaskNameBox.Name = "TaskNameBox";
            this.TaskNameBox.Size = new System.Drawing.Size(495, 20);
            this.TaskNameBox.TabIndex = 3;
            this.TaskNameBox.Text = "My short name";
            this.TaskNameBox.TextChanged += new System.EventHandler(this.TaskNameBox_TextChanged);
            // 
            // TaskDescriptionBox
            // 
            this.TaskDescriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskDescriptionBox.Location = new System.Drawing.Point(86, 28);
            this.TaskDescriptionBox.Margin = new System.Windows.Forms.Padding(2);
            this.TaskDescriptionBox.Multiline = true;
            this.TaskDescriptionBox.Name = "TaskDescriptionBox";
            this.TaskDescriptionBox.Size = new System.Drawing.Size(495, 68);
            this.TaskDescriptionBox.TabIndex = 4;
            this.TaskDescriptionBox.Text = "My long and detailed description";
            this.TaskDescriptionBox.TextChanged += new System.EventHandler(this.TaskDescriptionBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            // 
            // TaskDateBox
            // 
            this.TaskDateBox.Location = new System.Drawing.Point(86, 100);
            this.TaskDateBox.Margin = new System.Windows.Forms.Padding(2);
            this.TaskDateBox.Name = "TaskDateBox";
            this.TaskDateBox.ShowCheckBox = true;
            this.TaskDateBox.Size = new System.Drawing.Size(200, 20);
            this.TaskDateBox.TabIndex = 6;
            this.TaskDateBox.ValueChanged += new System.EventHandler(this.TaskDateBox_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tags";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Attachements";
            // 
            // TaskTagsPanel
            // 
            this.TaskTagsPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TaskTagsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaskTagsPanel.Controls.Add(this.label6);
            this.TaskTagsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskTagsPanel.Location = new System.Drawing.Point(86, 122);
            this.TaskTagsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TaskTagsPanel.Name = "TaskTagsPanel";
            this.TaskTagsPanel.Size = new System.Drawing.Size(495, 52);
            this.TaskTagsPanel.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2);
            this.label6.Size = new System.Drawing.Size(44, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "UI/UX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Modules";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(86, 250);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 277);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TaskMetadataList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(487, 251);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Metadata";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TaskMetadataList
            // 
            this.TaskMetadataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.TaskMetadataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskMetadataList.LabelEdit = true;
            this.TaskMetadataList.Location = new System.Drawing.Point(3, 3);
            this.TaskMetadataList.Name = "TaskMetadataList";
            this.TaskMetadataList.Size = new System.Drawing.Size(481, 245);
            this.TaskMetadataList.TabIndex = 0;
            this.TaskMetadataList.UseCompatibleStateImageBehavior = false;
            this.TaskMetadataList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 192;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(487, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Project";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(487, 251);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Contact";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TaskAttachementsList
            // 
            this.TaskAttachementsList.AllowDrop = true;
            this.TaskAttachementsList.ContextMenuStrip = this.AttachementsContextMenu;
            this.TaskAttachementsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskAttachementsList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.TaskAttachementsList.Location = new System.Drawing.Point(86, 178);
            this.TaskAttachementsList.Margin = new System.Windows.Forms.Padding(2);
            this.TaskAttachementsList.Name = "TaskAttachementsList";
            this.TaskAttachementsList.Size = new System.Drawing.Size(495, 68);
            this.TaskAttachementsList.TabIndex = 12;
            this.TaskAttachementsList.UseCompatibleStateImageBehavior = false;
            this.TaskAttachementsList.View = System.Windows.Forms.View.SmallIcon;
            this.TaskAttachementsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskAttachementsList_DragDrop);
            this.TaskAttachementsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaskAttachementsList_DragEnter);
            // 
            // RawMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 577);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "RawMainForm";
            this.Text = "TaskManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.TreeContextMenu.ResumeLayout(false);
            this.AttachementsContextMenu.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.TablePanel.ResumeLayout(false);
            this.TablePanel.PerformLayout();
            this.TaskTagsPanel.ResumeLayout(false);
            this.TaskTagsPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MenuBar;
        private System.Windows.Forms.ToolStripButton NewButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton UndoButton;
        private System.Windows.Forms.ToolStripButton RedoButton;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddTaskButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteTaskButton;
        private System.Windows.Forms.ContextMenuStrip AttachementsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem renameAttachementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenAttachementButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteAttachementButton;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.ListView TaskAttachementsList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView TaskMetadataList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel TaskTagsPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker TaskDateBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TaskDescriptionBox;
        private System.Windows.Forms.TextBox TaskNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TablePanel;
        private System.Windows.Forms.MyTreeView TaskTree;
    }
}

