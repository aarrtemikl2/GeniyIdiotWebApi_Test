using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Interfaces;
using GeniyIdiotWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniyIdiotWebApi.Services
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly Random _random = new();

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<QuestionDTO>> GetAllAsync()
        {
            var questions = await _questionRepository.GetAllAsync();

            return questions.Select(q => new QuestionDTO
            {
                Id = q.Id,
                Title = q.Title
            }
            ).ToList();
        }

        public async Task<List<QuestionDTO>> GetShuffledAsync()
        {
            var questions = await _questionRepository.GetAllAsync();

            var shuffleQuestions = questions.OrderBy(x => _random.Next()).ToList();

            return shuffleQuestions.Select(q => new QuestionDTO
            {
                Id = q.Id,
                Title = q.Title
            }
            ).ToList();
        }
        public async Task<bool> IsAllExistAsync(List<UserAnswerDTO> userAnswerDTOs)
        {
            var questions = await _questionRepository.GetAllAsync();

            return userAnswerDTOs.All(userAsnwer => questions.Select(q => q.Id)
                                                         .Contains(userAsnwer.QuestionId));
        }
    }
}
