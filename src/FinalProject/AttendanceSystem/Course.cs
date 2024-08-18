using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class Course
	{
		public int Id { get; set; }
		public string CourseName { get; set; }
		public double Fees { get; set; }
		public CourseTeacher CourseTeachers { get; set; }
		public List<CourseStudent> CourseStudents { get; set; }
		public ClassSchedule ClassSchedule { get; set; }
		public List<CourseAttendance> CourseAttendance { get; set; }
	}
}