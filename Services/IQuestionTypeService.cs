using ApplicationFormTask.DTOs;

namespace ApplicationFormTask.Services
{
    public interface IQuestionTypeService
    {
        Task<IEnumerable<QuestionTypeDTO>> GetCategoriesAsync();
    }
}
