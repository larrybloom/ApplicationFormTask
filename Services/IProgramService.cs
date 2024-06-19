using ApplicationFormTask.DTOs;

namespace ApplicationFormTask.Services
{
    public interface IProgramService
    {
        Task<ProgramDto> GetProgramAsync(string id);
        Task<IEnumerable<ProgramDto>> GetProgramsAsync();
        Task AddProgramAsync(ProgramDto programDto);
        Task UpdateProgramAsync(string id, ProgramDto programDto);
        Task DeleteProgramAsync(string id);
    }
}
