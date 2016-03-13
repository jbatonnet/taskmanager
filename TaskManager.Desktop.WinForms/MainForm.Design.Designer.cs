namespace TaskManager.Desktop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.UndoButton = new System.Windows.Forms.ToolStripButton();
            this.RedoButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TasksPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TaskBorder = new System.Windows.Forms.Panel();
            this.TaskPanel = new System.Windows.Forms.Panel();
            this.AddChildPanel = new System.Windows.Forms.Panel();
            this.TaskName = new System.Windows.Forms.Label();
            this.TaskDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskTagsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TasksSizer = new System.Windows.Forms.Panel();
            this.AddChildPanelArrow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChildrenPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.childTaskControl1 = new TaskManager.Desktop.ChildTaskControl();
            this.childTaskControl2 = new TaskManager.Desktop.ChildTaskControl();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.TasksPanel.SuspendLayout();
            this.TaskBorder.SuspendLayout();
            this.TaskPanel.SuspendLayout();
            this.AddChildPanel.SuspendLayout();
            this.AddChildPanelArrow.SuspendLayout();
            this.ChildrenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.OpenButton,
            this.SaveButton,
            this.toolStripSeparator,
            this.UndoButton,
            this.RedoButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // UndoButton
            // 
            this.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.RedoButton.Image = ((System.Drawing.Image)(resources.GetObject("RedoButton.Image")));
            this.RedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(23, 22);
            this.RedoButton.Text = "Redo";
            this.RedoButton.ToolTipText = "Redo last action";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(26, 17);
            this.StatusLabel.Text = "Idle";
            // 
            // TasksPanel
            // 
            this.TasksPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TasksPanel.Controls.Add(this.TasksSizer);
            this.TasksPanel.Controls.Add(this.TaskBorder);
            this.TasksPanel.Controls.Add(this.ChildrenPanel);
            this.TasksPanel.Controls.Add(this.AddChildPanel);
            this.TasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TasksPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TasksPanel.Location = new System.Drawing.Point(0, 25);
            this.TasksPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TasksPanel.Name = "TasksPanel";
            this.TasksPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.TasksPanel.Size = new System.Drawing.Size(284, 314);
            this.TasksPanel.TabIndex = 2;
            // 
            // TaskBorder
            // 
            this.TaskBorder.BackColor = System.Drawing.Color.LightGray;
            this.TaskBorder.Controls.Add(this.TaskPanel);
            this.TaskBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskBorder.Location = new System.Drawing.Point(8, 8);
            this.TaskBorder.Margin = new System.Windows.Forms.Padding(8, 0, 8, 4);
            this.TaskBorder.Name = "TaskBorder";
            this.TaskBorder.Padding = new System.Windows.Forms.Padding(1);
            this.TaskBorder.Size = new System.Drawing.Size(268, 65);
            this.TaskBorder.TabIndex = 0;
            // 
            // TaskPanel
            // 
            this.TaskPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.TaskPanel.Controls.Add(this.TaskTagsPanel);
            this.TaskPanel.Controls.Add(this.label3);
            this.TaskPanel.Controls.Add(this.TaskDescription);
            this.TaskPanel.Controls.Add(this.TaskName);
            this.TaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskPanel.Location = new System.Drawing.Point(1, 1);
            this.TaskPanel.Name = "TaskPanel";
            this.TaskPanel.Size = new System.Drawing.Size(266, 63);
            this.TaskPanel.TabIndex = 0;
            // 
            // AddChildPanel
            // 
            this.AddChildPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddChildPanel.Controls.Add(this.linkLabel1);
            this.AddChildPanel.Controls.Add(this.AddChildPanelArrow);
            this.AddChildPanel.Location = new System.Drawing.Point(8, 145);
            this.AddChildPanel.Margin = new System.Windows.Forms.Padding(8, 4, 8, 0);
            this.AddChildPanel.Name = "AddChildPanel";
            this.AddChildPanel.Size = new System.Drawing.Size(268, 24);
            this.AddChildPanel.TabIndex = 1;
            // 
            // TaskName
            // 
            this.TaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskName.Location = new System.Drawing.Point(4, 6);
            this.TaskName.Name = "TaskName";
            this.TaskName.Size = new System.Drawing.Size(210, 16);
            this.TaskName.TabIndex = 0;
            this.TaskName.Text = "Task.Name";
            // 
            // TaskDescription
            // 
            this.TaskDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskDescription.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TaskDescription.Location = new System.Drawing.Point(4, 24);
            this.TaskDescription.Name = "TaskDescription";
            this.TaskDescription.Size = new System.Drawing.Size(258, 15);
            this.TaskDescription.TabIndex = 1;
            this.TaskDescription.Text = "Task.Description";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "100 %";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TaskTagsPanel
            // 
            this.TaskTagsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskTagsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.TaskTagsPanel.Location = new System.Drawing.Point(0, 0);
            this.TaskTagsPanel.Name = "TaskTagsPanel";
            this.TaskTagsPanel.Size = new System.Drawing.Size(268, 4);
            this.TaskTagsPanel.TabIndex = 3;
            // 
            // TasksSizer
            // 
            this.TasksSizer.Location = new System.Drawing.Point(0, 8);
            this.TasksSizer.Margin = new System.Windows.Forms.Padding(0);
            this.TasksSizer.Name = "TasksSizer";
            this.TasksSizer.Size = new System.Drawing.Size(284, 0);
            this.TasksSizer.TabIndex = 2;
            // 
            // AddChildPanelArrow
            // 
            this.AddChildPanelArrow.Controls.Add(this.panel3);
            this.AddChildPanelArrow.Controls.Add(this.panel1);
            this.AddChildPanelArrow.Location = new System.Drawing.Point(8, 5);
            this.AddChildPanelArrow.Margin = new System.Windows.Forms.Padding(0);
            this.AddChildPanelArrow.Name = "AddChildPanelArrow";
            this.AddChildPanelArrow.Size = new System.Drawing.Size(8, 8);
            this.AddChildPanelArrow.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 1);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 8);
            this.panel3.TabIndex = 1;
            // 
            // ChildrenPanel
            // 
            this.ChildrenPanel.AutoSize = true;
            this.ChildrenPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChildrenPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ChildrenPanel.Controls.Add(this.childTaskControl1);
            this.ChildrenPanel.Controls.Add(this.childTaskControl2);
            this.ChildrenPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChildrenPanel.Location = new System.Drawing.Point(8, 77);
            this.ChildrenPanel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.ChildrenPanel.Name = "ChildrenPanel";
            this.ChildrenPanel.Size = new System.Drawing.Size(268, 64);
            this.ChildrenPanel.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(18, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add a child";
            // 
            // childTaskControl1
            // 
            this.childTaskControl1.BackColor = System.Drawing.SystemColors.Control;
            this.childTaskControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.childTaskControl1.Location = new System.Drawing.Point(0, 4);
            this.childTaskControl1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.childTaskControl1.Name = "childTaskControl1";
            this.childTaskControl1.Size = new System.Drawing.Size(268, 24);
            this.childTaskControl1.TabIndex = 0;
            // 
            // childTaskControl2
            // 
            this.childTaskControl2.BackColor = System.Drawing.SystemColors.Control;
            this.childTaskControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.childTaskControl2.Location = new System.Drawing.Point(0, 36);
            this.childTaskControl2.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.childTaskControl2.Name = "childTaskControl2";
            this.childTaskControl2.Size = new System.Drawing.Size(268, 24);
            this.childTaskControl2.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.TasksPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "MainForm";
            this.Text = "TaskManager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.TasksPanel.ResumeLayout(false);
            this.TasksPanel.PerformLayout();
            this.TaskBorder.ResumeLayout(false);
            this.TaskPanel.ResumeLayout(false);
            this.AddChildPanel.ResumeLayout(false);
            this.AddChildPanel.PerformLayout();
            this.AddChildPanelArrow.ResumeLayout(false);
            this.ChildrenPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton NewButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton UndoButton;
        private System.Windows.Forms.ToolStripButton RedoButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.FlowLayoutPanel TasksPanel;
        private System.Windows.Forms.Panel TaskBorder;
        private System.Windows.Forms.Panel TaskPanel;
        private System.Windows.Forms.Panel AddChildPanel;
        private System.Windows.Forms.Label TaskName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TaskDescription;
        private System.Windows.Forms.FlowLayoutPanel TaskTagsPanel;
        private System.Windows.Forms.Panel TasksSizer;
        private System.Windows.Forms.Panel AddChildPanelArrow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel ChildrenPanel;
        private ChildTaskControl childTaskControl1;
        private ChildTaskControl childTaskControl2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

