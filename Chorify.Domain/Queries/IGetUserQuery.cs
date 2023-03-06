using Chorify.Domain.Models;

namespace Chorify.Domain.Queries
{
    public interface IGetUserQuery
    {
        Task<User?> ById(Guid id);
        Task<User?> ByEmail(string email);
    }
}
