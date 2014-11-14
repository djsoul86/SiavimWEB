namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alertas",
                c => new
                    {
                        IdAlerta = c.Int(nullable: false, identity: true),
                        TipoAlerta = c.String(nullable: false),
                        FechaAlerta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdAlerta);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alertas");
        }
    }
}
