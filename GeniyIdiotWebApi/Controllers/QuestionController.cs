using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeniyIdiotWebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;
        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("questions")]
        public async Task<ActionResult<List<QuestionDTO>>> GetQuestions()
        {
            var questions = _questionService.GetAllAsync();

            return Ok(questions);
        }

        [HttpGet("shuffleQuestions")]
        public async Task<ActionResult<List<QuestionDTO>>> GetShuffleQuestions()
        {
            var questions = _questionService.GetShuffledAsync();

            return Ok(questions);
        }
        //TODO: Реализовать  методы удаления/добавление/получение вопроса
        [HttpPost("question")]
        public async Task<ActionResult<QuestionDTO>> Create([FromBody] QuestionRequestDTO request)
        {
            var isExist = await _questionService.IsExistAsync(request);

            if (isExist)
            {
                return StatusCode(409, "The question already exists");
            }

            var result = await _questionService.Create(request);

            return StatusCode(201, result);
        }

    }
}
