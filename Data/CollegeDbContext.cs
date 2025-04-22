using CollegeApp.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data;

public class CollegeDbContext : DbContext
{
    public CollegeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Marks> Marks { get; set; }

    // set unique key
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Applicant>()
            .HasIndex(b => b.AadharNo)
            .IsUnique();

        modelBuilder.Entity<Student>()
            .HasIndex(b => b.AadharNo)
            .IsUnique();

        modelBuilder.Entity<Applicant>()
            .HasIndex(b => b.Email)
            .IsUnique();

        modelBuilder.Entity<Student>()
            .HasIndex(b => b.Email)
            .IsUnique();

        modelBuilder.Entity<Department>()
            .HasIndex(b => b.Name)
            .IsUnique();

        modelBuilder.Entity<Marks>()
            .HasIndex(b => b.StudentId)
            .IsUnique();
    }
}