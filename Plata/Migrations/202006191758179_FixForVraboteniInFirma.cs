namespace Plata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForVraboteniInFirma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vrabotens", "firmaId", "dbo.Firmas");
            DropIndex("dbo.Vrabotens", new[] { "firmaId" });
            DropColumn("dbo.Vrabotens", "firmaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vrabotens", "firmaId", c => c.Long(nullable: false));
            CreateIndex("dbo.Vrabotens", "firmaId");
            AddForeignKey("dbo.Vrabotens", "firmaId", "dbo.Firmas", "id", cascadeDelete: true);
        }
    }
}
