using BasketApi.Data.Dtos.Possitions;
using BasketApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PossitionController : ControllerBase
    {
        private PossitionService _possitionService;

        public PossitionController(PossitionService possitionService)
        {
            _possitionService = possitionService;
        }

        [HttpPost]
        public IActionResult PostPossition([FromBody] CreatePossitionDto possitionDto)
        {
            ReadPossitionDto readDto = _possitionService.PostPossition(possitionDto);
            return CreatedAtAction(nameof(GetPossitionById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetPossitionById(int id)
        {
            ReadPossitionDto readDto = _possitionService.GetPossitionById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetPossition()
        {
            List<ReadPossitionDto> readDto = _possitionService.GetPossition();
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePossition(int id, [FromBody] UpdatePossitionDto possitionDto)
        {
            Result result = _possitionService.UpdatePossition(id, possitionDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePossition(int id)
        {
            Result result = _possitionService.DeletePossition(id);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
