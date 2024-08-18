# attendance-system

This console-based C# application is an attendance management system 
designed to streamline the process of tracking and managing attendance 
for small to medium-sized organizations. 
The system supports multiple user roles—Admin, Teacher, and Student—each with specific permissions and functionalities.

# How to run?
There is a migration just update it in database firstly.Then just run.

# Default User Accounts for Testing
# Admin
- Username:admin
- Password:123456

# Features

# Admin

# User Management:
Create Teachers (Name, Username, Password)
Create Students (Name, Username, Password)

# Course Management:
Create and manage Courses (Course Name, Fees)
Assign Teachers to Courses
Enroll Students in Courses

# Class Scheduling:
Set and manage Class Schedules for each course
Schedule consists of day, time, and total number of classes (e.g., Sunday 8PM-10PM, 20 Classes)
Teacher

# Attendance Reporting:
View attendance reports for courses they are assigned to
Reports include Student names and their attendance status (Present or Absent) for each class
Student

# Attendance Management:
Login to the system and mark attendance for courses they are enrolled in
Attendance can only be marked during scheduled class times

# Technology Stack
Programming Languag : C#
Framework: .NET with Entity Framework
Database: SQL Server for data persistence