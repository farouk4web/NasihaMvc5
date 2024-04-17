namespace Nasiha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUserAndRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40272751-3bf9-46b3-849c-2d85aac8672c', N'Admins')

                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [Nickname], [ProfileImageSrc]) VALUES (N'8af6d6f7-dd1e-4e55-a71e-2bb448f8be20', N'farouk@nasiha.com', 0, N'AKKQ4c1r3feItuJRBP7qJNDmn59h6wUkMtqkSsl32/UiTEqH/p9e7F+gDoPNTX62kg==', N'9dbb7d22-5f20-4d33-bdbc-3483a90a4474', NULL, 0, 0, NULL, 1, 0, N'farouk@nasiha.com', N'Farouk Abdlhamid', N'farouk', N'/Content/images/user.png')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8af6d6f7-dd1e-4e55-a71e-2bb448f8be20', N'40272751-3bf9-46b3-849c-2d85aac8672c')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
