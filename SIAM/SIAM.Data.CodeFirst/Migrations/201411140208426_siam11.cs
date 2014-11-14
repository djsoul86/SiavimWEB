namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notas", "UsuarioID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notas", "UsuarioID", c => c.String());
        }
    }
}
