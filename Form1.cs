using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateToDoList
{
    public partial class Form1 : Form
    {
        private FirestoreDb? firestoreDb;
        private List<TaskItem> allTasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Connect to the database using your key file
                string keyPath = AppDomain.CurrentDomain.BaseDirectory + "firebase-key.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyPath);

                // Ensure you have replaced this with your actual Project ID
                firestoreDb = FirestoreDb.Create("cse310-todolist");

                // Set defaults for UI controls
                cmbPriority.SelectedIndex = 1;
                cmbFilterPriority.SelectedIndex = 0;
                statusLabel.Text = "Loading tasks from cloud...";

                await LoadTasksAsync(); // Load tasks from the cloud
                statusLabel.Text = "Ready.";
            }
            catch (Exception ex)
            {
                // If anything goes wrong during startup, show a detailed error message
                MessageBox.Show($"Failed to connect to the database. Please check your firebase-key.json file and Project ID.\n\nError: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close the application since it cannot function without the database
                Application.Exit();
            }
        }

        private async Task LoadTasksAsync()
        {
            if (firestoreDb == null) return; // Don't run if the database connection failed

            allTasks.Clear();

            QuerySnapshot snapshot = await firestoreDb.Collection("tasks").GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                TaskItem task = document.ConvertTo<TaskItem>();
                allTasks.Add(task);
            }
            // --- ADD THIS LINE TO SORT THE TASKS ---
            allTasks = allTasks.OrderBy(task => task.OrderIndex).ToList();

            RefreshTaskList();
        }

        #region Core Task Actions (Add, Complete, Delete)

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            if (firestoreDb == null) return;
            string taskTitle = txtTaskTitle.Text.Trim();
            if (string.IsNullOrEmpty(taskTitle))
            {
                MessageBox.Show("Please enter a task title.", "Title Required");
                return;
            }

            string priority = cmbPriority.SelectedItem?.ToString() ?? "Medium";
            // Get the local time from the picker and convert it to UTC
            DateTime dueDateUtc = dtpDueDate.Value.ToUniversalTime();
            int newIndex = allTasks.Count; // The new task will be last in the list
            // Now, create the new task using the converted UTC date
            var newTask = new TaskItem(taskTitle, priority, dueDateUtc);

            await firestoreDb.Collection("tasks").Document(newTask.Id).SetAsync(newTask);

            allTasks.Add(newTask);
            RefreshTaskList();

            txtTaskTitle.Clear();
            statusLabel.Text = $"Task '{taskTitle}' added to cloud.";
        }

        private async void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (firestoreDb == null || listViewTasks.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = listViewTasks.SelectedItems[0];
            if (selectedItem != null && selectedItem.Tag is TaskItem task)
            {
                task.IsComplete = !task.IsComplete;

                DocumentReference docRef = firestoreDb.Collection("tasks").Document(task.Id);
                await docRef.SetAsync(task, SetOptions.Overwrite);

                UpdateTaskAppearance(selectedItem);
                statusLabel.Text = $"Task '{task.Title}' status updated in cloud.";
            }
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (firestoreDb == null || listViewTasks.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = listViewTasks.SelectedItems[0];
            if (selectedItem != null && selectedItem.Tag is TaskItem task)
            {
                DialogResult result = MessageBox.Show($"Delete '{task.Title}'?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await firestoreDb.Collection("tasks").Document(task.Id).DeleteAsync();

                    allTasks.Remove(task);
                    RefreshTaskList();
                    statusLabel.Text = $"Task '{task.Title}' deleted from cloud.";
                }
            }
        }

        #endregion

        #region UI and Data Handling (Refresh, Filter, Appearance)

        private void RefreshTaskList()
        {
            listViewTasks.BeginUpdate();
            listViewTasks.Items.Clear();

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

        #region Drag and Drop Logic

        private void listViewTasks_ItemDrag(object sender, ItemDragEventArgs e)
        {
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

        private async void listViewTasks_DragDrop(object sender, DragEventArgs e)
        {
            // Standard drag-drop setup code
            if (firestoreDb == null) return;
            ListViewItem? draggedItem = e.Data?.GetData(typeof(ListViewItem)) as ListViewItem;
            if (draggedItem == null) return;
            Point dropPoint = listViewTasks.PointToClient(new Point(e.X, e.Y));
            ListViewItem? targetItem = listViewTasks.GetItemAt(dropPoint.X, dropPoint.Y);
            if (targetItem == null || targetItem == draggedItem) return;

            // --- THIS IS THE CORRECTED LOGIC ---

            // Use 'as' for a safe cast. This will result in null if the cast fails.
            TaskItem? draggedTask = draggedItem.Tag as TaskItem;
            TaskItem? targetTask = targetItem.Tag as TaskItem;

            // Add a critical check: If either task is null, we can't proceed.
            if (draggedTask == null || targetTask == null)
            {
                return;
            }

            // --- END OF FIX ---

          
            int targetIndex = allTasks.IndexOf(targetTask);
            if (targetIndex < 0) return; // Safety check if target isn't in the list

            // Reorder the local list
            allTasks.Remove(draggedTask);
            allTasks.Insert(targetIndex, draggedTask);

            // Update OrderIndex and save to Firebase
            statusLabel.Text = "Saving new order to the cloud...";
            WriteBatch batch = firestoreDb.StartBatch();

            for (int i = 0; i < allTasks.Count; i++)
            {
                TaskItem task = allTasks[i];
                task.OrderIndex = i;

                DocumentReference docRef = firestoreDb.Collection("tasks").Document(task.Id);
                batch.Update(docRef, "OrderIndex", task.OrderIndex);
            }

            await batch.CommitAsync();

            RefreshTaskList();
            statusLabel.Text = "Task order saved.";
        }


        #endregion

        private void listViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}