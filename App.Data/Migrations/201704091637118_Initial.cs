namespace App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocType",
                c => new
                    {
                        DocTypeId = c.Byte(nullable: false),
                        DocTypeDesc = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DocTypeId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RequestDesc = c.String(nullable: false, maxLength: 100),
                        StatusId = c.Byte(nullable: false),
                        StateId = c.Int(nullable: false),
                        RequestDocTypeId = c.Byte(nullable: false),
                        ReceiveDocTypeId = c.Byte(nullable: false),
                        DeptId = c.Int(nullable: false),
                        DivId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.DocType", t => t.ReceiveDocTypeId)
                .ForeignKey("dbo.DocType", t => t.RequestDocTypeId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.RequestDocTypeId)
                .Index(t => t.ReceiveDocTypeId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Byte(nullable: false),
                        StatusDesc = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Request", "RequestDocTypeId", "dbo.DocType");
            DropForeignKey("dbo.Request", "ReceiveDocTypeId", "dbo.DocType");
            DropIndex("dbo.Request", new[] { "ReceiveDocTypeId" });
            DropIndex("dbo.Request", new[] { "RequestDocTypeId" });
            DropIndex("dbo.Request", new[] { "StatusId" });
            DropTable("dbo.Status");
            DropTable("dbo.Request");
            DropTable("dbo.DocType");
        }
    }
}
