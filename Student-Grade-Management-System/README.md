# Student Grade Management System

A Windows Forms app for keeping track of student grades. You can add students, search for them, see class statistics, and remove records. I built it for my C# assignment on Dictionaries, enums and exception handling.

## Features

- Add a student with a name and a grade between 0 and 100
- View all students, sorted from highest grade to lowest
- Search for a student by name
- Remove a single student, or clear all records (it asks you to confirm first)
- Class average, highest and lowest grades, and the names of the top and bottom students
- Each grade gets a category automatically

## Grade categories

| Grade range | Category  |
|-------------|-----------|
| 90 - 100    | Excellent |
| 80 - 89     | Good      |
| 70 - 79     | Fair      |
| 60 - 69     | Pass      |
| Below 60    | Fail      |

## Input validation

- Grades outside 0-100 are rejected
- Empty names are rejected
- Searching for or removing a student who doesn't exist shows a message instead of crashing
- Non-numeric grade input is caught and handled
- Clear All asks for confirmation before deleting anything

## Setup

You need Windows and the .NET 6.0 SDK.

```bash
git clone https://github.com/kamyuwambaye/Student-Grade-Management-System.git
cd Student-Grade-Management-System
dotnet restore
dotnet build
dotnet run
```

The app window opens once it starts.

## Using the app

**Add a student:** type the name in the Student Name box, the grade in the Grade box, then click Add Student. The student shows up in the list.

**View everyone:** click Display All. Each entry shows the name, grade and category, with the highest grades at the top.

**Search:** type a name in the Search Name box and click Search. The result appears in the display area.

**Statistics:** Average shows the class average. Statistics shows the total number of students, the average, the highest and lowest grades, and who got them.

**Remove a student:** type their name in the Student Name box and click Remove.

**Clear everything:** click Clear All and confirm.

## Project structure
Student-Grade-Management-System/
├── Program.cs # Entry point
├── GradeManagementForm.cs # Main window and button handlers
├── GradeManager.cs # Grade logic
├── Student.cs # Student class with validation
├── GradeCategory.cs # Grade category enum
├── StudentGradeManagement.csproj # Project settings
└── README.md

## How it works

Built with C#, .NET 6.0 and Windows Forms. Students are stored in a `Dictionary` keyed by name, so lookups are quick.

`GradeManager` holds the logic and keeps it separate from the UI:

- `AddStudent()` adds a student or updates their grade if the name already exists
- `SearchStudent()` looks a student up by name
- `CalculateAverageGrade()` returns the class average
- `GetHighestGrade()` and `GetLowestGrade()` return the extremes
- `GetTopStudents()` and `GetLowestStudents()` return the students with those grades

`Student` stores the name and grade, validates them, and works out the category. `GradeCategory` is an enum with the five categories above.

## Assignment requirements covered

- Students stored in a dictionary
- Display, search, average, highest and lowest grade
- Error handling and exception handling
- Keyboard and UI input through a Windows Forms GUI
- Enums for grade categories
- Control flow and functions

## Possible improvements

- Save data to a file so it isn't lost when the app closes
- Track grade history over time
- Support multiple classes or sections
- Export reports as PDF
- Import student lists from Excel

## Author

kamyuwambaye
