using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeniyIdiotWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly QuestionService _questionService;
        private readonly GameResultService _gameResultService;
        public GameController(QuestionService questionService, GameResultService gameResultService)
        {
            _questionService = questionService;
            _gameResultService = gameResultService;
        }

        [HttpGet("questions")]
        public async Task<ActionResult<List<QuestionDTO>>> GetQuestions()
        {
            var questions = _questionService.GetQuestionsAsync();

            return Ok(questions);
        }

        [HttpGet("shuffleQuestions")]
        public async Task<ActionResult<List<QuestionDTO>>> GetShuffleQuestions()
        {
            var questions = _questionService.GetShuffledQuestionsAsync();

            return Ok(questions);
        }

        [HttpGet("allGameResults")]
        public async Task<ActionResult<List<GameResultDTO>>> GetAllGameResults()
        {
            var gameResults = _gameResultService.GetAllAsync();

            return Ok(gameResults);
        }

        [HttpPost("gameResult")]
        public async Task<ActionResult<GameResultDTO>> PostGameResult([FromBody] UserGameResultRequestDTO request)
        {
            var result = await _gameResultService.CalculateAsync(request);

            return Ok(result);
        }
    }
}
