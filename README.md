# CSE 310: Cloud-Connected Task Manager (C#)

This project is a Desktop To-Do List Application created for CSE 310. It was built using C# and Windows Forms within the Visual Studio environment. The application functions as a personal task manager, designed to help users efficiently track their daily and long-term responsibilities.

In a significant revision, this application has been upgraded to use **Google Firestore** for all data storage. This provides a robust, real-time, cloud-based backend, ensuring data is persistent and synced.

---

## 📌 Features

* **Task Management**: Create tasks with a title, priority level (High, Medium, Low), and a due date.
* **Cloud Persistence**: All task data is automatically saved, updated, and deleted in a **Google Firestore** cloud database in real-time.
* **View and Update**: View the task list in a clean UI, mark tasks as complete, and delete them, with all changes instantly reflected in the cloud.
* **Filtering**: Filter the active task list by priority (e.g., show only "High" priority tasks).
* **Drag-and-Drop**: Dynamically reorder tasks in the list to match your preferences.

---

## 🧠 Technology & Concepts Learned

* **Languages & Frameworks**: C#, .NET, Windows Forms
* **Cloud Services**: Google Firebase / Firestore (NoSQL Database)
* **Key Concepts**:
    * Connecting a desktop application to a cloud backend.
    * Using **`async/await`** to handle asynchronous network operations without freezing the UI.
    * Performing CRUD (Create, Read, Update, Delete) operations against a NoSQL database.
    * Managing dependencies and libraries with the `Google.Cloud.Firestore` NuGet package.

---

## 🚀 Getting Started

### Prerequisites

* Windows 10 or later
* [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET Desktop Development** workload.
* An active internet connection.
* A Google account to create a Firebase project.

### How to Run

1.  **Set Up Firebase:**
    * Create a new project in the [Google Firebase Console](https://firebase.google.com/).
    * Create a **Firestore Database** in your project (start in **test mode**).
    * Go to **Project Settings -> Service accounts** and **generate a new private key**. This will download a JSON key file.
2.  **Configure the Project:**
    * Clone this repository to your local machine.
    * Rename the downloaded key file to `firebase-key.json` and place it in the project's output directory (`bin/Debug/...`).
    * Open `Form1.cs` and replace the placeholder `"YOUR_PROJECT_ID_HERE"` with your actual Firebase Project ID.
3.  **Run in Visual Studio:**
    * Open the `UltimateToDoList.sln` file in Visual Studio 2022.
    * Right-click the solution and choose **"Restore NuGet Packages"**.
    * Click **Start** or press `F5` to build and run the app.

---

## 🎥 Demo Video
▶️ **[Click here to watch the demo](https://youtu.be/YOUR_VIDEO_LINK_HERE)**  
Duration: 2–3 minutes  
Includes: Overview, feature demo, and what I learned.

---

## 🧑‍💻 Author

* **Val Marogi**
* This project was created for educational purposes for CSE 310.