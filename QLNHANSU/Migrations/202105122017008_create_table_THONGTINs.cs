namespace QLNHANSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_THONGTINs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.THONGTINs",
                c => new
                    {
                        ThongtinID = c.String(nullable: false, maxLength: 128),
                        Tieude = c.String(),
                        Noidung = c.String(),
                    })
                .PrimaryKey(t => t.ThongtinID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.THONGTINs");
            DropTable("dbo.Accounts");
        }
    }
}
