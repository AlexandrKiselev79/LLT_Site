using Autofac;
using Autofac.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Misc.LLT.Data;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Misc.LLT.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_llt";

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            this.RegisterPluginDataContext<LLTObjectContext>(builder, CONTEXT_NAME);

            builder.RegisterType<EfRepository<Player>>()
                .As<IRepository<Player>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
        }

        public int Order { get; private set; }
    }
}
