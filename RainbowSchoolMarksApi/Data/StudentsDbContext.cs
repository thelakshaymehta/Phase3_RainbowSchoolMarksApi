using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RainbowSchoolMarksApi.Models;

namespace RainbowSchoolMarksApi.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext (DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;

        public DbSet<Subject>? Subject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
                new Student { Id = 2, Name = "Bob Smith", Email = "bob.smith@example.com"},
                new Student { Id = 3, Name = "Carol Taylor", Email = "carol.taylor@example.com"}
                // Add 9 more students
            );

            // Seed Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Mathematics", Credits = 4 },
                new Subject { Id = 2, Name = "English Literature", Credits = 3 },
                new Subject { Id = 3, Name = "Physics", Credits = 4 }
                // Add 9 more subjects
            );

            modelBuilder.Entity<StudentMark>().HasData(
                new StudentMark { Id = 1, StudentId = 1, SubjectId = 1, Marks = 85 },
                new StudentMark { Id = 2, StudentId = 1, SubjectId = 2, Marks = 92 },
                new StudentMark { Id = 3, StudentId = 2, SubjectId = 1, Marks = 78 }
                // Add 9 more student marks
            );
        }

        public DbSet<RainbowSchoolMarksApi.Models.StudentMark>? StudentMark { get; set; }

    }
}
