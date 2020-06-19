namespace Plata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirmaAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Firmas",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        ime = c.String(),
                        adresa = c.String(),
                        naselenoMesto = c.String(),
                        opstina = c.String(),
                        telefon = c.String(),
                        email = c.String(),
                        dejnost = c.String(),
                        ziroSmetka = c.String(),
                        edb = c.String(),
                        posta = c.String(),
                        broj = c.String(),
                        grad = c.String(),
                        povBroj = c.String(),
                        faks = c.String(),
                        minTrud = c.Boolean(nullable: false),
                        odBruto = c.Boolean(nullable: false),
                        zastita = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Firmas");
        }
    }
}
