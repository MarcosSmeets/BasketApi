using AutoMapper;
using BasketApi.Data.Dtos.Teams;
using BasketApi.Models;

namespace BasketApi.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<CreateTeamDto, Team>();
            CreateMap<Team, ReadTeamDto>()
                .ForMember(t => t.Players,
                opts => opts.MapFrom(t => t.Players.Select(p => new { p.Id, p.Name, p.Age,p.Height,p.Weight, p.JarseyNumber })));
            CreateMap<UpdateTeamDto, Team>();
        }
    }
}
