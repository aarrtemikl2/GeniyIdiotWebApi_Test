
using GeniyIdiotWebApi.Data;
using GeniyIdiotWebApi.Interfaces;
using GeniyIdiotWebApi.Repository;
using GeniyIdiotWebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace GeniyIdiotWebApi
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

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<GameResultRepository>();
            builder.Services.AddScoped<RankRepository>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddScoped<QuestionService>();
            builder.Services.AddScoped<GameResultService>();
            builder.Services.AddScoped<UserService>();

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
}
