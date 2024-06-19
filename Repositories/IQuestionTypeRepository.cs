using ApplicationFormTask.DTOs;

namespace ApplicationFormTask.Repositories
{
    public interface IQuestionTypeRepository
    {
        Task<IEnumerable<QuestionTypeDTO>> GetCategoriesAsync();
    }
}
