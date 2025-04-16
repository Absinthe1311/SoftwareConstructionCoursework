
using Assignment8.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");
            var connectionString = builder.Configuration.GetConnectionString("OrderApiDB");

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // 把DBContext加入到容器
            builder.Services.AddDbContext<OrderContext>(opt => opt.UseMySQL(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHttpsRedirection(); //启动http到https的重定向

            app.MapControllers();

            app.Run();
        }
    }
}
