namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMOnths, DiscountRate) VALUES (0,0,0)");
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMOnths, DiscountRate) VALUES (30,1,10)");
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMOnths, DiscountRate) VALUES (90,3,15)");
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMOnths, DiscountRate) VALUES (100,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
