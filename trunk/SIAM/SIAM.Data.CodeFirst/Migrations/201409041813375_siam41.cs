namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        NombreCurso = c.String(nullable: false),
                        IntensidadHoraria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCurso);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cursoes");
        }
    }
}
