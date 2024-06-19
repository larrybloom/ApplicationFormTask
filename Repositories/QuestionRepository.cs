using ApplicationFormTask.DTOs;
using Microsoft.Azure.Cosmos;

namespace ApplicationFormTask.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public QuestionRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("ApplicationFormDB", "Questions");
        }

        public async Task AddQuestionAsync(CustomQuestionDto questionDto)
        {
            await _container.CreateItemAsync(questionDto, new PartitionKey(questionDto.Id));
        }

        public async Task<IEnumerable<CustomQuestionDto>> GetQuestionsByProgramAsync(string programId)
        {
            var query = _container.GetItemQueryIterator<CustomQuestionDto>(
                new QueryDefinition("SELECT * FROM c WHERE c.ProgramId = @programId")
                .WithParameter("@programId", programId)
            );
            var results = new List<CustomQuestionDto>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
    }
}
