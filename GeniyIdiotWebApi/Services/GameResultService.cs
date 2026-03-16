using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Interfaces;
using GeniyIdiotWebApi.Models;
using GeniyIdiotWebApi.Repository;

namespace GeniyIdiotWebApi.Services
{
    public class GameResultService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly GameResultRepository _gameResultRepository;
        private readonly RankRepository _rankRepository;
        public GameResultService(IQuestionRepository questionRepository, GameResultRepository gameResultRepository, RankRepository rankRepository)
        {
            _questionRepository = questionRepository;
            _gameResultRepository = gameResultRepository;
            _rankRepository = rankRepository;
        }

        public async Task<List<GameResultDTO>> GetAllAsync()
        {
            var gameResults = await _gameResultRepository.GetAll();

            var gameResultsDTO = gameResults.Select(gr => new GameResultDTO
            {
                UserId = gr.UserId,
                Score = gr.Score,
                Rank = gr.Rank
            }).ToList();

            return gameResultsDTO;
        }

        public async Task<GameResultDTO> CalculateAsync(UserGameResultRequestDTO request)
        {
            var questions = await _questionRepository.GetAllAsync();

            int score = 0;
            int totalQuestions = questions.Count();

            foreach (var userAnswer in request.UserAnswerDTOs)
            {
                var question = questions.FirstOrDefault(q => q.Id == userAnswer.QuestionId);

                if (question.Answer == userAnswer.UserAnswer)
                {
                    score++;
                }
            }
            var rank = await CalculateRank(score, totalQuestions);

            var gameResult = new GameResult(request.UserId, score, rank);

            try
            {
                await _gameResultRepository.SaveAsync(gameResult);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var gameResultDTO = new GameResultDTO(gameResult.UserId, gameResult.Score, gameResult.Rank);

            return gameResultDTO;
        }

        private async Task<string> CalculateRank(int score, int questionCount)
        {
            var ranks = await _rankRepository.GetRanksAsync();
            double percentCorrectCount = (double)score / questionCount * 100;
            int userRank = (int)(percentCorrectCount / (100.0 / ranks.Count));

            return ranks[Math.Min(userRank, ranks.Count - 1)].Name;
        }
    }
}
