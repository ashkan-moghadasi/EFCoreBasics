using EFCoreInWebAPI;
using EFCoreInWebAPI.Entities;
using EFCoreInWebAPI.Models;
using EFCoreInWebAPI.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

//var connectionString = builder.Configuration.GetConnectionString("DataBase");
//builder.Services.EFNormalConfig(connectionString);
builder.Services.EfAdvancedConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapGet("/Employees/{id:int}", async (int id, EmployeeContext dbContext) =>
{
    var emp = await dbContext
        .Set<Employee>()
        //Increase Performance with Disabling Tracking
        .AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id == id);
    if (emp is null)
    {
        return Results.NotFound($"Employee with Id:'{id}' Not Found");
    }

    var response = new EmployeeResponse(emp.Id, emp.FirstName, emp.LastName);
    return Results.Ok(response);
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}