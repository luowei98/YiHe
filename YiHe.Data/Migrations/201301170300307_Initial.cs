namespace YiHe.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuText = c.String(nullable: false),
                        Position = c.Int(nullable: false),
                        UrlController = c.String(nullable: false),
                        UrlAction = c.String(nullable: false),
                        BackgroundImage = c.String(),
                        Role = c.Int(nullable: false),
                        Parent_MenuId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.Menus", t => t.Parent_MenuId)
                .Index(t => t.Parent_MenuId);
            
            CreateTable(
                "dbo.OuterLinks",
                c => new
                    {
                        OuterLinkId = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OuterLinkId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.SliderId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        IconPath = c.String(),
                        MetaDescription = c.String(),
                        MetaKeywords = c.String(),
                    })
                .PrimaryKey(t => t.PartId);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        ElementId = c.Int(nullable: false, identity: true),
                        No = c.Int(nullable: false),
                        Title = c.String(),
                        Detail = c.String(),
                        SubDetail = c.String(),
                        Part_PartId = c.Int(),
                    })
                .PrimaryKey(t => t.ElementId)
                .ForeignKey("dbo.Parts", t => t.Part_PartId)
                .Index(t => t.Part_PartId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Qualification = c.String(),
                        Therapy = c.String(),
                        Skill = c.String(),
                        Introduction = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.OfficePhotoes",
                c => new
                    {
                        OfficePhotoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        MainPhoto = c.String(),
                        SmallerPhoto = c.String(),
                    })
                .PrimaryKey(t => t.OfficePhotoId);
            
            CreateTable(
                "dbo.OfficePhotoDetails",
                c => new
                    {
                        OfficePhotoDetailId = c.Int(nullable: false, identity: true),
                        DetailPhoto = c.String(),
                        OfficePhoto_OfficePhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.OfficePhotoDetailId)
                .ForeignKey("dbo.OfficePhotoes", t => t.OfficePhoto_OfficePhotoId)
                .Index(t => t.OfficePhoto_OfficePhotoId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        ExtractFrom = c.String(),
                        Picture = c.String(),
                        Content = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        BrowseTimes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.Parent_CategoryId)
                .Index(t => t.Parent_CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Used = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastLoginTime = c.DateTime(),
                        Activated = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.TagArticles",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Article_ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Article_ArticleId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Article_ArticleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagArticles", new[] { "Article_ArticleId" });
            DropIndex("dbo.TagArticles", new[] { "Tag_TagId" });
            DropIndex("dbo.Categories", new[] { "Parent_CategoryId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.OfficePhotoDetails", new[] { "OfficePhoto_OfficePhotoId" });
            DropIndex("dbo.Elements", new[] { "Part_PartId" });
            DropIndex("dbo.Menus", new[] { "Parent_MenuId" });
            DropForeignKey("dbo.TagArticles", "Article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.TagArticles", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.Categories", "Parent_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OfficePhotoDetails", "OfficePhoto_OfficePhotoId", "dbo.OfficePhotoes");
            DropForeignKey("dbo.Elements", "Part_PartId", "dbo.Parts");
            DropForeignKey("dbo.Menus", "Parent_MenuId", "dbo.Menus");
            DropTable("dbo.TagArticles");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
            DropTable("dbo.OfficePhotoDetails");
            DropTable("dbo.OfficePhotoes");
            DropTable("dbo.Staffs");
            DropTable("dbo.Elements");
            DropTable("dbo.Parts");
            DropTable("dbo.Sliders");
            DropTable("dbo.OuterLinks");
            DropTable("dbo.Menus");
        }
    }
}
