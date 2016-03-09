using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models.TennisClub;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class TennisClubService : ITennisClubService
    {
        private readonly IRepository<TennisClub> _tennisClubRepository;

        public TennisClubService(IRepository<TennisClub> tennisClubRepository)
        {
            _tennisClubRepository = tennisClubRepository;
        }

        public void Add(TennisClub club)
        {
            _tennisClubRepository.Insert(club);
        }

        public void Update(TennisClub club)
        {
            _tennisClubRepository.Update(club);
        }

        public void Delete(TennisClub club)
        {
            club.Deleted = true;
            _tennisClubRepository.Update(club);
        }

        public TennisClubModel GetById(int clubId)
        {
            return Mapper.Map<TennisClub, TennisClubModel>(_tennisClubRepository.GetById(clubId));
        }

        public List<TennisClubModel> GetAll()
        {
            return _tennisClubRepository.Table.Select(Mapper.Map<TennisClub, TennisClubModel>).ToList();
        }
    }
}
