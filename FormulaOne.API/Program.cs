using FormulaOne.DataService.Data;
using FormulaOne.DataService.Resositories;
using FormulaOne.DataService.Resositories.Interfaces;
using FormulaOne.Services.General;
using FormulaOne.Services.General.Interfaces;
using Hangfire;
using Hangfire.Storage.SQLite;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Get Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var hangFireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
//Initialising my DbContext inside the DI Container
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IMerchService, MerchService>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

//Hangfire Clint
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSQLiteStorage(hangFireConnectionString));
    
//Hengfire Server
builder.Services.AddHangfireServer();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly)); 

var app = builder.Build();

// Configure the HTTP request pipeline. Daha sonrasinda bak.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
app.MapHangfireDashboard("/hangfire", new DashboardOptions()
{
    DashboardTitle = "Formula One Service Dash",
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter()
        {
            Pass = "pass",
            User = "furkan"
        }
    }
});

app.Run();

