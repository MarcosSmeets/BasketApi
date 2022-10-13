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
            CreateMap<Team, ReadTeamDto>();
            CreateMap<UpdateTeamDto, Team>();
        }
    }
}
