namespace FinCtrl.Persistence.Migrations
{
    using FinCtrl.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FinCtrl.Persistence.FinCtrlDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinCtrl.Persistence.FinCtrlDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Tipos.AddOrUpdate(x => x.Id,
                new Tipo() { Id = 1, Nome = "Despesa" },
                new Tipo() { Id = 2, Nome = "Rendimento" }
            );

            context.Financas.AddOrUpdate(x => x.Id,
                new Financas() { Id = 1, Nome = "Internet bill", TipoId = 1, Data = DateTime.Now.AddDays(3), Observacao = "", Valor = 100 },
                new Financas() { Id = 2, Nome = "Web freelance payment", TipoId = 2, Data = DateTime.Now.AddDays(5), Observacao = "", Valor = 220},
                new Financas() { Id = 3, Nome = "Russell payback", TipoId = 2, Data = DateTime.Now.AddDays(8), Observacao = "", Valor = 8 },
                new Financas() { Id = 4, Nome = "Credit card bill", TipoId = 1, Data = DateTime.Now.AddDays(10), Observacao = "", Valor = 250 },
                new Financas() { Id = 5, Nome = "Netflix", TipoId = 1, Data = DateTime.Now.AddDays(10), Observacao = "", Valor = 50 },
                new Financas() { Id = 6, Nome = "Mobile freelance payment", TipoId = 2, Data = DateTime.Now.AddDays(11), Observacao = "", Valor = 280 },
                new Financas() { Id = 7, Nome = "Mom's party", TipoId = 1, Data = DateTime.Now.AddDays(11), Observacao = "", Valor = 300 },
                new Financas() { Id = 8, Nome = "Shopping hangout", TipoId = 1, Data = DateTime.Now.AddDays(15), Observacao = "", Valor = 250 },
                new Financas() { Id = 9, Nome = "Monthly payment", TipoId = 2, Data = DateTime.Now.AddDays(18), Observacao = "", Valor = 1200 },
                new Financas() { Id = 10, Nome = "Valentine's day gift", TipoId = 1, Data = DateTime.Now.AddDays(20), Observacao = "", Valor = 300 }
            );

        }
    }
}
