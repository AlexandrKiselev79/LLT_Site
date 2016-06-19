using System;
using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITournamentService
    {
        void Create(Tournament tournament);
        void Update(Tournament tournament);
        void Delete(Tournament tournament);

        Tournament GetById(int tournamentId);
        TournamentDetailsModel GetDetailsById(int tournamentId);
        List<Tournament> GetAll();
        List<Tournament> GetAllInPeriod(DateTime startDate, DateTime endDate);
        List<Tournament> GetAll(TournamentType searchType, string searchName);
    }
}
