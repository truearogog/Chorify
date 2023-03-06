using Chorify.Domain.Models;

namespace Chorify.Domain.Commands
{
    public interface IUpdateChoreCommand
    {
        Task Execute(Chore chore);
    }
}
