using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HolmesglenStudentManagementSystem.EntityModels
{
    public class AppDBContext : DbContext
    {
        public DbSet<EntityStudent> Student { get; set; }
        public DbSet<EntitySubject> Subjects { get; set; }
        public DbSet<EntityEnrollment> Enrollments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\saint\Downloads\data-driven-at2-202220\HolmesglenStudentManagementSystem.db");
        }

    }
}
