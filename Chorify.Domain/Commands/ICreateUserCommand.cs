using Chorify.Domain.Models;

namespace Chorify.Domain.Commands
{
    public interface ICreateUserCommand
    {
        Task Execute(User user);
    }
}
