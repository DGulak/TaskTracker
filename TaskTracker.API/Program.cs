using Microsoft.EntityFrameworkCore;
using TaskTracker.BLL;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;
using TaskTracker.DAL.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext and Provide Connection String
        var blogConnectionString = builder.Configuration.GetConnectionString("TaskTrackerConnectionString");
        builder.Services.AddDbContext<TaskTrackerContext>(options => options.UseSqlServer(blogConnectionString));

        // AutoMapper Configuration
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // DI Configurations - Business Logic Layer
        builder.Services.AddScoped<IProjectLogic, ProjectLogic>();
        builder.Services.AddScoped<ITaskLogic, TaskLogic>();

        // DI Configurations - Data Access Layer
        builder.Services.AddScoped<IRepository<Models.Project>, Repository<Models.Project>>();
        builder.Services.AddScoped<IRepository<Models.Task>, Repository<Models.Task>>();

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