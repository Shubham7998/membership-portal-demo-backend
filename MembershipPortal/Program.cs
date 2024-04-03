using MembershipPortal.Data;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
using MembershipPortal.Repositories;
using MembershipPortal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("connectionStringPooja");

builder.Services.AddDbContext<MembershipPortalDbContext>(options => options.UseSqlServer(connectionString));    

builder.Services.AddScoped<IUserService ,UserService> ();
builder.Services.AddScoped<IUserRepository , UserRepository>();


builder.Services.AddControllers();

builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddScoped<ITaxService, TaxService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
