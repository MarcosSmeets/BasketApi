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
            CreateMap<Country, ReadCountryDto>()
                .ForMember(c => c.Players,
                opts => opts.MapFrom(c => c.Players.Select(c => new { c.Id, c.Name, c.Age, c.JarseyNumber, c.Team })));
            CreateMap<UpdateCountryDto, Country>();
        }
    }
}
