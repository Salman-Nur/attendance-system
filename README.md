# attendance-system

This console-based C# application is an attendance management system 
designed to streamline the process of tracking and managing attendance 
for small to medium-sized organizations. 
The system supports multiple user roles—Admin, Teacher, and Student—each with specific permissions and functionalities.

# How to run?
There is a migration just update it in database firstly.Then just run.

# Default User Accounts for Testing
# Admin
- Username: admin
- Password: 123456

# Features

# User Management:
1.Create Teachers (Name, Username, Password)
2.Create Students (Name, Username, Password)

# Course Management:
1.Create and manage Courses (Course Name, Fees)
2.Assign Teachers to Courses
3.Enroll Students in Courses

# Class Scheduling:
1.Set and manage Class Schedules for each course
2.Schedule consists of day, time, and total number of classes (e.g., Sunday 8PM-10PM, 20 Classes)
Teacher

# Attendance Reporting:
1.View attendance reports for courses they are assigned to
2.Reports include Student names and their attendance status (Present or Absent) for each class
Student

# Attendance Management:
1.Login to the system and mark attendance for courses they are enrolled in
2.Attendance can only be marked during scheduled class times

# Technology Stack
1. C#
2. .NET with Entity Framework
3. SQL Server for data persistence
