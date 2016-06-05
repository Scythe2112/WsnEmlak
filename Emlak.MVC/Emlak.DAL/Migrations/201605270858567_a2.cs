namespace Emlak.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotograflar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Yol = c.String(),
                        KonutID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Konutlar", t => t.KonutID, cascadeDelete: true)
                .Index(t => t.KonutID);
            
            CreateTable(
                "dbo.Konutlar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OdaSayisi = c.Short(nullable: false),
                        Adres = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        BinaYasi = c.Short(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Metrekare = c.Double(nullable: false),
                        Aciklama = c.String(),
                        Enlem = c.Double(nullable: false),
                        Boylam = c.Double(nullable: false),
                        KullaniciID = c.String(maxLength: 128),
                        KatTuruID = c.Int(nullable: false),
                        IsitmaTuruID = c.Int(nullable: false),
                        IlanTuruID = c.Int(nullable: false),
                        YayindaMi = c.Boolean(nullable: false),
                        Baslik = c.String(),
                        OnaylanmaTarihi = c.Boolean(),
                        KatTur_ID = c.Int(),
                        IsitmaSistemi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IlanTurleri", t => t.IlanTuruID, cascadeDelete: true)
                .ForeignKey("dbo.IsitmaSistemleri", t => t.IsitmaTuruID, cascadeDelete: true)
                .ForeignKey("dbo.KatTurleri", t => t.KatTuruID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.KullaniciID)
                .Index(t => t.KullaniciID)
                .Index(t => t.KatTuruID)
                .Index(t => t.IsitmaTuruID)
                .Index(t => t.IlanTuruID)
                .Index(t => t.KatTur_ID)
                .Index(t => t.IsitmaSistemi_ID);
            
            CreateTable(
                "dbo.IlanTurleri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KatTurleri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tur = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 35),
                        RegisterDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        AvatarPath = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.IsitmaSistemleri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Konutlar", "IsitmaSistemi_ID", "dbo.IsitmaSistemleri");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Konutlar", "KullaniciID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Konutlar", "KatTuruID", "dbo.KatTurleri");
            DropForeignKey("dbo.Konutlar", "IsitmaTuruID", "dbo.KatTurleri");
            DropForeignKey("dbo.Konutlar", "KatTur_ID", "dbo.KatTurleri");
            DropForeignKey("dbo.Konutlar", "IlanTuruID", "dbo.IlanTurleri");
            DropForeignKey("dbo.Fotograflar", "KonutID", "dbo.Konutlar");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Konutlar", new[] { "IsitmaSistemi_ID" });
            DropIndex("dbo.Konutlar", new[] { "KatTur_ID" });
            DropIndex("dbo.Konutlar", new[] { "IlanTuruID" });
            DropIndex("dbo.Konutlar", new[] { "IsitmaTuruID" });
            DropIndex("dbo.Konutlar", new[] { "KatTuruID" });
            DropIndex("dbo.Konutlar", new[] { "KullaniciID" });
            DropIndex("dbo.Fotograflar", new[] { "KonutID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.IsitmaSistemleri");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.KatTurleri");
            DropTable("dbo.IlanTurleri");
            DropTable("dbo.Konutlar");
            DropTable("dbo.Fotograflar");
        }
    }
}
