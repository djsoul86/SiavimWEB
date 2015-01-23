namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asesorias", "Respuesta", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asesorias", "Respuesta");
        }
    }
}
