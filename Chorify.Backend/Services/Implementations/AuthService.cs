using Chorify.Backend.Services.Interfaces;
using Chorify.Domain.Dtos;
using Chorify.Domain.Models;
using Chorify.Services.Interfaces;

namespace Chorify.Backend.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthService(
            ILogger<AuthService> logger,
            IJwtService jwtService, 
            IUserService userService)
        {
            _logger = logger;
            _jwtService = jwtService;
            _userService = userService;
        }

        public void Register(HttpRequest request, RegisterDto dto)
        {
            var user = Task.Run(async () => await _userService.GetByEmail(dto.Email)).Result;

            if (user != null)
                throw new Exception();

            user = new User(
                Guid.NewGuid(),
                dto.Email,
                BCrypt.Net.BCrypt.HashPassword(dto.Password));

            Task.Run(async () => await _userService.Create(user));

            _logger.LogInformation($"Created user {user.Id} {user.Email}");
        }

        public void Login(HttpRequest request, HttpResponse response, LoginDto dto)
        {
            var user = Task.Run(async () => await _userService.GetByEmail(dto.Email)).Result;

            if (user == null)
                throw new Exception();

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception();

            var jwt = _jwtService.Generate(user.Id);

            response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });

            _logger.LogInformation($"User '{user.Id}' '{user.Email}' logged in");
        }

        public void Logout(HttpRequest request, HttpResponse response)
        {
            response.Cookies.Delete("jwt");
        }

        public User? GetUser(HttpRequest request)
        {
            var jwt = request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var userId = Guid.Parse(token.Issuer);
            var user = Task.Run(async () => await _userService.GetById(userId)).Result;

            return user;
        }
    }
}
