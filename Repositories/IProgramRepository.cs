using ApplicationFormTask.DTOs;

namespace ApplicationFormTask.Repositories
{
    public interface IProgramRepository
    {
        Task AddProgramAsync(ProgramDto programDto);
        Task DeleteProgramAsync(string id);
        Task<ProgramDto> GetProgramAsync(string id);
        Task<IEnumerable<ProgramDto>> GetProgramsAsync();
        Task UpdateProgramAsync(string id, ProgramDto programDto);
    }
}
