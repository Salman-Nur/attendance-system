

using AttendanceSystem;
using System.Globalization;

AttendanceDbContext context = new();
bool loggedIn = false;
string name = string.Empty;
string username = string.Empty;
string password = string.Empty;
string courseName = string.Empty;
while (!loggedIn)
{
	Console.Write("Enter Username : ");
	username = Console.ReadLine();
	Console.Write("Enter Password : ");
	password = Console.ReadLine();
	Login login = new();

	if (login.LoginAdmin(username, password))
	{
		bool b = true;
		while (b)
		{
			Console.WriteLine();
			Console.WriteLine("1.Create Teacher.");
			Console.WriteLine("2.Create Course.");
			Console.WriteLine("3.Create Student.");
			Console.WriteLine("4.Assign Teacher in a Course.");
			Console.WriteLine("5.Assign Students in a Course.");
			Console.WriteLine("6.Set class Schedule for a Course.");
			Console.WriteLine("7.Delete Teacher.");
			Console.WriteLine("8.Delete Student.");
			Console.WriteLine("9.Delete Course.");
			Console.WriteLine("10.Logout.");
			Console.WriteLine();
			string? input = Console.ReadLine();
			switch (input)
			{
				case "1":
					{
						Console.Write("Enter Teacher Name : ");
						name = Console.ReadLine();
						Console.Write("Enter Teacher Username : ");
						username = Console.ReadLine();
						Console.Write("Enter Teacher Password : ");
						password = Console.ReadLine();
						Create createTeacher = new();
						createTeacher.CreateTeacher(name, username, password);  
						break;
					}

				case "2":
					Console.Write("Enter Course Name : ");
					name = Console.ReadLine();
					Console.Write("Enter Fees : ");
					string fees = Console.ReadLine();
					Create createCourse = new();
					createCourse.CreateCourse(name, fees);
					break;

				case "3":
					Console.Write("Enter Student Name : ");
					name = Console.ReadLine();
					Console.Write("Enter Student Username : ");
					username = Console.ReadLine();
					Console.Write("Enter Student Password : ");
					password = Console.ReadLine();
					Create createStudent = new();
					createStudent.CreateStudent(name, username, password);
					break;

				case "4":
					Console.Write("Enter Course Name : ");
					courseName = Console.ReadLine();
					Console.Write("Enter a Teacher Username : ");
					username = Console.ReadLine();
					Assign assignTeacher = new();
					assignTeacher.AssignTeacher(courseName, username);
					break;

				case "5":
					Console.Write("Enter Course Name : ");
					courseName = Console.ReadLine();
					Console.Write("Enter Students Username separated by comma(,) : ");
					List<string> studentsUsername = new(Console.ReadLine().Split(','));
					Assign assignStudent = new();
					assignStudent.AssignStudents(courseName, studentsUsername);
					break;

				case "6":
					DateTime classStartDate = new();
					DateTime classEndDate = new();
					string enteredClassStartTime = string.Empty;
					string enteredClassEndTime = string.Empty;
					Console.Write("Enter Course Name : ");
					courseName = Console.ReadLine();
					Course course = context.Courses.FirstOrDefault(c => c.CourseName == courseName);
					if (string.IsNullOrWhiteSpace(courseName))
					{
                        Console.WriteLine("Course name can not be null.");
						break;
                    }
					else if (course == null)
					{
						Console.WriteLine($"{courseName} Course not found.");
						break;
					}
					else if (context.ClassSchedules.Any(c => c.CourseId == course.Id))
					{
						Console.WriteLine("Class Schedule is already set for this Course.");
						break;
					}
					Console.Write("Enter Total Number Of Classes : ");
					string classes = Console.ReadLine();
					int totalClasses;
					if(string.IsNullOrWhiteSpace(classes))
					{
						Console.WriteLine("Invalid input");
						break;
					}
					else if(int.TryParse(classes, out totalClasses))
					{
						if (totalClasses <= 0)
						{
							Console.WriteLine("Total classes must be a positive integer.");
							break;
						}
					}
					else
					{
						Console.WriteLine("Number of total classes must be integer.");
						break;
					}
					try
					{
						Console.Write("Enter Class Start Date (month/day/year) : ");
						classStartDate = DateTime.Parse(Console.ReadLine());
						Console.Write("Enter Class End Date (month/day/year) : ");
						classEndDate = DateTime.Parse(Console.ReadLine());
						try
						{
							Console.Write("Enter Class Start Time (hh:mm tt) : ");
							enteredClassStartTime = Console.ReadLine();
							Console.Write("Enter Class End Time (hh:mm tt) : ");
							enteredClassEndTime = Console.ReadLine();
							DateTime startTime = DateTime.ParseExact(enteredClassStartTime, "h:mm tt",
															CultureInfo.InvariantCulture);
							DateTime endTime = DateTime.ParseExact(enteredClassEndTime, "h:mm tt",
																	CultureInfo.InvariantCulture);
							TimeSpan classStartTime = startTime.TimeOfDay;
							TimeSpan classEndTime = endTime.TimeOfDay;
							Console.Write("Enter Days of week separated by comma(,) : ");
							List<string> daysOfWeek = new(Console.ReadLine().Split(','));
							Set set = new();
							set.SetClassSchedule(courseName, classStartDate,
												classEndDate, classStartTime,
												classEndTime, daysOfWeek,
												totalClasses);
						}
						catch
						{
							Console.WriteLine("Invalid format. Please enter time in the correct format.");
						}
					}
					catch
					{
						Console.WriteLine("Invalid format. Please enter date in the correct format.");
						break;
					}
					
					break;

				case "7":
					{
						Console.Write("Enter Teacher Username : ");
						username = Console.ReadLine();
						Delete deleteTeacher = new();
						deleteTeacher.DeleteTeacher(username);
						break;
					}

				case "8":
					{
						Console.Write("Enter Student Username : ");
						username = Console.ReadLine();
						Delete deleteStudent = new();
						deleteStudent.DeleteStudent(username);
						break;
					}

				case "9":
					{
						Console.Write("Enter Course Name : ");
						courseName = Console.ReadLine();
						Delete deleteCourse = new();
						deleteCourse.DeleteCourse(courseName);
						break;
					}

				case "10":
					b = false;
					break;

				default:
					Console.WriteLine("Invalid Input.");					
					break;
			}
		}
	}



	else if (login.LoginStudent(username, password))
	{
		while (true)
		{
			Console.WriteLine();
			Console.WriteLine("1.Give Attendance.");
			Console.WriteLine("2.Logout.");
			Console.WriteLine();
			string? input = Console.ReadLine();
			if (input == "1")
			{
				Console.Write("Enter Course Name : ");
				courseName = Console.ReadLine();
				GiveAttendance giveAttendance = new();
				giveAttendance.IsPresent(courseName, username);
			}
			else if (input == "2")
			{
				break;
			}
			else
			{
				Console.WriteLine("Invalid input.");
			}
		}
	}



	else if (login.LoginTeacher(username, password))
	{
		while (true)
		{
			Console.WriteLine();
			Console.WriteLine("1.Check Attendance Report.");
			Console.WriteLine("2.Logout.");
			Console.WriteLine();
			string? input = Console.ReadLine();
			if (input == "1")
			{
				Console.Write("Enter Course Name : ");
				courseName = Console.ReadLine();
				AttendanceReport attendanceReport = new();
				attendanceReport.CheckAttendance(courseName);
			}
			else if (input == "2")
			{
				break;
			}
			else
			{
				Console.WriteLine("Invalid input.");
			}
		}
	}


	else
	{
		Console.WriteLine("Invalid Username or Password. Try again.");
		Console.WriteLine();
	}
}