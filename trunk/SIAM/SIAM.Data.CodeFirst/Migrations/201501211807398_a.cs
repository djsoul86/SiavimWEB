namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asesorias",
                c => new
                    {
                        IdAsesoria = c.Int(nullable: false, identity: true),
                        Pregunta = c.String(),
                        ResueltaOk = c.Boolean(nullable: false),
                        Cedula = c.String(nullable: false, maxLength: 128),
                        IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAsesoria)
                .ForeignKey("dbo.Cursos", t => t.IdCurso, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Cedula, cascadeDelete: true)
                .Index(t => t.Cedula)
                .Index(t => t.IdCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asesorias", "Cedula", "dbo.Usuarios");
            DropForeignKey("dbo.Asesorias", "IdCurso", "dbo.Cursos");
            DropIndex("dbo.Asesorias", new[] { "IdCurso" });
            DropIndex("dbo.Asesorias", new[] { "Cedula" });
            DropTable("dbo.Asesorias");
        }
    }
}
