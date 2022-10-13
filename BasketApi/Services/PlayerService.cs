using AutoMapper;
using BasketApi.Data;
using BasketApi.Data.Dtos.Players;
using BasketApi.Models;
using FluentResults;

namespace BasketApi.Services
{
    public class PlayerService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PlayerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPlayerDto PostPlayer(CreatePlayerDto playerDto)
        {
            Player player = _mapper.Map<Player>(playerDto);
            _context.Players.Add(player);
            _context.SaveChanges();
            return _mapper.Map<ReadPlayerDto>(player);
        }

        public ReadPlayerDto GetPlayerById(int id)
        {
            Player player = _context.Players.FirstOrDefault(p => p.Id == id);
            if(player != null)
            {
                ReadPlayerDto result = _mapper.Map<ReadPlayerDto>(player);
                return result;
            }
            return null;
        }

        public List<ReadPlayerDto> GetPlayer()
        {
            List<Player> players;
            players = _context.Players.ToList();
            if(players != null)
            {
                List<ReadPlayerDto> readDto = _mapper.Map<List<ReadPlayerDto>>(players);
                return readDto;
            }
            return null;
        }

        public Result PutPlayer(int id, UpdatePlayerDto playerDto)
        {
            Player player = _context.Players.FirstOrDefault(p => p.Id==id);
            if (player == null)
                return Result.Fail("Not Found");
            _mapper.Map(playerDto, player);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletePlayer(int id)
        {
            Player player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return Result.Fail("Not Found");
            _context.Players.Remove(player);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
