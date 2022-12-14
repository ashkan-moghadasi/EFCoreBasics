using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Context;
using EFCoreDemo.Models;
using EFCoreDemo.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Tests
{
    internal static class CrudTester
    {
        
         internal static  Employee GetEmployee(int id)
         {
             var context = GetContext();
             var provider = new EmployeeProvider(context);
             var emp= provider.GetEmployee(id);
             emp?.PrintEmployee();
             return emp;
         }
        
        internal static  void CreateEmployee()
         {
             var context = GetContext();
             var repo = new EmployeeRepository(context);
             var newEmp= repo.Create(2, "ashkan", "moghadasi", "address");
             newEmp.PrintEmployee();
         }
         internal static  void UpdateEmployee()
         {
             var emp2 =  GetEmployee(2);
             var context = GetContext();
             var repo = new EmployeeRepository(context);
             if (emp2 != null)
             {
                 emp2.FirstName = "NewName";
                 var newEmp =  repo.Update(emp2);
                 newEmp.PrintEmployee();
             }
         }


        private static EmployeeContext GetContext()
         {
             var connectionString = @"Data Source=.\sqlexpress;Initial Catalog=efcoredemo;Integrated Security=True;Pooling=False";
             return new EmployeeContext(connectionString);
             
        }
    }
}
