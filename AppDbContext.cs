using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Sqlite;
using miniprojectfinal.Models;

namespace miniprojectfinal.DataServices
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlite("Data Source=miniprojectfinal.db");
               
            }
        }
    }
}