using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class Delete
	{
		public void DeleteTeacher(string username)
		{
			AttendanceDbContext context = new();
			User user = context.Users.FirstOrDefault(u => u.Username == username && u.Type == "Teacher");
			if (string.IsNullOrWhiteSpace(username))
			{
				Console.WriteLine("Username can not be null.");
			}
			else if(user != null)
			{
				context.Users.Remove(user);
				context.SaveChanges();
                Console.WriteLine("Teacher Deleted.");
            }
			else
			{
                Console.WriteLine("Teacher not found.");
            }
		}

		public void DeleteStudent(string username)
		{
			AttendanceDbContext context = new();
			User user = context.Users.FirstOrDefault(u => u.Username == username && u.Type == "Student");
			if (string.IsNullOrWhiteSpace(username))
			{
				Console.WriteLine("Username can not be null.");
			}
			else if (user != null)
			{
				context.Users.Remove(user);
				context.SaveChanges();
				Console.WriteLine("Student Deleted.");
			}
			else
			{
				Console.WriteLine("Student not found.");
			}
		}

		public void DeleteCourse(string courseName)
		{
			AttendanceDbContext context = new();
			Course course = context.Courses.FirstOrDefault(u => u.CourseName == courseName);
			if (string.IsNullOrWhiteSpace(courseName))
			{
				Console.WriteLine("Course can not be null.");
			}
			else if (course != null)
			{
				context.Courses.Remove(course);
				context.SaveChanges();
				Console.WriteLine($"{courseName} Course Deleted.");
			}
			else
			{
				Console.WriteLine($"{courseName} Course not found.");
			}
		}
	}
}
