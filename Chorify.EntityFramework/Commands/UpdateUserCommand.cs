using Chorify.Domain.Commands;
using Chorify.Domain.Models;
using Chorify.EntityFramework.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework.Commands
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public UpdateUserCommand(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(User user)
        {
            using (var context = _contextFactory.Create())
            {
                var userDto = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(user.Id));

                if (userDto != null)
                {
                    userDto.Email = userDto.Email;
                    userDto.PasswordHash = userDto.PasswordHash;
                    userDto.Updated = DateTime.Now;

                    await context.SaveChangesAsync();
                };
            }
        }
    }
}
