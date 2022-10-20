using BasketApi.Data.Dtos.Countrys;
using BasketApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public IActionResult PostCountry([FromBody] CreateCountryDto countryDto)
        {
            ReadCountryDto readDto = _countryService.PostCountry(countryDto);
            return CreatedAtAction(nameof(GetCountryById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            ReadCountryDto readDto = _countryService.GetCountryById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetCountry()
        {
            List<ReadCountryDto> readDto = _countryService.GetCountry();
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContry(int id, [FromBody] UpdateCountryDto countryDto)
        {
            Result result = _countryService.UpdateCountry(id, countryDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            Result result = _countryService.DeleteCountry(id);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
