using Chorify.Domain.Models;
using Chorify.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework.Queries
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public GetUserQuery(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User?> ById(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var userDto = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (userDto == null) return null;

                return new User(userDto.Id, userDto.Email, userDto.PasswordHash);
            }
        }

        public async Task<User?> ByEmail(string email)
        {
            using (var context = _contextFactory.Create())
            {
                var userDto = await context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));

                if (userDto == null) return null;

                return new User(userDto.Id, userDto.Email, userDto.PasswordHash);
            }
        }
    }
}
