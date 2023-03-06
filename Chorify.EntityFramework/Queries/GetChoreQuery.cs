using Chorify.Domain.Models;
using Chorify.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework.Queries
{
    public class GetChoreQuery : IGetChoreQuery
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public GetChoreQuery(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Chore>> All(Guid userId)
        {
            using (var context = _contextFactory.Create())
            {
                var choreDtos = await context.Chores.Where(x => x.UserId.Equals(userId)).ToListAsync();

                return choreDtos.Select(x => new Chore(x.Id, x.Name, x.Description, x.Color, x.UserId));
            }
        }

        public async Task<Chore?> ById(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var choreDto = await context.Chores.FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (choreDto == null) return null;

                return new Chore(choreDto.Id, choreDto.Name, choreDto.Description, choreDto.Color, choreDto.UserId);
            }
        }
    }
}
