using datlichkhambenh.Models;
using datlichkhambenh.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<DepartmentService, DepartmentServiceImpl>();
builder.Services.AddScoped<DoctorService, DoctorServiceImpl>();
builder.Services.AddScoped<PatientService, PatientServiceImpl>();
builder.Services.AddScoped<ExaminationscheduleService, ExaminationscheduleServiceImpl>();

var app = builder.Build();

app.UseSession();

app.UseStaticFiles();

app.MapControllerRoute
	(
	name: "default",
	pattern: "{controller}/{action}"
	);

app.MapControllerRoute
	(
	name: "area",
	pattern: "{area:exists}/{controller}/{action}"
	);

app.Run();

