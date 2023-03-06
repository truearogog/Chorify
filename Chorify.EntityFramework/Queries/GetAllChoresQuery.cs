using Chorify.Domain.Models;
using Chorify.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework.Queries
{
    public class GetAllChoresQuery : IGetAllChoresQuery
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public GetAllChoresQuery(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Chore>> Execute(Guid userId)
        {
            using (var context = _contextFactory.Create())
            {
                var choreDtos = await context.Chores.Where(x => x.UserId.Equals(userId)).ToListAsync();

                return choreDtos.Select(x => new Chore(x.Id, x.Name, x.Description, x.Color));
            }
        }
    }
}
