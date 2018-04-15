namespace FIT_IoT.Server.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class senzori1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthentificationTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        authToken = c.String(),
                        deviceCpuID = c.String(),
                        deviceHddID = c.String(),
                        deviceMotherBoardID = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        KorisnikID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.KorisnikID)
                .Index(t => t.KorisnikID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Password = c.String(),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        DateExecuteStart = c.DateTime(),
                        DateExecuteEnd = c.DateTime(),
                        CommandType = c.Int(nullable: false),
                        ErrorDescription = c.String(),
                        AuthentificationTokenID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthentificationTokens", t => t.AuthentificationTokenID)
                .Index(t => t.AuthentificationTokenID);
            
            CreateTable(
                "dbo.SensorMeasurements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Vrijednost = c.Double(nullable: false),
                        Date = c.DateTime(),
                        SensorType = c.Int(),
                        SensorId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commands", "AuthentificationTokenID", "dbo.AuthentificationTokens");
            DropForeignKey("dbo.AuthentificationTokens", "KorisnikID", "dbo.Users");
            DropIndex("dbo.Commands", new[] { "AuthentificationTokenID" });
            DropIndex("dbo.AuthentificationTokens", new[] { "KorisnikID" });
            DropTable("dbo.SensorMeasurements");
            DropTable("dbo.Commands");
            DropTable("dbo.Users");
            DropTable("dbo.AuthentificationTokens");
        }
    }
}
