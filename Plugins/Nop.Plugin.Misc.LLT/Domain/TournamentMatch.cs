using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TournamentMatch : BaseEntity
    {
        public TournamentMatch() { }

        public TournamentMatch(Tournament tournament, Match match)
        {
            this.Tournament = tournament;
            this.Match = match;
        }

        public Tournament Tournament { get; set; }
        public Match Match { get; set; }
    }
}