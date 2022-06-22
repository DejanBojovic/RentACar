namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'16125e81-5be0-460f-8a19-864964ffc311', N'perica@gmail.com', 0, N'ALZb82pnRPmq2+8imv/ttYpNYapLlSnXhNBGvnZ84IFlfGKy8TxF5A1F8DFJhg3M8w==', N'3014dd9c-7122-4acc-887c-bc0528cd9664', NULL, 0, 0, NULL, 1, 0, N'perica@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ca8e05d-ea3f-49a1-a2e5-bf50e0399f7f', N'admin@gmail.com', 0, N'ACTBNXeQZ1No7CpKbFdA7GYapfraRaX6O4Sr5mkWKoSYdQtddXACdBNPEbI0yFjXLw==', N'24a374c4-7446-4e16-a18e-0ae602a23abe', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3eae4b7c-a843-4670-a8cc-2221bf0bb0df', N'menadzer@gmail.com', 0, N'AFHcVJ59kMt1DsdgRY5K4FhE2ZLfAGCU7B3S0lOG7nQm2dVTmRvNi/BsACNv7JRrUw==', N'38b9a83e-5995-4561-9445-56e7f3e958d4', NULL, 0, 0, NULL, 1, 0, N'menadzer@gmail.com')
            ");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5e5f86f4-e2f4-4a15-b35a-27994cb5e654', N'CanManageAll')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd11c841d-a51b-433e-b5e0-5a1521f0db4f', N'CanManageCars')
                ");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ca8e05d-ea3f-49a1-a2e5-bf50e0399f7f', N'5e5f86f4-e2f4-4a15-b35a-27994cb5e654')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3eae4b7c-a843-4670-a8cc-2221bf0bb0df', N'd11c841d-a51b-433e-b5e0-5a1521f0db4f')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
