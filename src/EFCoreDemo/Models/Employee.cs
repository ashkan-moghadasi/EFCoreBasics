using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
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
}
