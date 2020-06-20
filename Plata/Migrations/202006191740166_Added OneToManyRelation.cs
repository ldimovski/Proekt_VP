namespace Plata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneToManyRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vrabotens", "firmaId", c => c.Long(nullable: false));
            CreateIndex("dbo.Vrabotens", "firmaId");
            AddForeignKey("dbo.Vrabotens", "firmaId", "dbo.Firmas", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vrabotens", "firmaId", "dbo.Firmas");
            DropIndex("dbo.Vrabotens", new[] { "firmaId" });
            DropColumn("dbo.Vrabotens", "firmaId");
        }
    }
}
