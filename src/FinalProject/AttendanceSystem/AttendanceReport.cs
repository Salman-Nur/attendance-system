using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class AttendanceReport
	{
		public void CheckAttendance(string courseName)
		{
			List<DateTime> classDates = new();
			AttendanceDbContext context = new();
			Course course = context.Courses.FirstOrDefault(c => c.CourseName == courseName);
			if (course == null)
			{
				Console.WriteLine($"{courseName} Course not found.");
				return;
			}
			List<int> allStudentIds = context.CourseStudents
							.Where(c => c.CourseId == course.Id)
							.Select(c => c.StudentId)
							.ToList();
			if (allStudentIds.Count == 0)
			{
				Console.WriteLine($"No Student assigned in {courseName} Course");
				return;
			}
			List<int> attendStudentIds = context.CourseAttendances
				.Where(c => c.CourseId == course.Id)
				.Select(c => c.StudentId)
				.ToList();
			if (course != null)
			{
				ClassSchedule classSchedule = context.ClassSchedules.FirstOrDefault(c => c.CourseId == course.Id);
				if (classSchedule != null)
				{
					List<string> daysOfWeek = classSchedule.DayOfWeek.Split(',')
						.Select(day => day.Trim().ToLower()).ToList();
					List<DateTime> allClassDates = new();
					DateTime currentDate = classSchedule.ClassStartDate;
					while (currentDate <= classSchedule.ClassEndDate)
					{
						string currentDayOfWeek = currentDate.DayOfWeek.ToString().ToLower();
						if (daysOfWeek.Contains(currentDayOfWeek))
						{
							allClassDates.Add(currentDate);
						}
						currentDate = currentDate.AddDays(1);
					}
					Console.WriteLine($"Attendance report of {courseName} course.");
					Console.WriteLine();
					Console.Write("Student Name   ".PadRight(20));
					
					foreach (var classDate in allClassDates)
					{
						if (DateTime.Now >= classDate)
						{
							classDates.Add(classDate);
						}
						else
						{
							break;
						}
					}
					foreach (var classDate in classDates)
					{
						Console.Write($"{classDate:dd MMM}".PadRight(12));
					}
					Console.WriteLine();
					foreach (var studentId in allStudentIds)
					{
						User studentUser = context.Users.FirstOrDefault(u => u.Id == studentId);
						Console.Write($"{studentUser.Name}".PadRight(12));
						foreach (var classDate in classDates)
						{
							if (attendStudentIds.Contains(studentId) &&
								context.CourseAttendances.Any(c => c.CourseId == course.Id &&
								c.StudentId == studentId && c.AttendanceDate.Date == classDate.Date))
							{
								Console.Write($"          √".PadRight(12));
							}
							else if (!attendStudentIds.Contains(studentId) || context.CourseAttendances.Any(c => c.CourseId != course.Id))
							{
								Console.Write($"          X".PadRight(12));
							}
						}
						Console.WriteLine();
					}
				}
			}
		}
	}
}

