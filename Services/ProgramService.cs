using ApplicationFormTask.DTOs;
using ApplicationFormTask.Models;
using ApplicationFormTask.Repositories;
using AutoMapper;

namespace ApplicationFormTask.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task AddProgramAsync(ProgramDto programDto)
        {
            await _programRepository.AddProgramAsync(programDto);
        }

        public async Task DeleteProgramAsync(string id)
        {
            await _programRepository.DeleteProgramAsync(id);
        }

        public async Task<ProgramDto> GetProgramAsync(string id)
        {
            return await _programRepository.GetProgramAsync(id);
        }

        public async Task<IEnumerable<ProgramDto>> GetProgramsAsync()
        {
            return await _programRepository.GetProgramsAsync();
        }

        public async Task UpdateProgramAsync(string id, ProgramDto programDto)
        {
            await _programRepository.UpdateProgramAsync(id, programDto);
        }
    }
}
