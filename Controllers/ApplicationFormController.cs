using ApplicationFormTask.DTOs;
using ApplicationFormTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFormTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ApplicationFormController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] ProgramDto programDto)
        {
            await _programService.AddProgramAsync(programDto);
            return CreatedAtAction(nameof(GetProgram), new { id = programDto.Title }, programDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(string id)
        {
            var program = await _programService.GetProgramAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var programs = await _programService.GetProgramsAsync();
            return Ok(programs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(string id, [FromBody] ProgramDto programDto)
        {
            await _programService.UpdateProgramAsync(id, programDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(string id)
        {
            await _programService.DeleteProgramAsync(id);
            return NoContent();
        }
    }
}
