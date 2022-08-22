using EFCoreInWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInWebAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        private DbSet<Employee> Employees { get; set; }
    }
}
