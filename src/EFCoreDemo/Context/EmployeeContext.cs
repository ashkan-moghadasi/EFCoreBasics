using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Context
{
    public class EmployeeContext : DbContext
    {
        private readonly string _connectionString;

        public EmployeeContext(string connectionString)
        {
            _connectionString = connectionString;
            
        }
        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: _connectionString);
        }
    }
}
