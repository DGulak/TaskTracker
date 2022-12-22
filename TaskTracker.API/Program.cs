using Microsoft.EntityFrameworkCore;
using TaskTracker.BLL;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;
using TaskTracker.DAL.Data;
using TaskTracker.DAL.Repositories;
using TaskTracker.Infrastructure.Entities;
using Infrastructure = TaskTracker.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext and Provide Connection String
        var taskTrackerConnString = builder.Configuration.GetConnectionString("TaskTrackerConnectionString");
        builder.Services.AddDbContext<TaskTrackerContext>(options => 
            options.UseSqlServer(taskTrackerConnString, b => b.MigrationsAssembly("TaskTracker.DAL")));

        // AutoMapper Configuration
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // DI Configurations - Business Logic Layer
        builder.Services.AddScoped<IProjectLogic, ProjectLogic>();
        builder.Services.AddScoped<ITaskLogic, TaskLogic>();

        // DI Configurations - Data Access Layer
        builder.Services.AddScoped<IUnitOfWork<Project>, UnitOfWork<Project>>();
        builder.Services.AddScoped<IUnitOfWork<Infrastructure.Entities.Task>, UnitOfWork<Infrastructure.Entities.Task>>();

        builder.Services.AddControllers();
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
    }
}