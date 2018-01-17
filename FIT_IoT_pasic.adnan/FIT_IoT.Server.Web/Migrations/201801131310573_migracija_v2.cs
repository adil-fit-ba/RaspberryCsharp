using System.Data.Entity.Migrations;

namespace FIT_IoT.Server.Web.Migrations
{
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
