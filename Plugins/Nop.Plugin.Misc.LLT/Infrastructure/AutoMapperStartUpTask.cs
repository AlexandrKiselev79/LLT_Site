using AutoMapper;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.TennisClub;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Infrastructure
{
    public class AutoMapperStartUpTask : IStartupTask
    {
        public void Execute()
        {
            Mapper.CreateMap<Domain.Player, PlayerModel>();
            Mapper.CreateMap<PlayerModel, Domain.Player>();
            Mapper.CreateMap<Domain.Tournament, TournamentModel>();
            Mapper.CreateMap<TournamentModel, Domain.Tournament>();
            Mapper.CreateMap<Domain.Match, MatchModel>();
            Mapper.CreateMap<Domain.SetResult, SetResultModel>();
            Mapper.CreateMap<Domain.TennisClub, TennisClubModel>();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
