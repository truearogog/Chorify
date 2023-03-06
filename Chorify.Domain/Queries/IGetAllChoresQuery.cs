using Chorify.Domain.Models;

namespace Chorify.Domain.Queries
{
    public interface IGetAllChoresQuery
    {
        Task<IEnumerable<Chore>> Execute(Guid userId);
    }
}
