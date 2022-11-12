namespace OssBssSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleOfStaffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Password = c.String(),
                        Fio = c.String(),
                        RoleId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleOfStaffs", t => t.RoleId_Id)
                .Index(t => t.RoleId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "RoleId_Id", "dbo.RoleOfStaffs");
            DropIndex("dbo.Staffs", new[] { "RoleId_Id" });
            DropTable("dbo.Staffs");
            DropTable("dbo.RoleOfStaffs");
        }
    }
}
