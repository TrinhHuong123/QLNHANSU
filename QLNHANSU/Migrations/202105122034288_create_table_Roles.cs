namespace QLNHANSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Accounts", "RoleID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}
