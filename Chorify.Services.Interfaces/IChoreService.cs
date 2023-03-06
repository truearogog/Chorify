using Chorify.Domain.Models;

namespace Chorify.Services.Interfaces
{
    public interface IChoreService
    {
        Task Create(Chore chore);
        Task Update(Chore chore);
        Task Delete(Guid id);
        Task<IEnumerable<Chore>> GetAll(Guid userId);
    }
}
