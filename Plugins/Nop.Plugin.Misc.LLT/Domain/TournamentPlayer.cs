using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TournamentPlayer : BaseEntity
    {
        public TournamentPlayer()
        {
        }

        public TournamentPlayer(Tournament tournament, Player player)
        {
            this.Tournament = tournament;
            this.Player = player;
        }

        public Tournament Tournament { get; set; }
        public Player Player { get; set; }
    }
}