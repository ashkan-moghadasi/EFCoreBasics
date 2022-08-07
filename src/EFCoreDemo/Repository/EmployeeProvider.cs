using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Context;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Repository;

internal class EmployeeProvider:IEmployeeProvider
{
    private readonly EmployeeContext _employeeContext;

    public EmployeeProvider(EmployeeContext employeeContext)
    {
        _employeeContext = employeeContext;
    }
    public  Employee? GetEmployee(int id)
    {
       return  _employeeContext.Employees.FirstOrDefault( e=> e.Id == id);
    }
}