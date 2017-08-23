namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9da125bf-eecd-4d07-bf48-4b5cc40d8200', N'admin@bidly.com', 0, N'AD2D1+vnQjVUpiFbC//uMZkTlrbKhErNHTvIcmfRM4rqSRYSbzoCfk65Kduv6X+hCA==', N'bfe079b2-35b7-46ba-98cf-d82d54aee47b', NULL, 0, 0, NULL, 1, 0, N'admin@bidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dcc2d582-f01a-41b6-a385-12c0c74f1d07', N'quest@bidly.com', 0, N'AHt/D8EvIFpqx2yWfWH2GC07jmBDKx8Gp4B2Hw8kq2Aa2uW5Rd4iSbYIfigHo4751g==', N'924afca9-903a-42d8-850c-002bb969bbac', NULL, 0, 0, NULL, 1, 0, N'quest@bidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ca5a0edf-5c90-4a0b-82fa-6da1a739283f', N'CanManageMovie')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9da125bf-eecd-4d07-bf48-4b5cc40d8200', N'ca5a0edf-5c90-4a0b-82fa-6da1a739283f')
");
        }
        
        public override void Down()
        {
        }
    }
}
