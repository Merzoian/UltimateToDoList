namespace UltimateToDoList
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listViewTasks = new ListView();
            column1 = new ColumnHeader();
            column2 = new ColumnHeader();
            column3 = new ColumnHeader();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panel1 = new Panel();
            btnDeleteTask = new Button();
            btnMarkComplete = new Button();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbFilterPriority = new ComboBox();
            btnAddTask = new Button();
            txtTaskTitle = new TextBox();
            dtpDueDate = new DateTimePicker();
            cmbPriority = new ComboBox();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // listViewTasks
            // 
            listViewTasks.AllowDrop = true;
            listViewTasks.BackColor = SystemColors.ScrollBar;
            listViewTasks.Columns.AddRange(new ColumnHeader[] { column1, column2, column3 });
            listViewTasks.Dock = DockStyle.Fill;
            listViewTasks.FullRowSelect = true;
            listViewTasks.GridLines = true;
            listViewTasks.Location = new Point(0, 60);
            listViewTasks.Name = "listViewTasks";
            listViewTasks.Size = new Size(1023, 338);
            listViewTasks.TabIndex = 0;
            listViewTasks.UseCompatibleStateImageBehavior = false;
            listViewTasks.View = View.Details;
            listViewTasks.ItemDrag += listViewTasks_ItemDrag;
            listViewTasks.SelectedIndexChanged += listViewTasks_SelectedIndexChanged;
            listViewTasks.DragDrop += listViewTasks_DragDrop;
            listViewTasks.DragEnter += listViewTasks_DragEnter;
            // 
            // column1
            // 
            column1.Text = "TaskTitle";
            column1.Width = 350;
            // 
            // column2
            // 
            column2.Text = "Priority";
            column2.Width = 100;
            // 
            // column3
            // 
            column3.Text = "DueDate";
            column3.Width = 120;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1023, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(118, 17);
            statusLabel.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteTask);
            panel1.Controls.Add(btnMarkComplete);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 398);
            panel1.Name = "panel1";
            panel1.Size = new Size(1023, 30);
            panel1.TabIndex = 2;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteTask.AutoSize = true;
            btnDeleteTask.Location = new Point(935, 2);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(76, 25);
            btnDeleteTask.TabIndex = 1;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnMarkComplete
            // 
            btnMarkComplete.AutoSize = true;
            btnMarkComplete.Location = new Point(3, 2);
            btnMarkComplete.Name = "btnMarkComplete";
            btnMarkComplete.Size = new Size(108, 25);
            btnMarkComplete.TabIndex = 0;
            btnMarkComplete.Text = "Toggle Complete";
            btnMarkComplete.UseVisualStyleBackColor = true;
            btnMarkComplete.Click += btnMarkComplete_Click;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbFilterPriority);
            panel2.Controls.Add(btnAddTask);
            panel2.Controls.Add(txtTaskTitle);
            panel2.Controls.Add(dtpDueDate);
            panel2.Controls.Add(cmbPriority);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1023, 60);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 11);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 12;
            label3.Text = "Text Box";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(326, 39);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 11;
            label2.Text = "Priority";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(557, 36);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 10;
            label1.Text = "Filter by Priority";
            // 
            // cmbFilterPriority
            // 
            cmbFilterPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPriority.FormattingEnabled = true;
            cmbFilterPriority.Items.AddRange(new object[] { "High", "Medium", "Low" });
            cmbFilterPriority.Location = new Point(653, 33);
            cmbFilterPriority.Name = "cmbFilterPriority";
            cmbFilterPriority.Size = new Size(62, 23);
            cmbFilterPriority.TabIndex = 9;
            cmbFilterPriority.Click += cmbFilterPriority_SelectedIndexChanged;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(733, 33);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(55, 23);
            btnAddTask.TabIndex = 8;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(3, 30);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(308, 23);
            txtTaskTitle.TabIndex = 4;
            txtTaskTitle.Text = "Title";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(446, 33);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(105, 23);
            dtpDueDate.TabIndex = 4;
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "High", "Medium", "Low" });
            cmbPriority.Location = new Point(377, 34);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(63, 23);
            cmbPriority.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1023, 450);
            Controls.Add(listViewTasks);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "To Do List by ValMarogi";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewTasks;
        private ColumnHeader column1;
        private ColumnHeader column2;
        private ColumnHeader column3;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Panel panel1;
        private Button btnDeleteTask;
        private Button btnMarkComplete;
        private Panel panel2;
        private TextBox txtTaskTitle;
        private ComboBox cmbPriority;
        private DateTimePicker dtpDueDate;
        private Button btnAddTask;
        private Label label1;
        private ComboBox cmbFilterPriority;
        private Label label2;
        private Label label3;
    }
}
