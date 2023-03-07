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

        public async Task Register(HttpRequest request, UserRegisterDto dto)
        {
            var user = await _userService.GetByEmail(dto.Email);

            if (user != null)
                throw new Exception();

            user = new User(
                Guid.NewGuid(),
                dto.Email,
                BCrypt.Net.BCrypt.HashPassword(dto.Password));

            await _userService.Create(user);

            _logger.LogInformation($"Created user {user.Id} {user.Email}");
        }

        public async Task Login(HttpRequest request, HttpResponse response, UserLoginDto dto)
        {
            var user = await _userService.GetByEmail(dto.Email);
            
            if (user == null)
                throw new Exception();

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception();

            var jwt = _jwtService.Generate(user.Id);

            response.Cookies.Append("jwt", jwt, new CookieOptions { });

            _logger.LogInformation($"User '{user.Id}' '{user.Email}' logged in");
        }

        public async Task Logout(HttpRequest request, HttpResponse response)
        {
            await Task.Run(() => {
                response.Cookies.Delete("jwt");
            });
        }

        public async Task<User?> GetUser(HttpRequest request)
        {
            var jwt = request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Guid.Parse(token.Issuer);
            var user = await _userService.GetById(userId);

            return user ?? throw new Exception();
        }
    }
}
