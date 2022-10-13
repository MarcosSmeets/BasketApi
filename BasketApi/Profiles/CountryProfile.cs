using AutoMapper;
using BasketApi.Data.Dtos.Countrys;
using BasketApi.Models;

namespace BasketApi.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountryDto, Country>();
            CreateMap<Country, ReadCountryDto>();
            CreateMap<UpdateCountryDto, Country>();
        }
    }
}
