using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Services.Logging;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class LLTObjectContext : DbContext, IDbContext
    {
        private ILogger _logger;

        public LLTObjectContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new MatchMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new SetResultMap());
            modelBuilder.Configurations.Add(new TennisClubMap());
            modelBuilder.Configurations.Add(new PlayerResultMap());
            modelBuilder.Configurations.Add(new TieBreakResultMap());
            modelBuilder.Configurations.Add(new TournamentMap());
            modelBuilder.Configurations.Add(new TournamentMatchMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public string CreateDatabaseInstallationScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public void Install()
        {
            try
            {
                Database.SetInitializer<LLTObjectContext>(null);
                Database.ExecuteSqlCommand(CreateDatabaseInstallationScript());
                SaveChanges();
            }
            catch (Exception ex)
            {
                _logger = EngineContext.Current.Resolve<ILogger>();
                _logger.Error("LLT installation process.", ex);
            }
        }

        public void Uninstall()
        {
            //this.DropPluginTable(TablesName.PlayerResultTable);
            //this.DropPluginTable(TablesName.TournamentTable);
            //this.DropPluginTable(TablesName.MatchTable);
            //this.DropPluginTable(TablesName.TennisClubTable);
            //this.DropPluginTable(TablesName.TieBreakResultTable);
            //this.DropPluginTable(TablesName.PlayerTable);
            //this.DropPluginTable(TablesName.SetResultTable);
            //this.DropPluginTable(TablesName.AddressTable);
        }
        
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }

        public bool ProxyCreationEnabled { get; set; }
        public bool AutoDetectChangesEnabled { get; set; }
    }
}
