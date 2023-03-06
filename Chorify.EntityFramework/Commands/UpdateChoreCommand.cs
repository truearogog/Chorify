using Chorify.Domain.Commands;
using Chorify.Domain.Models;
using Chorify.EntityFramework.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework.Commands
{
    public class UpdateChoreCommand : IUpdateChoreCommand
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public UpdateChoreCommand(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Chore chore)
        {
            using (var context = _contextFactory.Create())
            {
                var choreDto = await context.Chores.FirstOrDefaultAsync(x => x.Id.Equals(chore.Id));

                if (choreDto != null)
                {
                    choreDto.Name = chore.Name;
                    choreDto.Description = chore.Description;
                    choreDto.Color = chore.Color;
                    choreDto.Updated = DateTime.Now;

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
