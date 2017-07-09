namespace ApiBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Londitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        User_Id = c.String(maxLength: 128),
                        Dive_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Dives", t => t.Dive_ID)
                .Index(t => t.User_Id)
                .Index(t => t.Dive_ID);
            
            CreateTable(
                "dbo.DiveGears",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Supplier_ID = c.Long(),
                        Type_ID = c.Long(),
                        Diver_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .ForeignKey("dbo.GearTypes", t => t.Type_ID)
                .ForeignKey("dbo.Divers", t => t.Diver_ID)
                .Index(t => t.Supplier_ID)
                .Index(t => t.Type_ID)
                .Index(t => t.Diver_ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GearTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Required = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dives",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Londitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Time = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DivePosts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        Poster_ID = c.Long(),
                        Dive_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Divers", t => t.Poster_ID)
                .ForeignKey("dbo.Dives", t => t.Dive_ID)
                .Index(t => t.Poster_ID)
                .Index(t => t.Dive_ID);
            
            CreateTable(
                "dbo.DiveLogs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Log = c.String(),
                        Dive_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dives", t => t.Dive_ID)
                .Index(t => t.Dive_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiveLogs", "Dive_ID", "dbo.Dives");
            DropForeignKey("dbo.DivePosts", "Dive_ID", "dbo.Dives");
            DropForeignKey("dbo.DivePosts", "Poster_ID", "dbo.Divers");
            DropForeignKey("dbo.Divers", "Dive_ID", "dbo.Dives");
            DropForeignKey("dbo.Divers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DiveGears", "Diver_ID", "dbo.Divers");
            DropForeignKey("dbo.DiveGears", "Type_ID", "dbo.GearTypes");
            DropForeignKey("dbo.DiveGears", "Supplier_ID", "dbo.Suppliers");
            DropIndex("dbo.DiveLogs", new[] { "Dive_ID" });
            DropIndex("dbo.DivePosts", new[] { "Dive_ID" });
            DropIndex("dbo.DivePosts", new[] { "Poster_ID" });
            DropIndex("dbo.DiveGears", new[] { "Diver_ID" });
            DropIndex("dbo.DiveGears", new[] { "Type_ID" });
            DropIndex("dbo.DiveGears", new[] { "Supplier_ID" });
            DropIndex("dbo.Divers", new[] { "Dive_ID" });
            DropIndex("dbo.Divers", new[] { "User_Id" });
            DropTable("dbo.DiveLogs");
            DropTable("dbo.DivePosts");
            DropTable("dbo.Dives");
            DropTable("dbo.GearTypes");
            DropTable("dbo.Suppliers");
            DropTable("dbo.DiveGears");
            DropTable("dbo.Divers");
        }
    }
}
