using GeniyIdiotWebApi.Data;
using GeniyIdiotWebApi.Models;

namespace GeniyIdiotWebApi.Repository
{
    public class GameResultRepository
    {
        private readonly AppDbContext _context;
        public GameResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GameResult> SaveAsync(GameResult gameResult)
        {
            await _context.AddAsync<GameResult>(gameResult);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Не удалось сохранить в БД. Откат");
            }

            return gameResult;
        }
    }
}
