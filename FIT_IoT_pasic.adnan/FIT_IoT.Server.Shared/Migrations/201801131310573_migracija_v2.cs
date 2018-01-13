namespace FIT_IoT.Server.Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija_v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Temperaturas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Temperaturas");
        }
    }
}
