namespace Nasiha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAdvicesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        LikeIt = c.Boolean(nullable: false),
                        PinIt = c.Boolean(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                        Sender = c.String(),
                        ReceiverId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .Index(t => t.ReceiverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advices", "ReceiverId", "dbo.AspNetUsers");
            DropIndex("dbo.Advices", new[] { "ReceiverId" });
            DropTable("dbo.Advices");
        }
    }
}
