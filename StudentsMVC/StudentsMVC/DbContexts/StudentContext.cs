using StudentsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentsMVC.DbContexts
{
    public class StudentContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }

        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().ToTable("Student");

            modelBuilder.Entity<StudentModel>()
                .Property(s => s.Mark)
                .HasDefaultValue(0);
        }
    }
}
