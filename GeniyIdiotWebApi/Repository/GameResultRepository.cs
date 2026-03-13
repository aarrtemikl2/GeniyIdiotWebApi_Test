using GeniyIdiotWebApi.Data;

namespace GeniyIdiotWebApi.Repository
{
    public class GameResultRepository
    {
        private readonly AppDbContext _context;
        public GameResultRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
