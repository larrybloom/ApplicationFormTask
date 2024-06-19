using ApplicationFormTask.DTOs;
using ApplicationFormTask.Repositories;

namespace ApplicationFormTask.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _typeRepository;

        public QuestionTypeService(IQuestionTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IEnumerable<QuestionTypeDTO>> GetCategoriesAsync()
        {
            return await _typeRepository.GetCategoriesAsync();
        }
    }
}
