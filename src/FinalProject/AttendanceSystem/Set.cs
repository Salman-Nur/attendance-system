using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class Set
	{
		public void SetClassSchedule(string courseName, DateTime classStartDate,
			                        DateTime classEndDate, TimeSpan classStartTime,
									TimeSpan classEndTime, List<string> daysOfWeek,
									int totalClass)
		{
			AttendanceDbContext context = new();
			Course course = context.Courses.FirstOrDefault(c => c.CourseName == courseName);
			
			if(course != null)
			{
				ClassSchedule classSchedule = new();
				classSchedule.CourseId = course.Id;
				classSchedule.TotalClasses = totalClass;
				classSchedule.ClassStartDate = classStartDate;
				classSchedule.ClassEndDate = classEndDate;
				classSchedule.ClassStartTime = classStartTime;
				classSchedule.ClassEndTime = classEndTime;
				classSchedule.DayOfWeek = string.Join(",", daysOfWeek);
				context.ClassSchedules.Add(classSchedule);
				context.SaveChanges();
				Console.WriteLine("Class Schedule Set.");
			}
		}
	}
}