using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class ClassSchedule
	{
		public int CourseId { get; set; }
		public int TotalClasses { get; set; }
		public DateTime ClassStartDate { get; set; }
		public DateTime ClassEndDate { get; set; }
		public TimeSpan ClassStartTime { get; set; }
		public TimeSpan ClassEndTime { get; set; }
		public string DayOfWeek { get; set; }
		public Course Course { get; set; }

	}
}
