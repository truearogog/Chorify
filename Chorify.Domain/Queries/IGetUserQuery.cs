using Chorify.Domain.Models;

namespace Chorify.Domain.Queries
{
    public interface IGetUserQuery
    {
        Task<User?> Execute(Guid id);
        Task<User?> Execute(string email);
    }
}
