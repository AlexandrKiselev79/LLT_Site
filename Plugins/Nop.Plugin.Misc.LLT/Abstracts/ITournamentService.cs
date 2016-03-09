using System;
using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITournamentService
    {
        void Create(Tournament tournament);
        void Update(Tournament tournament);
        void Delete(Tournament tournament);

        TournamentModel GetById(int tournamentId);
        TournamentDetailsModel GetDetailsById(int tournamentId);
        List<TournamentModel> GetAll();
        List<TournamentModel> GetAllInPeriod(DateTime startDate, DateTime endDate);
    }
}
