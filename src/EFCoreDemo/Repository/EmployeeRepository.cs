using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Context;
using EFCoreDemo.Models;

namespace EFCoreDemo.Repository
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public  Employee Create(int id, string firstName, string lastName,string address)
        {
            var response = _context.Add(new Employee()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
           _context.SaveChanges();
            return response.Entity;   
        }

        public  Employee Update(Employee employee)
        {
            var response=_context.Update(employee);
             _context.SaveChanges();
            return response.Entity;
        }

        public  void Delete(Employee employee)
        {
              _context.Remove(employee);
               _context.SaveChangesAsync();

        }
    }
}
