# 📝 Windows Forms Task Manager (C#)

This project is a Desktop To-Do List Application created for CSE 310. It was built using C# and Windows Forms within the Visual Studio environment. The application functions as a personal task manager, designed to help users efficiently track their daily and long-term responsibilities.

---

## 📌 Features

### ✅ Core Features
- Add tasks with:
  - Title
  - Priority (Low, Medium, High)
  - Due Date
- View task list in a clean, responsive UI
- Mark tasks as completed or incomplete
- Delete tasks from the list

### 💾 Persistence
- All tasks are automatically **saved to a JSON file** (`tasks.json`)
- Tasks are **loaded back** when the app restarts

### 🔍 Filtering
- Filter tasks by selected **priority** (e.g., show only "High" priority tasks)

### 📅 Optional Stretch Features
- Due date support per task
- Sort tasks by due date (optional for future)
- Ready for extension: sorting, drag-and-drop, or tagging

---

## 🧠 What I Learned
- How to use Windows Forms in Visual Studio 2022
- Structuring code using C# classes and event-driven programming
- Saving/loading structured data using `System.Text.Json`
- Building reusable and readable UI logic

---

## 🚀 Getting Started

### Prerequisites
- Windows 10 or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with **.NET Desktop Development**

### How to Run
1. Open `TaskManagerApp.sln` in Visual Studio 2022
2. Click **Start** or press `F5` to run the app
3. Add tasks, filter by priority, mark complete, and see them saved in `tasks.json`

---

## 📂 Folder Structure
/TaskManagerApp

├── Form1.cs

├── TaskItem.cs

├── tasks.json ← created automatically at runtime

├── Form1.Designer.cs

├── Form1.resx

├── README.md



---

## 🎥 Demo Video
▶️ **[Click here to watch the demo](https://youtu.be/EFYzxFpNCPE)**  
Duration: 2–3 minutes  
Includes: Overview, feature demo, and what I learned.

---

## 🧑‍💻 License
This is made/used for learning preposes.
