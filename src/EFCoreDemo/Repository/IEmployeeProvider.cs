using EFCoreDemo.Models;

namespace EFCoreDemo.Repository;

internal interface IEmployeeProvider
{
    Task<Employee?> GetEmployee(int id);
}