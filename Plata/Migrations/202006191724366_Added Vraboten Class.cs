namespace Plata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVrabotenClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vrabotens",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        ime = c.String(),
                        datumPriem = c.DateTime(nullable: false),
                        datumOtkaz = c.DateTime(),
                        pol = c.String(),
                        embg = c.String(),
                        adresa = c.String(),
                        opstina = c.String(),
                        transakciskaSmetka = c.String(),
                        podracnaEdinica = c.String(),
                        email = c.String(),
                        brutoPlata = c.Int(nullable: false),
                        netoPlata = c.Int(nullable: false),
                        sifra = c.Int(nullable: false),
                        skrateno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vrabotens");
        }
    }
}
