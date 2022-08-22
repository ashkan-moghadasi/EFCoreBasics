using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using EFCoreDemo.InlineQuery;
namespace EFCoreDemo.InlineQuery;

public class CheckInlineQuery
{
    internal static Employee? GetEmployeeByName(string name)
    {

        var context = GetContext();
        var emp= context.Employees.FirstOrDefault(e =>
            e.FirstName.Equals(name));
        emp?.PrintEmployee();

        return emp;
    }
    internal static Employee GetEmployeeById(int id)
    {
        var context = GetContext();
        var provider = new EmployeeProvider(context);
        var emp = provider.GetEmployee(id);
        emp.PrintEmployee();
        return emp;
    }
    private static InlineQuery.EmployeeContext GetContext()
    {
        var connectionString = @"Data Source=.\sqlexpress;Initial Catalog=efcoredemo;Integrated Security=True;Pooling=False";
        var optionBuilder = new DbContextOptionsBuilder();
        optionBuilder.UseSqlServer(connectionString);
        
        return  new EmployeeContext(optionBuilder.Options);
        
    }
}