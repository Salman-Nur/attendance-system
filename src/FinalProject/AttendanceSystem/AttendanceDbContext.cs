using AttendanceSystem;
using AttendanceSystem.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class AttendanceDbContext : DbContext
    {
        private readonly string _connectionString;
        public AttendanceDbContext()
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=AttendanceSystem;User Id=salman;Password=123456;TrustServerCertificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(AdminSeed.user);

            modelBuilder.Entity<CourseTeacher>()
                .HasKey(c => new { c.CourseId, c.TeacherId });

            modelBuilder.Entity<CourseStudent>()
                .HasKey(c => new { c.CourseId, c.StudentId });

            modelBuilder.Entity<ClassSchedule>()
                .HasKey(c => c.CourseId);

            modelBuilder.Entity<ClassSchedule>()
		        .Property(c => c.ClassStartDate)
		        .HasColumnType("date");

			modelBuilder.Entity<ClassSchedule>()
				.Property(c => c.ClassEndDate)
				.HasColumnType("date");

            modelBuilder.Entity<CourseAttendance>()
                .HasKey(c => new { c.CourseId, c.StudentId, c.AttendanceDate });

			modelBuilder.Entity<CourseAttendance>()
				.Property(c => c.AttendanceDate)
				.HasColumnType("date");

			base.OnModelCreating(modelBuilder);
		}
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get;set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
		public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<CourseAttendance> CourseAttendances { get; set; }
	}
}