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
        public DbSet<AnswerAttempt> AnswerAttempts { get; set; }
        public DbSet<Rank> Ranks { get; set; }
    }
}
