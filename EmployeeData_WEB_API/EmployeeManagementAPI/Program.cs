using DAL_Employee.Data_Access;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Options;
using DAL_Employee.Interface;
using DAL_Employee.Models;
using DAL_Employee.Repository;
using BAL_Employee.Business_Layer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DI for DBcontext
builder.Services.AddDbContext<EmployeeDbContext>(Options => 
Options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCon")));
builder.Services.AddTransient<IEmpRepository<Employee>, EmployeeRepository>();
builder.Services.AddTransient<EmployeesBAL, EmployeesBAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
