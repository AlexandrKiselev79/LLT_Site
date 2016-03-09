using Nop.Plugin.Misc.LLT.Models.Player;

namespace Nop.Plugin.Misc.LLT.Models.Match
{
    public class SetResultModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Player1Games { get; set; }

        public int Player2Games { get; set; }

        public int Player1TieBreak { get; set; }

        public int Player2TieBreak { get; set; }

        public PlayerModel Player1 { get; set; }

        public PlayerModel Player2 { get; set; }

        public bool WonBy(int playerid)
        {
            if (Player1.Id == playerid
                && Player1Games > Player2Games)
                return true;

            if (Player2.Id == playerid
                && Player2Games > Player1Games)
                return true;

            return false;
        }
    }
}
