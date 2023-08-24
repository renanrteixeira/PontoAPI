using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
//using Pomelo.EntityFrameworkCore.MySql;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PontoAPI.Infrastructure.Data;
using PontoAPI.Infrastructure.Application;
using PontoAPI.Core.Interface;
using PontoAPI.Web.Helpers;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString));
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

builder.Services.AddScoped<ITokenRepository<User>, TokenRepository>();

//regras
builder.Services.AddScoped<IApplication<Company>, CompanyApplication>();
builder.Services.AddScoped<IApplication<Employee>, EmployeeApplication>();
builder.Services.AddScoped<IApplication<Hour>, HourApplication>();
builder.Services.AddScoped<IApplication<Role>, RoleApplication>();
builder.Services.AddScoped<IApplication<TypeDate>, TypeDateApplication>();
builder.Services.AddScoped<IApplication<User>, UserApplication>();

builder.Services.AddScoped<ITokenApplication<User>, TokenApplication>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var key = Encoding.ASCII.GetBytes(Secret.SecretKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }); ;

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
