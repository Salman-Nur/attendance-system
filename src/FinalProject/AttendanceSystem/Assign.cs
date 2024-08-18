using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AttendanceSystem;

namespace AttendanceSystem
{
	public class Assign
	{
		public void AssignTeacher(string courseName, string userName)
		{
			AttendanceDbContext context = new();
			Course course = context.Courses.FirstOrDefault(c => c.CourseName == courseName);
			if (course != null)
			{
				User user = context.Users.FirstOrDefault(u => u.Username == userName && u.Type == "Teacher");
				if (user != null)
				{
					if (context.CourseTeachers.Any(c => c.CourseId == course.Id))
					{
						Console.WriteLine($"Teacher is already assigned to the {courseName} Course.");
					}
					else
					{
						CourseTeacher courseTeacher = new();
						courseTeacher.CourseId = course.Id;
						courseTeacher.TeacherId = user.Id;
						context.CourseTeachers.Add(courseTeacher);
						context.SaveChanges();
						Console.WriteLine($"Teacher assigned to {courseName} Course.");
					}
				}
				else
				{
					Console.WriteLine("Teacher not found.");
				}
			}
			else
			{
				Console.WriteLine($"{courseName} Course not found.");
			}
		}


		public void AssignStudents(string courseName, List<string> userNames)
		{
			AttendanceDbContext context = new();
			Course course = context.Courses.FirstOrDefault(c => c.CourseName == courseName);
			if (course != null)
			{
				foreach (string userName in userNames)
				{
					User user = context.Users.FirstOrDefault(u => u.Username == userName && u.Type == "Student");
					if (user != null)
					{
						bool isAssigned = context.CourseStudents.Any(c => c.CourseId == course.Id && c.StudentId == user.Id);
						if (!isAssigned)
						{
							CourseStudent courseStudent = new();
							courseStudent.CourseId = course.Id;
							courseStudent.StudentId = user.Id;
							context.CourseStudents.Add(courseStudent);
							context.SaveChanges();
							Console.WriteLine($"{userName} assigned to {courseName} Course.");
						}
						else
						{
							Console.WriteLine($"{userName} is already assigned to {courseName} Course.");
						}
					}
					else
					{
						Console.WriteLine($"'{userName}' not found in Students.");
					}
				}
			}
			else
			{
				Console.WriteLine($"{courseName} Course not found.");
			}
		}
	}
}