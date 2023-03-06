using Chorify.Domain.Models;

namespace Chorify.Domain.Queries
{
    public interface IGetChoreQuery
    {
        Task<IEnumerable<Chore>> All(Guid userId);
        Task<Chore?> ById(Guid id);
    }
}
