using RoboClearingApi.Contexts;
using RoboClearingApi.Services;

using RoboClearingApi.Services.Impl;


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
            
            builder.Services.AddScoped<IRobotRepository, RobotRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

            builder.Services.AddDbContext<RoboClearingPostgreSqlDBContext>();
        
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
