using Microsoft.EntityFrameworkCore;
using PizzaShopAPIJWT.context;
using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model;
using PizzaShopAPIJWT.Repositories;
using PizzaShopAPIJWT.services;

namespace PizzaShopAPIJWT
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

            builder.Services.AddDbContext<PizzaShopContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
             );

            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();


            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();

            builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();

            builder.Services.AddScoped<IPizzaService, PizzaService>();


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
