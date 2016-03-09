using Autofac;
using Autofac.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Data;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Service;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Misc.LLT.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_llt";

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            this.RegisterPluginDataContext<LLTObjectContext>(builder, CONTEXT_NAME);

            #region Repositories

            builder.RegisterType<EfRepository<Player>>()
                .As<IRepository<Player>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<SetResult>>()
                .As<IRepository<SetResult>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Match>>()
                .As<IRepository<Match>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
            
            builder.RegisterType<EfRepository<Address>>()
                .As<IRepository<Address>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<TennisClub>>()
                .As<IRepository<TennisClub>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<PlayerResult>>()
                .As<IRepository<PlayerResult>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<TieBreakResult>>()
                .As<IRepository<TieBreakResult>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Tournament>>()
                .As<IRepository<Tournament>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<TournamentClub>>()
                .As<IRepository<TournamentClub>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<TournamentMatch>>()
                .As<IRepository<TournamentMatch>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            #endregion

            #region Services

            builder.RegisterType<PlayerService>().As<IPlayerService>().InstancePerLifetimeScope();
            builder.RegisterType<TournamentService>().As<ITournamentService>().InstancePerLifetimeScope();
            builder.RegisterType<ChallengeService>().As<IChallengeService>().InstancePerLifetimeScope();
            builder.RegisterType<TournamentMatchService>().As<ITournamentMatchService>().InstancePerLifetimeScope();
            builder.RegisterType<TennisClubService>().As<ITennisClubService>().InstancePerLifetimeScope();

            #endregion
        }

        public int Order { get; private set; }
    }
}
