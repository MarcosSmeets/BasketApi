using AutoMapper;
using BasketApi.Data;
using BasketApi.Data.Dtos.Countrys;
using BasketApi.Models;
using FluentResults;

namespace BasketApi.Services
{
    public class CountryService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CountryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCountryDto PostCountry(CreateCountryDto countryDto)
        {
            Country country = _mapper.Map<Country>(countryDto);
            _context.Countries.Add(country);
            _context.SaveChanges();
            return _mapper.Map<ReadCountryDto>(country);
        }

        public ReadCountryDto GetCountryById(int id)
        {
            Country country = _context.Countries.FirstOrDefault(p => p.Id == id);
            if (country != null)
            {
                ReadCountryDto result = _mapper.Map<ReadCountryDto>(country);
                return result;
            }
            return null;
        }

        public List<ReadCountryDto> GetCountry()
        {
            List<Country> country;
            country = _context.Countries.ToList();
            if (country != null)
            {
                List<ReadCountryDto> readDto = _mapper.Map<List<ReadCountryDto>>(country);
                return readDto;
            }
            return null;
        }

        public Result UpdateCountry(int id, UpdateCountryDto countryDto)
        {
            Country country = _context.Countries.FirstOrDefault(p => p.Id == id);
            if (country == null)
                return Result.Fail("Not Found");
            _mapper.Map(countryDto, country);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteCountry(int id)
        {
            Country country = _context.Countries.FirstOrDefault(p => p.Id == id);
            if (country == null)
                return Result.Fail("Not Found");
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
