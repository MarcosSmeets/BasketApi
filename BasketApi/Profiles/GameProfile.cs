using AutoMapper;
using BasketApi.Data.Dtos.Games;
using BasketApi.Models;

namespace BasketApi.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<CreateGameDto, Game>();
            CreateMap<Game, ReadGameDto>();
            CreateMap<UpdateGameDto, Game>();
        }
    }
}
