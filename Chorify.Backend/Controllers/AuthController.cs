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
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var response = new ApiResponseDto(() =>
            {
                _authService.Register(Request, dto);
            });
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var response = new ApiResponseDto(() =>
            {
                _authService.Login(Request, Response, dto);
            });
            return Ok(response);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var response = new ApiResponseDto(() =>
            {
                _authService.Logout(Request, Response);
            });
            return Ok(response);
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            var response = new ApiResponseDto(() =>
            {
                return _authService.GetUser(Request);
            });
            return Ok(response);
        }
    }
}
