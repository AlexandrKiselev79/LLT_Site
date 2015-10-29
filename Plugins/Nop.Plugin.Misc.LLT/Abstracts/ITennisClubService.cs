using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITennisClubService
    {
        void Add(TennisClub club);
        void Update(TennisClub club);
        void Delete(TennisClub club);

        TennisClub GetById(int clubId);
        List<TennisClub> GetAll();
    }
}
