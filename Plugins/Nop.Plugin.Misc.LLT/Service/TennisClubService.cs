using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;

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

        public TennisClub GetById(int clubId)
        {
            return _tennisClubRepository.GetById(clubId);
        }

        public List<TennisClub> GetAll()
        {
            return _tennisClubRepository.Table.ToList();
        }
    }
}
