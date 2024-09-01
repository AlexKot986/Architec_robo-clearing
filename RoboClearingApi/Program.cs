using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoboClearingApi.Contexts;
using RoboClearingApi.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using RoboClearingApi.Services.Impl;
using RoboClearingApi.Services.NotImpl;

namespace RoboClearingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(configure =>
            {
                configure.EnableAnnotations();
            });

            builder.Services.AddScoped<IRoboStatusRepository, RoboStatusRepository>();
            builder.Services.AddScoped<IRobotRepository, RobotRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            builder.Services.AddScoped(typeof(WeekDayRepository));
            builder.Services.AddScoped(typeof(TypeOfClearingRepository));

            builder.Services.AddDbContext<RoboClearingPostgreSqlDBContext>(options =>
            {
                options.UseNpgsql();
            });
        
            var app = builder.Build();

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
