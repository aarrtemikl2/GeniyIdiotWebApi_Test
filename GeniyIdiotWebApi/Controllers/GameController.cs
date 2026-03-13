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
            var questions = _questionService.GetShuffledQuestionsAsync();

            return Ok(questions);
        }

        [HttpPost("GameResult")]
        public async Task<ActionResult<GameResultDTO>> PostGameResult([FromBody] UserGameResultRequestDTO request)
        {
            if (request == null || request.UserAnswerDTOs == null)
            {
                return BadRequest("Неверный формат данных");
            }

            var result = await _gameResultService.GetGameResultAsync(request);

            return Ok(result);
        }
    }
}
