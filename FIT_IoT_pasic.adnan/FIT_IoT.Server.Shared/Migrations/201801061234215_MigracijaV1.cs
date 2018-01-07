namespace FIT_IoT.Server.Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracijaV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Komandas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumEvidentiranja = c.DateTime(nullable: false),
                        DatumIzvrsenja = c.DateTime(),
                        JelIzvrsena = c.Boolean(nullable: false),
                        VrstaKomande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Komandas");
        }
    }
}
