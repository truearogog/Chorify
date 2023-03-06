using Chorify.Domain.Models;

namespace Chorify.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(User user);
        Task Update(User user);
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
    }
}
