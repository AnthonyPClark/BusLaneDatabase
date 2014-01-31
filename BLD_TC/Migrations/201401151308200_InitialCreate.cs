namespace BLD_TC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        BusLane_ID = c.Int(),
                        BusLaneEditModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BusLanes", t => t.BusLane_ID)
                .ForeignKey("dbo.BusLaneEditModels", t => t.BusLaneEditModel_ID)
                .Index(t => t.BusLane_ID)
                .Index(t => t.BusLaneEditModel_ID);
            
            CreateTable(
                "dbo.BusLanes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        implementationDate = c.DateTime(nullable: false),
                        startTime = c.DateTime(nullable: false),
                        endTime = c.DateTime(nullable: false),
                        length = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        removed = c.Boolean(nullable: false),
                        removedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusLaneEditModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        implementationDate = c.DateTime(nullable: false),
                        startTime = c.DateTime(nullable: false),
                        endTime = c.DateTime(nullable: false),
                        length = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "BusLaneEditModel_ID" });
            DropIndex("dbo.Vehicles", new[] { "BusLane_ID" });
            DropForeignKey("dbo.Vehicles", "BusLaneEditModel_ID", "dbo.BusLaneEditModels");
            DropForeignKey("dbo.Vehicles", "BusLane_ID", "dbo.BusLanes");
            DropTable("dbo.BusLaneEditModels");
            DropTable("dbo.BusLanes");
            DropTable("dbo.Vehicles");
        }
    }
}
