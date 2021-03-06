namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "CarId", "dbo.Cars");
            DropIndex("dbo.Rentals", new[] { "CarId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropTable("dbo.Rentals");
        }
    }
}
