using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Models
{
    public class Head2HeadModel
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public List<Match> ChallengeMatches { get; set; }
        //public List<> TournamentMatches { get; set; }
    }
}
