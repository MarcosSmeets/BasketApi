using AutoMapper;
using BasketApi.Data;
using BasketApi.Data.Dtos.Possitions;
using BasketApi.Models;
using FluentResults;

namespace BasketApi.Services
{
    public class PossitionService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PossitionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadPossitionDto PostPossition(CreatePossitionDto possitionDto)
        {
            Possition possition = _mapper.Map<Possition>(possitionDto);
            _context.Possitions.Add(possition);
            _context.SaveChanges();
            return _mapper.Map<ReadPossitionDto>(possition);
        }

        public ReadPossitionDto GetPossitionById(int id)
        {
            Possition possition = _context.Possitions.FirstOrDefault(p => p.Id == id);
            if (possition != null)
            {
                ReadPossitionDto result = _mapper.Map<ReadPossitionDto>(possition);
                return result;
            }
            return null;
        }

        public List<ReadPossitionDto> GetPossition()
        {
            List<Possition> possition;
            possition = _context.Possitions.ToList();
            if (possition != null)
            {
                List<ReadPossitionDto> readDto = _mapper.Map<List<ReadPossitionDto>>(possition);
                return readDto;
            }
            return null;
        }

        public Result UpdatePossition(int id, UpdatePossitionDto possitionDto)
        {
            Possition possition = _context.Possitions.FirstOrDefault(p => p.Id == id);
            if (possition == null)
                return Result.Fail("Not Found");
            _mapper.Map(possitionDto, possition);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletePossition(int id)
        {
            Possition possition = _context.Possitions.FirstOrDefault(p => p.Id == id);
            if (possition == null)
                return Result.Fail("Not Found");
            _context.Possitions.Remove(possition);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
