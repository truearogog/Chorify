using Chorify.Backend.Services.Interfaces;
using Chorify.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Chorify.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                await _authService.Register(Request, dto);
                return null;
            });

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                await _authService.Login(Request, Response, dto);
                return null;
            });

            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                await _authService.Logout(Request, Response);
                return null;
            });

            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                var user = await _authService.GetUser(Request);
                return user;
            });

            return Ok(response);
        }
    }
}
