using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Interfaces;
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

        public async Task<GameResultDTO> GetGameResultAsync(UserGameResultRequestDTO request)
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

            var gameResultDTO = new GameResultDTO(request.UserId, score, rank);

            return gameResultDTO;
        }

        public async Task<string> CalculateRank(int score, int questionCount)
        {
            var ranks = await _rankRepository.GetRanksAsync();
            double percentCorrectCount = (double)score / questionCount * 100;
            int userRank = (int)(percentCorrectCount / (100.0 / ranks.Count));

            return ranks[Math.Min(userRank, ranks.Count - 1)].Name;
        }
    }
}
