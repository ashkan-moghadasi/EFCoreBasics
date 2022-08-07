using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Context;
using EFCoreDemo.Models;

namespace EFCoreDemo.Repository
{
    internal class EmployeeRepo:IEmployeeRepo
    {
        private readonly EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee> Create(int id, string firstName, string lastName,string address)
        {
            var response =await _context.AddAsync(new Employee()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
             await  _context.SaveChangesAsync();
            return response.Entity;   
        }

        public async Task<Employee> Update(Employee employee)
        {
            var response=_context.Update(employee);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async void Delete(Employee employee)
        {
              _context.Remove(employee);
              await _context.SaveChangesAsync();

        }
    }
}
