using Chorify.Backend.DI;
using Chorify.EntityFramework;

namespace Chorify.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDataAccess(builder);

            builder.Services.AddCommandGroup();
            builder.Services.AddQueryGroup();
            builder.Services.AddServiceGroup();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var context = app.Services.GetRequiredService<ChorifyDbContextFactory>().Create())
            {
                context.Database.EnsureCreated();
            }

            app.UseAuthorization();

            app.UseCors(options => options
                .WithOrigins(new[] { "http://localhost:3000" })
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.MapControllers();
            app.MapFallbackToController("Index", "Fallback");

            app.Run();
        }
    }
}