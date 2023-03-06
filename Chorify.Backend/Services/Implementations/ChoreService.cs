using Chorify.Domain.Commands;
using Chorify.Domain.Models;
using Chorify.Domain.Queries;
using Chorify.Services.Interfaces;

namespace Chorify.Backend.Services.Implementations
{
    public class ChoreService : IChoreService
    {
        private readonly ICreateChoreCommand _createChoreCommand;
        private readonly IUpdateChoreCommand _updateChoreCommand;
        private readonly IDeleteChoreCommand _deleteChoreCommand;
        private readonly IGetAllChoresQuery _getAllChoresQuery;

        public ChoreService(
            ICreateChoreCommand createChoreCommand, 
            IUpdateChoreCommand updateChoreCommand, 
            IDeleteChoreCommand deleteChoreCommand, 
            IGetAllChoresQuery getAllChoresQuery)
        {
            _createChoreCommand = createChoreCommand;
            _updateChoreCommand = updateChoreCommand;
            _deleteChoreCommand = deleteChoreCommand;
            _getAllChoresQuery = getAllChoresQuery;
        }

        public async Task Create(Chore chore)
        {
            await _createChoreCommand.Execute(chore);
        }

        public async Task Update(Chore chore)
        {
            await _updateChoreCommand.Execute(chore);
        }

        public async Task Delete(Guid id)
        {
            await _deleteChoreCommand.Execute(id);
        }

        public async Task<IEnumerable<Chore>> GetAll(Guid userId)
        {
            return await _getAllChoresQuery.Execute(userId);
        }
    }
}
