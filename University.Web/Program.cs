using Microsoft.EntityFrameworkCore;
using University.Core.Services.Interfaces;
using University.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IStudentService, StudentService>();
#region DataBase Context
var connectionString = builder.Configuration.GetConnectionString("UniversityConnection") ??
    throw new InvalidOperationException("Connection string 'UniversityConnection' not found.");
builder.Services.AddDbContext<UniversityContext>(options =>
                options.UseSqlServer(connectionString));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
