using Nop.Admin.Extensions;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Extensions
{
    public static class MappingExtensions
    {
        public static PlayerModel ToModel(this Player entity)
        {
            return entity.MapTo<Player, PlayerModel>();
        }

        public static Player ToEntity(this PlayerModel model)
        {
            return model.MapTo<PlayerModel, Player>();
        }

        public static TournamentModel ToModel(this Tournament entity)
        {
            return entity.MapTo<Tournament, TournamentModel>();
        }

        public static Tournament ToEntity(this TournamentModel model)
        {
            return model.MapTo<TournamentModel, Tournament>();
        }

        public static Match ToEntity(this MatchModel model)
        {
            return model.MapTo<MatchModel, Match>();
        }
    }
}
