using EFCoreDemo.Context;
using EFCoreDemo.Models;
using EFCoreDemo.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.StoredProcedure;

public class EmployeeProvider : IEmployeeProvider
{
    private readonly EmployeeContext _context;

    public EmployeeProvider(EmployeeContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Employee GetEmployee(int id)
    {
       return _context.Employees.FromSqlRaw("Exec dbo.GetEmployeeById @id={0}", id).ToListAsync().Result.FirstOrDefault();
       
    }
}