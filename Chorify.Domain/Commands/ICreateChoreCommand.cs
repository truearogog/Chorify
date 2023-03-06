using Chorify.Domain.Models;

namespace Chorify.Domain.Commands
{
    public interface ICreateChoreCommand
    {
        Task Execute(Chore chore);
    }
}
