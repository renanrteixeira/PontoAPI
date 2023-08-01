using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
//using Pomelo.EntityFrameworkCore.MySql;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PontoAPI.Infrastructure.Data;
using PontoAPI.Infrastructure.Application;
using PontoAPI.Core.Interface;
using PontoAPI.Web.Helpers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));
//Repositorios
builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Hour>, HourRepository>();
builder.Services.AddScoped<IRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IRepository<TypeDate>, TypeDateRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

//regras
builder.Services.AddScoped<IApplication<Company>, CompanyApplication>();
builder.Services.AddScoped<IApplication<Employee>, EmployeeApplication>();
builder.Services.AddScoped<IApplication<Hour>, HourApplication>();
builder.Services.AddScoped<IApplication<Role>, RoleApplication>();
builder.Services.AddScoped<IApplication<TypeDate>, TypeDateApplication>();
builder.Services.AddScoped<IApplication<User>, UserApplication>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
