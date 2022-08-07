using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Models;

namespace EFCoreDemo.Repository
{
    internal interface IEmployeeRepo
    {
        Task<Employee> Create(int id, string firstName, string lastName,string address);
        Task<Employee> Update(Employee employee);
        void Delete(Employee employee);
    }
}
