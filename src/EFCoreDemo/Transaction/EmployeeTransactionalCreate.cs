using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemo.Context;
using EFCoreDemo.Models;

namespace EFCoreDemo.Transaction;

public static class EmployeeTransactionalCreate
{
    private static EmployeeContext GetContext()
    {
        var connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=efcoredemo;Integrated Security=True;Pooling=False";

        return new EmployeeContext(connectionString);
    }


    public static void Create()
    {
        EmployeeContext context = GetContext();
        Employee[] employees = new Employee[]
        {
            new Employee() { Id = 3, FirstName = "Ashkan", LastName = "Moghadasi" },
            new Employee() { Id = 4, FirstName = "ali", LastName = "rezayee" },
            new Employee() { Id = 5, FirstName = "Ashmohamad", LastName = "karimi" },
            new Employee() { Id = 6, FirstName = "sirvan", LastName = "khosravi" },
        };
        using var transaction = context.Database.BeginTransaction();
        try
        {
            foreach (var emp in employees)
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                emp.PrintEmployee();
            }

            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine(e);
        }
    }
}