namespace FinCtrl.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Financas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255),
                        Data = c.DateTime(nullable: false),
                        Observacao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.TipoId)
                .Index(t => t.TipoId);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Financas", "TipoId", "dbo.Tipo");
            DropIndex("dbo.Financas", new[] { "TipoId" });
            DropTable("dbo.Tipo");
            DropTable("dbo.Financas");
        }
    }
}
