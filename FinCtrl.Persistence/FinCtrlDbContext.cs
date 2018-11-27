using FinCtrl.Domain.Entities;
using FinCtrl.Persistence.EntityConfigurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FinCtrl.Persistence
{
    public class FinCtrlDbContext : DbContext
    {
        public FinCtrlDbContext() : base()
        {
            
        }

        public DbSet<Financas> Financas { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FinancasConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
