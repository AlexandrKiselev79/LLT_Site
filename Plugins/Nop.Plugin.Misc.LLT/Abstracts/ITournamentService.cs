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

        void AddPlayer(Tournament tournament, Player player);
        void UpdatePlayer(Tournament tournament, Player player);
        void RemovePlayer(Tournament tournament, Player player);

        void AddMatch(Tournament tournament, Match match);
        Match GetMatchById(int tournamentId, int matchId);
        void UpdateMatch(Tournament tournament, Match match);
        void RemoveMatch(Tournament tournament, Match match);

        Tournament GetById(int tournamentId);
        TournamentDetailsModel GetDetailsById(int tournamentId);
        List<Tournament> GetAll();
        List<Tournament> GetAllInPeriod(DateTime startDate, DateTime endDate);
        List<Tournament> GetAll(TournamentType searchType, string searchName);
    }
}
