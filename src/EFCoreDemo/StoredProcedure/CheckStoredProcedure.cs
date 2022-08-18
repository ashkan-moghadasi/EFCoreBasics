using EFCoreDemo.Context;
using EFCoreDemo.Models;
namespace EFCoreDemo.StoredProcedure;

public class CheckStoredProcedure
{
    internal static Employee GetEmployeeById(int id)
    {
        var context = GetContext();
        var provider = new EmployeeProvider(context);
        var emp = provider.GetEmployee(id);
        emp.PrintEmployee();
        return emp;
    }
    private static EmployeeContext GetContext()
    {
        var connectionString = @"Data Source=.\sqlexpress;Initial Catalog=efcoredemo;Integrated Security=True;Pooling=False";
        
        return  new EmployeeContext(connectionString);
        
    }
}