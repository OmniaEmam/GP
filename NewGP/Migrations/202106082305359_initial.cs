namespace NewGP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        adminId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        adress = c.String(nullable: false),
                        phone = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.adminId);
            
            CreateTable(
                "dbo.findpeoples",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Lastname = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Dateoffound = c.DateTime(nullable: false),
                        Image = c.String(),
                        Age = c.Int(nullable: false),
                        Ismale = c.String(nullable: false),
                        placefound = c.String(nullable: false),
                        current = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        tvcc = c.Boolean(nullable: false),
                        PersonFeature = c.String(nullable: false),
                        DescripClothes = c.String(nullable: false),
                        story = c.String(nullable: false),
                        UserID = c.Int(),
                        adminId = c.Int(),
                        Creaton = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Admins", t => t.adminId)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.adminId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Brithdate = c.DateTime(nullable: false),
                        Ismale = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Password = c.String(nullable: false),
                        ImageUrl = c.String(),
                        Creaton = c.DateTime(),
                        token = c.String(),
                        verified = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Findpersoncomments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        Creaton = c.DateTime(),
                        UserID = c.Int(nullable: false),
                        findpeopleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.findpeoples", t => t.findpeopleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.findpeopleId);
            
            CreateTable(
                "dbo.Kidnaps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ismale = c.String(nullable: false),
                        Aboutacciedance = c.String(nullable: false),
                        placehappend = c.String(nullable: false),
                        image = c.String(),
                        cctv = c.Boolean(nullable: false),
                        creaton = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Misscomments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        Creaton = c.DateTime(),
                        UserID = c.Int(nullable: false),
                        misspersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.misspersons", t => t.misspersonId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.misspersonId);
            
            CreateTable(
                "dbo.misspersons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Lname = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Image = c.String(),
                        Age = c.Int(nullable: false),
                        Dateofmiss = c.DateTime(nullable: false),
                        Ismale = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        placemiss = c.String(nullable: false),
                        cctv = c.Boolean(nullable: false),
                        PersonFeature = c.String(nullable: false),
                        DescripClothes = c.String(nullable: false),
                        story = c.String(nullable: false),
                        UserID = c.Int(),
                        Creaton = c.DateTime(),
                        adminId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.adminId)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.adminId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.Crimesvidios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Vname = c.String(nullable: false),
                        Vfile = c.String(nullable: false),
                        comment = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Crimesvidios", "UserID", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Misscomments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Misscomments", "misspersonId", "dbo.misspersons");
            DropForeignKey("dbo.misspersons", "UserID", "dbo.Users");
            DropForeignKey("dbo.misspersons", "adminId", "dbo.Admins");
            DropForeignKey("dbo.Kidnaps", "UserID", "dbo.Users");
            DropForeignKey("dbo.Findpersoncomments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Findpersoncomments", "findpeopleId", "dbo.findpeoples");
            DropForeignKey("dbo.findpeoples", "UserID", "dbo.Users");
            DropForeignKey("dbo.findpeoples", "adminId", "dbo.Admins");
            DropIndex("dbo.Crimesvidios", new[] { "UserID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.misspersons", new[] { "adminId" });
            DropIndex("dbo.misspersons", new[] { "UserID" });
            DropIndex("dbo.Misscomments", new[] { "misspersonId" });
            DropIndex("dbo.Misscomments", new[] { "UserID" });
            DropIndex("dbo.Kidnaps", new[] { "UserID" });
            DropIndex("dbo.Findpersoncomments", new[] { "findpeopleId" });
            DropIndex("dbo.Findpersoncomments", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.findpeoples", new[] { "adminId" });
            DropIndex("dbo.findpeoples", new[] { "UserID" });
            DropTable("dbo.Crimesvidios");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.misspersons");
            DropTable("dbo.Misscomments");
            DropTable("dbo.Kidnaps");
            DropTable("dbo.Findpersoncomments");
            DropTable("dbo.Users");
            DropTable("dbo.findpeoples");
            DropTable("dbo.Admins");
        }
    }
}
