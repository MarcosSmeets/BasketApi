using AutoMapper;
using BasketApi.Data;
using BasketApi.Data.Dtos.Teams;
using BasketApi.Models;
using FluentResults;

namespace BasketApi.Services
{
    public class TeamService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TeamService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadTeamDto PostTeam(CreateTeamDto teamDto)
        {
            Team team = _mapper.Map<Team>(teamDto);
            _context.Teams.Add(team);
            _context.SaveChanges();
            return _mapper.Map<ReadTeamDto>(teamDto);
        }

        public ReadTeamDto GetTeamById(int id)
        {
            Team team = _context.Teams.FirstOrDefault(p => p.Id == id);
            if (team != null)
            {
                ReadTeamDto result = _mapper.Map<ReadTeamDto>(team);
                return result;
            }
            return null;
        }

        public List<ReadTeamDto> GetTeam()
        {
            List<Team> team;
            team = _context.Teams.ToList();
            if (team != null)
            {
                List<ReadTeamDto> readDto = _mapper.Map<List<ReadTeamDto>>(team);
                return readDto;
            }
            return null;
        }

        public Result UpdateTeam(int id, UpdateTeamDto teamDto)
        {
            Team team = _context.Teams.FirstOrDefault(p => p.Id == id);
            if (team == null)
                return Result.Fail("Not Found");
            _mapper.Map(teamDto, team);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteTeam(int id)
        {
            Team team = _context.Teams.FirstOrDefault(p => p.Id == id);
            if (team == null)
                return Result.Fail("Not Found");
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
