
using ApplicationFormTask.DTOs;
using ApplicationFormTask.Models;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;

namespace ApplicationFormTask.Repositories
{
    public class ProgramRepository : IProgramRepository
    {

        private readonly Microsoft.Azure.Cosmos.Container _container;

        public ProgramRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("ApplicationFormDB", "Programs");
        }

        public async Task AddProgramAsync(ProgramDto programDto)
        {
            await _container.CreateItemAsync(programDto, new PartitionKey(programDto.Id));
        }

        public async Task DeleteProgramAsync(string id)
        {
            await _container.DeleteItemAsync<ProgramDto>(id, new PartitionKey(id));
        }

        public async Task<ProgramDto> GetProgramAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<ProgramDto>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProgramDto>> GetProgramsAsync()
        {
            var query = _container.GetItemQueryIterator<Program>();
            var results = new List<Program>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return (IEnumerable<ProgramDto>)results;
        }

        public async Task UpdateProgramAsync(string id, ProgramDto program)
        {
            await _container.UpsertItemAsync(program, new PartitionKey(id));
        }
    }
}
