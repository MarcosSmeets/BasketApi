using BasketApi.Data.Dtos.Players;
using BasketApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public IActionResult PostPlayer([FromBody] CreatePlayerDto playerDto)
        {
            ReadPlayerDto readDto = _playerService.PostPlayer(playerDto);
            return CreatedAtAction(nameof(GetPlayerById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            ReadPlayerDto readDto = _playerService.GetPlayerById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetPlayer()
        {
            List<ReadPlayerDto> readDto = _playerService.GetPlayer();
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutPlayer(int id, [FromBody] UpdatePlayerDto playerDto)
        {
            Result result = _playerService.PutPlayer(id, playerDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            Result result = _playerService.DeletePlayer(id);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
