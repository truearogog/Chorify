using Chorify.Domain.Commands;
using Chorify.Domain.Models;
using Chorify.Domain.Queries;
using Chorify.Services.Interfaces;

namespace Chorify.Backend.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IUpdateUserCommand _updateUserCommand;
        private readonly IGetUserQuery _getUserQuery;

        public UserService(
            ICreateUserCommand createUserCommand, 
            IUpdateUserCommand updateUserCommand, 
            IGetUserQuery getUserQuery)
        {
            _createUserCommand = createUserCommand;
            _updateUserCommand = updateUserCommand;
            _getUserQuery = getUserQuery;
        }

        public async Task Create(User user)
        {
            await _createUserCommand.Execute(user);
        }

        public async Task Update(User user)
        {
            await _updateUserCommand.Execute(user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _getUserQuery.Execute(email);
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _getUserQuery.Execute(id);
        }
    }
}
