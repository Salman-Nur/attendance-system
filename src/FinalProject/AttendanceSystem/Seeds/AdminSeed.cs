using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Seeds
{
	public static class AdminSeed
	{
		public static User user = new User()
		{
			Id = 1,
			Type = "Admin",
			Name = "Salman Nur",
			Username = "admin",
			Password = "123456"
		};
	}
}
