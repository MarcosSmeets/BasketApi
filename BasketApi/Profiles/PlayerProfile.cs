using AutoMapper;
using BasketApi.Data.Dtos.Players;
using BasketApi.Models;

namespace BasketApi.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<UpdatePlayerDto, Player>();
            CreateMap<CreatePlayerDto, Player>();
            CreateMap<Player, ReadPlayerDto>();
        }
    }
}
