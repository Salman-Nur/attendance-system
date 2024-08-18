using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class User
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public List<CourseTeacher> Courseteachers { get; set; }
		public List<CourseStudent> CourseStudents { get; set; }
		public List<CourseAttendance> CourseAttendances { get; set; }
	}
}
