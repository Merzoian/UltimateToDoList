using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UltimateToDoList
{
    public partial class Form1 : Form
    {
        private List<TaskItem> allTasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPriority.SelectedIndex = 1;
            cmbFilterPriority.SelectedIndex = 0;
            statusLabel.Text = "Welcome! Load existing tasks or create a new one.";
        }

        #region Core Task Actions (Add, Complete, Delete)

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskTitle = txtTaskTitle.Text.Trim();
            if (string.IsNullOrEmpty(taskTitle))
            {
                MessageBox.Show("Please enter a task title.", "Title Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // FIX: Safely get the selected priority. If nothing is selected, default to "Medium".
            string priority = cmbPriority.SelectedItem?.ToString() ?? "Medium";

            var newTask = new TaskItem(
                taskTitle,
                priority,
                dtpDueDate.Value
            );

            allTasks.Add(newTask);
            RefreshTaskList();

            txtTaskTitle.Clear();
            txtTaskTitle.Focus();
            statusLabel.Text = $"Task '{taskTitle}' added.";
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0) return;

            // FIX: Safely get the task object from the selected item's Tag property.
            if (listViewTasks.SelectedItems[0].Tag is TaskItem task)
            {
                task.IsComplete = !task.IsComplete;
                UpdateTaskAppearance(listViewTasks.SelectedItems[0]);
                statusLabel.Text = $"Task '{task.Title}' status updated.";
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0) return;

            // FIX: Safely get the task object.
            if (listViewTasks.SelectedItems[0].Tag is TaskItem task)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the task: '{task.Title}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    allTasks.Remove(task);
                    RefreshTaskList();
                    statusLabel.Text = $"Task '{task.Title}' deleted.";
                }
            }
        }

        #endregion

        #region UI and Data Handling (Refresh, Filter, Appearance)

        private void RefreshTaskList()
        {
            listViewTasks.BeginUpdate();
            listViewTasks.Items.Clear();

            // FIX: Safely get the filter string.
            string filter = cmbFilterPriority.SelectedItem?.ToString() ?? "All";

            var filteredTasks = allTasks.Where(task => filter == "All" || task.Priority == filter);

            foreach (var task in filteredTasks)
            {
                ListViewItem item = new ListViewItem(task.Title);
                item.SubItems.Add(task.Priority);
                item.SubItems.Add(task.DueDate.ToShortDateString());
                item.Tag = task;

                UpdateTaskAppearance(item);
                listViewTasks.Items.Add(item);
            }

            listViewTasks.EndUpdate();
        }

        private void cmbFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void UpdateTaskAppearance(ListViewItem item)
        {
            // FIX: Safely get the task object.
            if (item.Tag is TaskItem task)
            {
                if (task.IsComplete)
                {
                    item.ForeColor = Color.Gray;
                    item.Font = new Font(listViewTasks.Font, FontStyle.Strikeout);
                }
                else
                {
                    item.ForeColor = SystemColors.WindowText;
                    item.Font = new Font(listViewTasks.Font, FontStyle.Regular);
                }
            }
        }

        #endregion

        #region Save and Load Logic

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                sfd.Title = "Save Tasks File";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string json = JsonConvert.SerializeObject(allTasks, Formatting.Indented);
                    File.WriteAllText(sfd.FileName, json);
                    statusLabel.Text = $"Tasks saved to {Path.GetFileName(sfd.FileName)}";
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                ofd.Title = "Open Tasks File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string json = File.ReadAllText(ofd.FileName);

                    // FIX: Handle the case where the file might be empty or invalid.
                    var loadedTasks = JsonConvert.DeserializeObject<List<TaskItem>>(json);
                    if (loadedTasks != null)
                    {
                        allTasks = loadedTasks;
                        RefreshTaskList();
                        statusLabel.Text = $"Tasks loaded from {Path.GetFileName(ofd.FileName)}";
                    }
                    else
                    {
                        MessageBox.Show("Could not load tasks from the selected file.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Drag and Drop Logic

        private void listViewTasks_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // FIX: Check that e.Item is not null before starting the drag.
            if (e.Item != null)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void listViewTasks_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listViewTasks_DragDrop(object sender, DragEventArgs e)
        {
            // FIX: Add comprehensive null checks for all objects involved in the drag/drop.
            if (e.Data == null) return;

            Point cp = listViewTasks.PointToClient(new Point(e.X, e.Y));
            ListViewItem? dropTargetItem = listViewTasks.GetItemAt(cp.X, cp.Y);
            ListViewItem? draggedItem = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;

            if (draggedItem == null || dropTargetItem == null || draggedItem == dropTargetItem) return;

            if (draggedItem.Tag is TaskItem draggedTask && dropTargetItem.Tag is TaskItem targetTask)
            {
                int targetIndex = allTasks.IndexOf(targetTask);
                if (targetIndex >= 0)
                {
                    allTasks.Remove(draggedTask);
                    allTasks.Insert(targetIndex, draggedTask);
                    RefreshTaskList();
                    statusLabel.Text = "Task order updated.";
                }
            }
        }
        #endregion

        private void listViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTaskTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}