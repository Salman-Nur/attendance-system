using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class Login
	{
		public bool LoginAdmin(string username, string password)
		{
			AttendanceDbContext context = new();
			User user = context.Users.Where(x => x.Id == 1).FirstOrDefault();
			if (user.Username == username && user.Password == password && user.Type == "Admin")
				return true;
			return false;
		}

		public bool LoginStudent(string username, string password)
		{
			bool result = false;
			AttendanceDbContext context = new();
			List<User> users = context.Users.ToList();
			foreach(var user in users)
			{
				if (user.Username == username && user.Password == password && user.Type == "Student")
				{
					result = true;
					break;
				}
			}
			return result;
		}

		public bool LoginTeacher(string username, string password)
		{
			bool result = false;
			AttendanceDbContext context = new();
			List<User> users = context.Users.ToList();
			foreach (var user in users)
			{
				if (user.Username == username && user.Password == password && user.Type == "Teacher")
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}
}
