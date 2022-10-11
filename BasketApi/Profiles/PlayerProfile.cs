using AutoMapper;
using BasketApi.Data.Dtos.Players;
using BasketApi.Models;

namespace BasketApi.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<CreatePlayerDto, Player>();
        }
    }
}
