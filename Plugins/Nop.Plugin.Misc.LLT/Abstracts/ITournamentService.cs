using System;
using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITournamentService
    {
        void Create(Tournament tournament);
        void Update(Tournament tournament);
        void Delete(Tournament tournament);

        Tournament GetById(int tournamentId);
        List<Tournament> GetAll();
        List<Tournament> GetAllInPeriod(DateTime startDate, DateTime endDate);
    }
}
