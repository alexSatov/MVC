﻿using StudentsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentsMVC.DbContexts
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Student>()
                .Property(s => s.Mark)
                .HasDefaultValue(0);
        }
    }
}
