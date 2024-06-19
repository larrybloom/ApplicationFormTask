using ApplicationFormTask.DTOs;
using ApplicationFormTask.Repositories;

namespace ApplicationFormTask.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task AddQuestionAsync(CustomQuestionDto questionDto)
        {
            await _questionRepository.AddQuestionAsync(questionDto);
        }

        public async Task<IEnumerable<CustomQuestionDto>> GetQuestionsByProgramAsync(string programId)
        {
            return await _questionRepository.GetQuestionsByProgramAsync(programId);
        }
    }
}
