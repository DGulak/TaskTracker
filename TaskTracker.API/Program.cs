using Microsoft.EntityFrameworkCore;
using TaskTracker.BLL;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Data;
using TaskTracker.DAL.Repositories;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext and Provide connection info
        var connectionString = builder.Configuration["ConnectionString"];

        builder.Services.AddDbContext<TaskTrackerContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TaskTracker.DAL")));

        // AutoMapper Configuration
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // DI Configurations - Business Logic Layer
        builder.Services.AddScoped<IProjectLogic, ProjectLogic>();
        builder.Services.AddScoped<ITaskLogic, TaskLogic>();

        // DI Configurations - Data Access Layer
        builder.Services.AddScoped<IUnitOfWork<Project>, UnitOfWork<Project>>();
        builder.Services.AddScoped<IUnitOfWork<TaskTracker.Infrastructures.Entities.Task>, UnitOfWork<TaskTracker.Infrastructures.Entities.Task>>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var serviceScope = app.Services.CreateScope())
        {
            try
            {
                // Takes all of our migrations files and apply them against the database in case they are not implemented
                var context = serviceScope.ServiceProvider.GetService<TaskTrackerContext>();
                context.Database.Migrate();
                context.SaveChanges();
                context.Dispose();
            }
            catch (Exception ex)
            {
                var logger = serviceScope.ServiceProvider.GetService<ILogger<Project>>();
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}