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
        private readonly UserService _userService;
        public GameController(QuestionService questionService, GameResultService gameResultService, UserService userService)
        {
            _questionService = questionService;
            _gameResultService = gameResultService;
            _userService = userService;
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
            var isQuestionsExist = await _questionService.IsAllExistAsync(request.UserAnswerDTOs);

            if (!isQuestionsExist)
            {
                return StatusCode(404, "One of the questions does not exist");
            }

            var userDTO = new UserDTO(request.UserName);
            var isUserExist = await _userService.IsExistAsync(userDTO);

            if (!isUserExist)
            {
                return StatusCode(404, "User does not exist");
            }

            var result = await _gameResultService.CalculateAsync(request);

            return Ok(result);
        }
    }
}
