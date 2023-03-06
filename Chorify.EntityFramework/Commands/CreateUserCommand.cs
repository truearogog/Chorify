using Chorify.Domain.Commands;
using Chorify.Domain.Models;
using Chorify.EntityFramework.Dtos;
using System;

namespace Chorify.EntityFramework.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly ChorifyDbContextFactory _contextFactory;

        public CreateUserCommand(ChorifyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(User user)
        {
            using (var context = _contextFactory.Create())
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };

                context.Users.Add(userDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
