using GeniyIdiotWebApi.Data;
using GeniyIdiotWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniyIdiotWebApi.Repository
{
    public class RankRepository
    {
        private readonly AppDbContext _context;
        public RankRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rank>> GetRanksAsync()
        {
            return await _context.Ranks.ToListAsync();
        }
    }
}
