using EFCoreDemo.Models;

namespace EFCoreDemo.Repository;

internal interface IEmployeeProvider
{
    Employee GetEmployee(int id);
}