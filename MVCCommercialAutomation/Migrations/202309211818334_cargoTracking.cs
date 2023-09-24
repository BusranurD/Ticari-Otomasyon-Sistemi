namespace MVCCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargoTracking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CargoID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        TrackingNo = c.String(maxLength: 100, unicode: false),
                        Employes = c.String(maxLength: 20, unicode: false),
                        Recipient = c.String(maxLength: 20, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoID);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        TrackingNo = c.String(maxLength: 10, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.Cargoes");
        }
    }
}
