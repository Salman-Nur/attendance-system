using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class CourseAttendance
	{
		public int CourseId { get; set; }
		public int StudentId { get; set; }
		public DateTime AttendanceDate { get; set; }
		public Course Course { get; set; }
		public User Student { get; set; }
	}
}
