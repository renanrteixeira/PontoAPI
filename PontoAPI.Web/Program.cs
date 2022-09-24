using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
//using Pomelo.EntityFrameworkCore.MySql;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PontoAPI.Infrastructure.Data;
using PontoAPI.Infrastructure.Interface;
using PontoAPI.Application.Application;
using PontoAPI.Application.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Repositorios
builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();
builder.Services.AddScoped<IRepository<Employe>, EmployeRepository>();
builder.Services.AddScoped<IRepository<Hour>, HourRepository>();
builder.Services.AddScoped<IRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IRepository<TypeDate>, TypeDateRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
//regras
builder.Services.AddScoped<IApplication<Company>, CompanyApplication>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
