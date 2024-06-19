using ApplicationFormTask.DTOs;
using ApplicationFormTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFormTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionTypeService _categoryService;

        public QuestionController(IQuestionTypeService categoryService, IQuestionService questionService)
        {
            _categoryService = categoryService;
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(CustomQuestionDto questionDto)
        {
            await _questionService.AddQuestionAsync(questionDto);
            return Ok();
        }

        [HttpGet("program/{programId}")]
        public async Task<ActionResult<IEnumerable<CustomQuestionDto>>> GetQuestionsByProgram(string programId)
        {
            var questions = await _questionService.GetQuestionsByProgramAsync(programId);
            return Ok(questions);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<QuestionTypeDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}
