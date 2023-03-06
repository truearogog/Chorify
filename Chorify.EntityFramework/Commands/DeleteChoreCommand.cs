using Chorify.Domain.Commands;
using Chorify.EntityFramework.Dtos;

namespace Chorify.EntityFramework.Commands
{
    public class DeleteChoreCommand : IDeleteChoreCommand
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public DeleteChoreCommand(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var choreDto = new ChoreDto
                {
                    Id = id
                };

                context.Chores.Remove(choreDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
