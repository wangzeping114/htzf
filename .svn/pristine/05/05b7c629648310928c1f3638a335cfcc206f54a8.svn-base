namespace WS.HTZF.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TWS_Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CreateAt = c.DateTime(nullable: false, precision: 0),
                        LatestUpdatedAt = c.DateTime(nullable: false, precision: 0),
                        FullName = c.String(maxLength: 50, storeType: "nvarchar"),
                        IsDisplay = c.Boolean(nullable: false),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TWS_Role", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TWS_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        IsSuperAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TWS_RoleMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permission = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TWS_Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.TWS_Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TWS_Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Icon = c.String(maxLength: 100, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        ActionSref = c.String(maxLength: 200, storeType: "nvarchar"),
                        Path = c.String(maxLength: 100, storeType: "nvarchar"),
                        Level = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TWS_Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.TWS_Commodity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitileOrName = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        SerialNumber = c.String(maxLength: 200, storeType: "nvarchar"),
                        CommodityStatus = c.Int(nullable: false),
                        ImagePath = c.String(unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sequence = c.Int(nullable: false),
                        ShelfTime = c.DateTime(precision: 0),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        AsOfTime = c.DateTime(nullable: false, precision: 0),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tws_Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tws_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(maxLength: 200, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Sequence = c.Int(),
                        IsDisplay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tws_CommodityDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Introduction = c.String(maxLength: 2000, storeType: "nvarchar"),
                        Description = c.String(maxLength: 2000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TWS_Commodity", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.tws_CommodityDetailPirture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(maxLength: 200, storeType: "nvarchar"),
                        Sequence = c.Int(),
                        CommodityDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tws_CommodityDetail", t => t.CommodityDetailId, cascadeDelete: true)
                .Index(t => t.CommodityDetailId);
            
            CreateTable(
                "dbo.tws_Stock",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ReservedQuantity = c.Int(),
                        HaveSalesQuantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TWS_Commodity", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tws_Stock", "Id", "dbo.TWS_Commodity");
            DropForeignKey("dbo.tws_CommodityDetailPirture", "CommodityDetailId", "dbo.tws_CommodityDetail");
            DropForeignKey("dbo.tws_CommodityDetail", "Id", "dbo.TWS_Commodity");
            DropForeignKey("dbo.TWS_Commodity", "CategoryId", "dbo.tws_Category");
            DropForeignKey("dbo.TWS_RoleMenu", "RoleId", "dbo.TWS_Role");
            DropForeignKey("dbo.TWS_RoleMenu", "MenuId", "dbo.TWS_Menu");
            DropForeignKey("dbo.TWS_Menu", "ParentId", "dbo.TWS_Menu");
            DropForeignKey("dbo.TWS_Account", "RoleId", "dbo.TWS_Role");
            DropIndex("dbo.tws_Stock", new[] { "Id" });
            DropIndex("dbo.tws_CommodityDetailPirture", new[] { "CommodityDetailId" });
            DropIndex("dbo.tws_CommodityDetail", new[] { "Id" });
            DropIndex("dbo.TWS_Commodity", new[] { "CategoryId" });
            DropIndex("dbo.TWS_Menu", new[] { "ParentId" });
            DropIndex("dbo.TWS_RoleMenu", new[] { "RoleId" });
            DropIndex("dbo.TWS_RoleMenu", new[] { "MenuId" });
            DropIndex("dbo.TWS_Account", new[] { "RoleId" });
            DropTable("dbo.tws_Stock");
            DropTable("dbo.tws_CommodityDetailPirture");
            DropTable("dbo.tws_CommodityDetail");
            DropTable("dbo.tws_Category");
            DropTable("dbo.TWS_Commodity");
            DropTable("dbo.TWS_Menu");
            DropTable("dbo.TWS_RoleMenu");
            DropTable("dbo.TWS_Role");
            DropTable("dbo.TWS_Account");
        }
    }
}
