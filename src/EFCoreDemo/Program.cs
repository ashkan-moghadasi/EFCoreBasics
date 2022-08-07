

using EFCoreDemo.Context;
using EFCoreDemo.Repository;

var connectionString = @"Data Source=.\sqlexpress;Initial Catalog=efcoredemo;Integrated Security=True;Pooling=False";
var context = new EmployeeContext(connectionString);
var provider=new EmployeeProvider(context);
var emp=await provider.GetEmployee(1);
Console.WriteLine($"Welcome {emp.Id} {emp.FirstName} {emp.LastName} {emp.Address}");

var repo=new EmployeeRepo(context);
var emp2 =await repo.Create(2, "ashkan", "moghadasi", "My Address");
emp2.FirstName = "newname";
var emp3 = await repo.Update(emp2);
Console.WriteLine($"Welcome {emp3.Id} {emp3.FirstName} {emp3.LastName} {emp3.Address}");

