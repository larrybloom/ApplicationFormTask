using ApplicationFormTask.DTOs;

namespace ApplicationFormTask.Repositories
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(CustomQuestionDto questionDto);
        Task<IEnumerable<CustomQuestionDto>> GetQuestionsByProgramAsync(string programId);
    }
}
