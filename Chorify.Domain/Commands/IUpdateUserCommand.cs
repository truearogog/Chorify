using Chorify.Domain.Models;

namespace Chorify.Domain.Commands
{
    public interface IUpdateUserCommand
    {
        Task Execute(User user);
    }
}
