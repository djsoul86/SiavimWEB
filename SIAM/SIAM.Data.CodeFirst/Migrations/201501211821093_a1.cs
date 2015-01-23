namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asesorias", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Asesorias", "FechaRespuesta", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asesorias", "FechaRespuesta");
            DropColumn("dbo.Asesorias", "FechaCreacion");
        }
    }
}
