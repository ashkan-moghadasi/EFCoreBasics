using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
    public static class ExtensionMethods
    {
        public static async void PrintEmployee(this Employee? emp)
        {
            if (emp !=null)
            {
                await Console.Out.WriteLineAsync($"Welcome {emp.Id} {emp.FirstName} {emp.LastName} {emp.Address}");

            }

        }
    }
}
