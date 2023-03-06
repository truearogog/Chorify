using Chorify.Domain.Commands;
using Chorify.Domain.Models;
using Chorify.EntityFramework.Dtos;

namespace Chorify.EntityFramework.Commands
{
    public class CreateChoreCommand : ICreateChoreCommand
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public CreateChoreCommand(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Chore chore)
        {
            using (var context = _contextFactory.Create())
            {
                var choreDto = new ChoreDto
                {
                    Id = chore.Id,
                    Name = chore.Name,
                    Description = chore.Description,
                    Color = chore.Color,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };

                context.Chores.Add(choreDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
