using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class Create
	{
		public void CreateTeacher(string name, string username, string password)
		{
			AttendanceDbContext context = new();
			if (string.IsNullOrWhiteSpace(username))
			{
				Console.WriteLine("Username can not be null.");
			}
			else if(context.Users.Any(c => c.Username == username))
			{
                Console.WriteLine("That Username is taken. Try another.");
            }
			else if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("Name can not be null.");
			}
			else if (string.IsNullOrWhiteSpace(password))
			{
				Console.WriteLine("Password can not be null.");
			}
			else
			{
				User newUser = new User { Name = name, Username = username, Password = password, Type = "Teacher" };
				context.Users.Add(newUser);
				context.SaveChanges();
				Console.WriteLine("Teacher created.");
			}
        }

		public void CreateCourse(string name, string fees)
		{
			double Fees = 0.0;
			if (string.IsNullOrWhiteSpace(fees))
			{
				Console.WriteLine("Fees can not be null");
				return;
			}
			else if (!double.TryParse(fees, out double invalidFees))
			{
				Console.WriteLine("Invalid fees. Not a valid double");
				return;
			}
			else
			{
				double.TryParse(fees, out double validFess);
				Fees = validFess;
			}
			AttendanceDbContext context = new();
			if (context.Courses.Any(c => c.CourseName == name))
			{
				Console.WriteLine("This Course is already created.");
			}
			else if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("Course Name can not be null");
			}
			else if (Fees < 0)
			{
                Console.WriteLine("Fees can not be negative");
            }
			else
			{
				context.Courses.Add(new Course { CourseName = name, Fees = Fees });
				context.SaveChanges();
				Console.WriteLine("Course created.");
			}
		}

		public void CreateStudent(string name, string username, string password)
		{
			AttendanceDbContext context = new();
			if (string.IsNullOrWhiteSpace(username))
			{
				Console.WriteLine("Username can not be null.");
			}
			else if(context.Users.Any(c => c.Username == username))
			{
                Console.WriteLine("That Username is taken. Try another.");
            }
			else if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("Name can not be null.");
			}
			else if (string.IsNullOrWhiteSpace(password))
			{
				Console.WriteLine("Password can not be null.");
			}
			else
			{
				User newUser = new User { Name = name, Username = username, Password = password, Type = "Student" };
				context.Users.Add(newUser);
				context.SaveChanges();
				Console.WriteLine("Student created.");
			}
		}
	}
}
