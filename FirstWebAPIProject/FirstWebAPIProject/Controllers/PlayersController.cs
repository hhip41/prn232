using FirstWebAPIProject.DTOs.Players;
using FirstWebAPIProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var players = await _playerService.GetPlayersAsync(urlQueryParameters);
            return Ok(players);
        }

        [HttpGet("{id:long}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            var player = await _playerService.GetPlayerDetailResponse(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            if (playerRequest == null) return BadRequest();
            await _playerService.CreatePlayerAsync(playerRequest);
            return CreatedAtAction(nameof(GetPlayerDetailAsync), new { name = playerRequest.Name }, playerRequest);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            if (playerRequest == null) return BadRequest();
            var result = await _playerService.UpdatePlayerAsync(id, playerRequest);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            var result = await _playerService.DeletePlayerAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
