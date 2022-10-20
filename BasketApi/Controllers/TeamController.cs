using BasketApi.Data.Dtos.Teams;
using BasketApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public IActionResult PostTeam([FromBody] CreateTeamDto teamDto)
        {
            ReadTeamDto readDto = _teamService.PostTeam(teamDto);
            return CreatedAtAction(nameof(GetTeamById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            ReadTeamDto readDto = _teamService.GetTeamById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetTeam()
        {
            List<ReadTeamDto> readDto = _teamService.GetTeam();
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, UpdateTeamDto teamDto)
        {
            Result result = _teamService.UpdateTeam(id, teamDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            Result result = _teamService.DeleteTeam(id);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
