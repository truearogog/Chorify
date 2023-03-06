using Chorify.Backend.Services.Interfaces;
using Chorify.Domain.Dtos;
using Chorify.Domain.Models;
using Chorify.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chorify.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IChoreService _choreService;

        public ChoreController(
            ILogger<AuthController> logger, 
            IAuthService authService, 
            IChoreService choreService)
        {
            _logger = logger;
            _authService = authService;
            _choreService = choreService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllChores()
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                var user = await _authService.GetUser(Request);
                var chores = await _choreService.GetAll(user.Id);

                return chores;
            });

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChore([FromBody] ChoreCreateDto dto)
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                var user = await _authService.GetUser(Request);
                var chore = new Chore(Guid.NewGuid(), dto.Name, dto.Description, dto.Color, user.Id);

                await _choreService.Create(chore);
                return null;
            });

            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateChore([FromBody] ChoreUpdateDto dto)
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                var user = await _authService.GetUser(Request);
                var choreId = Guid.Parse(dto.Id);
                var chore = await _choreService.GetById(choreId);

                if (chore == null)
                    throw new Exception();

                if (!chore.UserId.Equals(user.Id))
                    throw new Exception();

                await _choreService.Update(new Chore(choreId, dto.Name, dto.Description, dto.Color));
                return null;
            });

            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteChore([FromBody] ChoreDeleteDto dto)
        {
            var response = await ApiResponseDto.BuildAsync(async () =>
            {
                var user = await _authService.GetUser(Request);
                var choreId = Guid.Parse(dto.Id);
                var chore = await _choreService.GetById(choreId);

                if (chore == null)
                    throw new Exception();

                if (!chore.UserId.Equals(user.Id))
                    throw new Exception();

                await _choreService.Delete(choreId);
                return null;
            });

            return Ok(response);
        }
    }
}
