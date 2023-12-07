namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6a5e48a0-9b8f-4dc9-8de3-900feb3cf0f8', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'422d5223-64c0-4193-8251-0c6d18b68775', N'CanManageMovies')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e1b221bf-a98f-4060-b647-7e309ca0a469', N'Employee')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f1e97ded-9806-403c-b419-f5327975d9d4', N'Manager')");
        }
        
        public override void Down()
        {
        }
    }
}
