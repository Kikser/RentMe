namespace RentMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreatAA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        RentTime = c.Int(nullable: false),
                        Accommodations_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Accommodations_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Accommodations_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AlterColumn("dbo.Accommodations", "RentSale", c => c.Int(nullable: false));
            AlterColumn("dbo.Accommodations", "Types", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Accommodations_Id", "dbo.Accommodations");
            DropIndex("dbo.Rents", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "Accommodations_Id" });
            AlterColumn("dbo.Accommodations", "Types", c => c.Byte(nullable: false));
            AlterColumn("dbo.Accommodations", "RentSale", c => c.Byte(nullable: false));
            DropTable("dbo.Rents");
            DropTable("dbo.Orders");
        }
    }
}
