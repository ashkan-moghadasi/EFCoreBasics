using System.ComponentModel.DataAnnotations.Schema;
namespace EFCoreInWebAPI.Entities;

[Table("Employee")]
public class Employee
{

    public int Id { get; set; }
    [Column("empName")]
    public string FirstName { get; set; }

    [Column("empLastName")]
    public string LastName { get; set; }

    [Column("empAddress")]
    public string? Address { get; set; }
}