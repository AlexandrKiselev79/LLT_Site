using Nop.Admin.Extensions;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models.Player;

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
    }
}
