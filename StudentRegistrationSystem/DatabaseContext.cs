using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem
{
    public class DatabaseContext : DbContext
    {
        public static readonly string workingDirectory = Directory.GetCurrentDirectory();

        public string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=" +
          Path.Combine(projectDirectory, "Database.db"));



        public DbSet<User> Users { get; set; }
        public DbSet<Student1> Students1 { get; set; }

        public DbSet<Module> Modules { get; set; }

    }
}
