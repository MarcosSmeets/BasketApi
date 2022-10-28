using AutoMapper;
using BasketApi.Data.Dtos.Possitions;
using BasketApi.Models;

namespace BasketApi.Profiles
{
    public class PossitionProfile : Profile
    {
        public PossitionProfile()
        {
            CreateMap<CreatePossitionDto, Possition>();
            CreateMap<Possition, ReadPossitionDto>()
                .ForMember(po => po.Players,
                opts => opts.MapFrom(po => po.Players.Select(p => new {p.Id, p.Name,p.Age, p.JarseyNumber, p.Team})));
            CreateMap<UpdatePossitionDto, Possition>();
        }
        
    }
}
