using Microsoft.EntityFrameworkCore;
using RequestTrackerAPI.context;
using RequestTrackerAPI.interfaces;
using RequestTrackerAPI.models;
using RequestTrackerAPI.repository;
using RequestTrackerAPI.Service;
using static System.Object;

namespace RequestTrackerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region context

            builder.Services.AddDbContext<RequestTrackerContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion
            #region employee swervice
            builder.Services.AddScoped<IReposiroty<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IReposiroty<int, User>, UserRepository>();
            #endregion
            #region service
            builder.Services.AddScoped<IEmployeeService, EmployeeBasicService>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
