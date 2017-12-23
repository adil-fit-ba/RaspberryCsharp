namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Komandas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JelIzvrsena = c.Boolean(nullable: false),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Komandas");
        }
    }
}
