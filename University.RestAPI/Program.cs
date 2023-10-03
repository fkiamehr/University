using Microsoft.EntityFrameworkCore;
using University.DataLayer.Context;
using University.RestAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStudentAPIService, StudentAPIService>();

#region DataBase Context
var connectionString = builder.Configuration.GetConnectionString("UniversityConnection") ??
    throw new InvalidOperationException("Connection string 'UniversityConnection' not found.");
builder.Services.AddDbContext<UniversityContext>(options =>
                options.UseSqlServer(connectionString));
#endregion

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
