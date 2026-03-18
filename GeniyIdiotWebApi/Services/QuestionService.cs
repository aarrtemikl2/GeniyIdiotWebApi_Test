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
            }).ToList();
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

            return userAnswerDTOs.All(userAnswer => questions.Select(q => q.Id)
                                                         .Contains(userAnswer.QuestionId));
        }

        public async Task<bool> IsExistAsync(QuestionRequestDTO questionRequestDTO)
        {
            var questions = await _questionRepository.GetAllAsync();

            return questions.Any(q => q.Title == questionRequestDTO.Title);
        }

        public async Task<QuestionDTO> Create(QuestionRequestDTO questionRequestDTO)
        {
            var question = new Question(questionRequestDTO.Title, questionRequestDTO.Answer);

            await _questionRepository.AddAsync(question);

            var questionDTO = new QuestionDTO(question.Id, question.Title);

            return questionDTO;
        }
    }
}
