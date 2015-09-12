using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            modelBuilder.Configurations.Add(new PlayerMap());
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
            this.DropPluginTable("Player");
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
