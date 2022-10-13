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
            CreateMap<Possition, ReadPossitionDto>();
            CreateMap<UpdatePossitionDto, Possition>();
        }
        
    }
}
