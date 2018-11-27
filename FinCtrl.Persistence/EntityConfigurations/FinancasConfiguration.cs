using FinCtrl.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FinCtrl.Persistence.EntityConfigurations
{
    public class FinancasConfiguration : EntityTypeConfiguration<Financas>
    {
        public FinancasConfiguration()
        {
            Property(f => f.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(f => f.Nome).HasMaxLength(255);
            Property(f => f.Observacao).IsOptional().HasMaxLength(25555);

            HasRequired(t => t.Tipo)
                .WithMany(f => f.Financas)
                .HasForeignKey(d => d.TipoId)
                .WillCascadeOnDelete(false);
        }
    }
}
