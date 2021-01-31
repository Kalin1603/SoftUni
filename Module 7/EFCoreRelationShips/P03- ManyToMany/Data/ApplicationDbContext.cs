namespace P03__ManyToMany.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03__ManyToMany.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }

        public virtual DbSet<StudentExam> StudentExams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=examsDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentExam>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ExamId });
            });
        }
    }
}
