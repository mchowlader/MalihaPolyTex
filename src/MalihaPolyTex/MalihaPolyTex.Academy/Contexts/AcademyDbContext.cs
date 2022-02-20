using MalihaPolyTex.Academy.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Contexts
{
    public class AcademyDbContext : DbContext, IAcademyDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public AcademyDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder )
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring( dbContextOptionsBuilder );
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
    }
}
