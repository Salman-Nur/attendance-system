using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
	public class GiveAttendance
	{
		public bool IsPresent(string courseName, string studentUsername)
		{
			AttendanceDbContext context = new();
			User user = context.Users.FirstOrDefault(s => s.Username == studentUsername && s.Type == "Student");
			DateTime currentDate = DateTime.Now;
			DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;
			Course course = context.Courses.FirstOrDefault(c => c.CourseName == courseName);
			if (course != null)
			{
				CourseStudent courseStudent = context.CourseStudents.FirstOrDefault(c => c.CourseId == course.Id && c.StudentId == user.Id);
				if (courseStudent != null)
				{
					ClassSchedule classSchedule = context.ClassSchedules.FirstOrDefault(c => c.CourseId == course.Id);
					if(classSchedule != null)
					{
						if (currentDate.Date < classSchedule.ClassStartDate)
						{
							Console.WriteLine($"The {courseName} Course is upcoming.");
							return false;
						}
						else if (currentDate.Date > classSchedule.ClassEndDate)
						{
							Console.WriteLine($"The {courseName} Course has ended.");
							return false;
						}
						List<string> daysOfWeek = classSchedule.DayOfWeek.Split(',').Select(day => day.ToLower()).ToList();
						string currentDay = currentDayOfWeek.ToString().ToLower();
						if (daysOfWeek.Contains(currentDay))
						{
							TimeSpan currentTime = DateTime.Now.TimeOfDay;
							if (currentTime >= classSchedule.ClassStartTime && currentTime <= classSchedule.ClassEndTime)
							{
								try
								{
									CourseAttendance courseAttendance = new();
									courseAttendance.CourseId = course.Id;
									courseAttendance.StudentId = user.Id;
									courseAttendance.AttendanceDate = currentDate;
									context.CourseAttendances.Add(courseAttendance);
									context.SaveChanges();
									Console.WriteLine("Attendance submitted.");
									return true;
								}
								catch
								{
                                    Console.WriteLine("Attendance already submitted.");
                                }

							}
							else
							{
								Console.WriteLine("It's not the class time.");
							}
						}
						else
						{
							Console.WriteLine($"Today there is no class of {courseName} Course.");
						}
					}				
					else
					{
						Console.WriteLine($"Class schedule not found for {courseName} course.");
					}
				}
				else
				{
					Console.WriteLine($"You are not enrolled in {courseName} course.");
				}
			}
			else
			{
				Console.WriteLine($"{courseName} Course not found.");
			}
			return false;
		}
	}
}

