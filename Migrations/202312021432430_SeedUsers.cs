namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9cbc0e8f-29fd-4037-b0fe-8eb64066d568', N'admin@vidly.com', 0, N'AK7efx4E97f8F0OZyczhbTRJ01LaKS58oncGuZql9pgjwE5JJrSxzmG9q1l4u0FamQ==', N'1799370b-2715-4068-834c-dfbe255cec07', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e6c0cfbe-6b6f-4acf-9984-a8056e903e43', N'guest@vidly.com', 0, N'AGbcKro1VpP2KCDzUbkAre8nz/nGzaLZpSaXNNM9+E2QMpyyuKeRt1HAdxJsT4opmQ==', N'e9ac64cb-ba2b-4012-95bd-360c25965a5f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'422d5223-64c0-4193-8251-0c6d18b68775', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9cbc0e8f-29fd-4037-b0fe-8eb64066d568', N'422d5223-64c0-4193-8251-0c6d18b68775')
");
        }
        
        public override void Down()
        {
        }
    }
}
