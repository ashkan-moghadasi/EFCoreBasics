using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Context;
using EFCoreDemo.Models;
using EFCoreDemo.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.InlineQuery
{
    internal class EmployeeProvider : IEmployeeProvider
    {
        private readonly EmployeeContext _context;

        public EmployeeProvider(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Employee GetEmployee(int id)
        {
            return _context.Employees
                .FromSqlRaw("SELECT Id,empName,empLastName, empAddress FROM dbo.Employee where Id={0}", id)
                .FirstOrDefaultAsync().Result;
        }
    }
}
