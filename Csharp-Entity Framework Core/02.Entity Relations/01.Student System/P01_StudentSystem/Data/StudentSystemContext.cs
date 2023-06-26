using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
           : base(options)
        {

        }
        public virtual DbSet<Student> Students{ get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentsCourses{ get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Homework> Homeworks { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode();
                entity.Property(x=> x.PhoneNumber).IsUnicode(false);
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode();
                entity.Property(x => x.Description).IsUnicode();
            });
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode();
                entity.Property(x => x.Url).IsUnicode(false);
            });
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(x => x.Content).IsUnicode(false);
            });
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(x => new { x.StudentId, x.CourseId });
            });
                
        }

    }
}
