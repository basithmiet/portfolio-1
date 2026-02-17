
using LifeOS.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("LifeOSDb"));

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("allowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("allowAll");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}
