using GeniyIdiotWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniyIdiotWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Title = "Сколько будет два плюс два умноженное на два?",
                    Answer = 6
                },
                new Question
                {
                    Id = 2,
                    Title = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
                    Answer = 9
                },
                new Question
                {
                    Id = 3,
                    Title = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                    Answer = 25
                },
                new Question
                {
                    Id = 4,
                    Title = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
                    Answer = 60
                },
                new Question
                {
                    Id = 5,
                    Title = "Пять свечей горело, две потухли. Сколько свечей осталось?",
                    Answer = 2
                }
            );
            modelBuilder.Entity<Rank>().HasData(
                new Rank
                {
                    Id = 1,
                    Name = "Идиот"
                },
                new Rank
                {
                    Id = 2,
                    Name = "Кретин"
                },
                new Rank
                {
                    Id = 3,
                    Name = "Дурак"
                },
                new Rank
                {
                    Id = 4,
                    Name = "Нормальный"
                },
                new Rank
                {
                    Id = 5,
                    Name = "Талант"
                },
                new Rank
                {
                    Id = 6,
                    Name = "Гений"
                }
            );
        }
    }
}
