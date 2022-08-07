
using EFCoreDemo.Models;
using EFCoreDemo.Tests;

var emp1= CrudTester.GetEmployee(1);
emp1.PrintEmployee();


CrudTester.CreateEmployee();

CrudTester.UpdateEmployee();

