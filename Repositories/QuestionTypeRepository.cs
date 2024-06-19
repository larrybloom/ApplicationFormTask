using ApplicationFormTask.DTOs;
using Microsoft.Azure.Cosmos;

namespace ApplicationFormTask.Repositories
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public QuestionTypeRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("ApplicationFormDB", "Categories");
        }

        public async Task<IEnumerable<QuestionTypeDTO>> GetCategoriesAsync()
        {
            var query = _container.GetItemQueryIterator<QuestionTypeDTO>();
            var results = new List<QuestionTypeDTO>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
    }
}
