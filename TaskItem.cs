using Google.Cloud.Firestore; // Add this using statement
using System;

[FirestoreData] // Add this attribute
public class TaskItem
{
    [FirestoreProperty] // This attribute is for the ID
    public string Id { get; set; } = string.Empty;

    [FirestoreProperty] // Add this attribute to all properties
    public string Title { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Priority { get; set; } = string.Empty;

    [FirestoreProperty]
    public DateTime DueDate { get; set; }

    [FirestoreProperty]
    public bool IsComplete { get; set; }

    // --- ADD THIS NEW PROPERTY ---
    [FirestoreProperty]
    public int OrderIndex { get; set; }
    // ----------------------------

    public TaskItem() { }

    public TaskItem(string title, string priority, DateTime dueDate)
    {
        // Generate a new, unique ID for every new task
        Id = Guid.NewGuid().ToString();
        Title = title;
        Priority = priority;
        DueDate = dueDate;
        IsComplete = false;
    }
}