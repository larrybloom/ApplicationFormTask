using ApplicationFormTask.DTOs;

namespace ApplicationFormTask.Services
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(CustomQuestionDto questionDto);
        Task<IEnumerable<CustomQuestionDto>> GetQuestionsByProgramAsync(string programId);
    }
}
