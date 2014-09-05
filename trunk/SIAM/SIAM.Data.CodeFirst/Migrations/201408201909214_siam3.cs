namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "Cedula", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Usuarios", "Cedula");
            DropColumn("dbo.Usuarios", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "UserID", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "Cedula", c => c.String());
            AddPrimaryKey("dbo.Usuarios", "UserID");
        }
    }
}
