namespace Plata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMig3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vrabotens", "sifra", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vrabotens", "sifra", c => c.Int(nullable: false));
        }
    }
}
