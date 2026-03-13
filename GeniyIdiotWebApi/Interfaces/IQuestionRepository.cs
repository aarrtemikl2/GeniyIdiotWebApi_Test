using GeniyIdiotWebApi.Models;

namespace GeniyIdiotWebApi.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task<Question> AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int id);
    }
}
