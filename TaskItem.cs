using System;

public class TaskItem
{
    // Initialize properties to a non-null default value.
    // string.Empty is a valid, non-null string.
    public string Title { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }

    // This empty constructor is now safe because the properties are initialized above.
    public TaskItem() { }

    // Updated constructor to include the due date.
    public TaskItem(string title, string priority, DateTime dueDate)
    {
        Title = title;
        Priority = priority;
        DueDate = dueDate;
        IsComplete = false;
    }
}