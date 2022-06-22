namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
    }
}
