using MembershipPortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("connectionStringHemant");

builder.Services.AddDbContext<MembershipPortalDbContext>(options => options.UseSqlServer(connectionString));    
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
