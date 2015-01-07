namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CursosUsuariosCursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios");
            DropForeignKey("dbo.CursosUsuariosCursos", "Cursos_IdCurso", "dbo.Cursos");
            DropIndex("dbo.CursosUsuariosCursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            DropIndex("dbo.CursosUsuariosCursos", new[] { "Cursos_IdCurso" });
            AddColumn("dbo.Cursos", "CursosUsuarios_CursoId", c => c.Int());
            AddColumn("dbo.Cursos", "CursosUsuarios_CedulaId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            CreateIndex("dbo.CursosUsuarios", "CursoId");
            CreateIndex("dbo.CursosUsuarios", "CedulaId");
            AddForeignKey("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios", new[] { "CursoId", "CedulaId" });
            AddForeignKey("dbo.CursosUsuarios", "CedulaId", "dbo.Usuarios", "Cedula", cascadeDelete: true);
            AddForeignKey("dbo.CursosUsuarios", "CursoId", "dbo.Cursos", "IdCurso", cascadeDelete: true);
            DropTable("dbo.CursosUsuariosCursos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CursosUsuariosCursos",
                c => new
                    {
                        CursosUsuarios_CursoId = c.Int(nullable: false),
                        CursosUsuarios_CedulaId = c.String(nullable: false, maxLength: 128),
                        Cursos_IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId, t.Cursos_IdCurso });
            
            DropForeignKey("dbo.CursosUsuarios", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.CursosUsuarios", "CedulaId", "dbo.Usuarios");
            DropForeignKey("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios");
            DropIndex("dbo.CursosUsuarios", new[] { "CedulaId" });
            DropIndex("dbo.CursosUsuarios", new[] { "CursoId" });
            DropIndex("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            DropColumn("dbo.Cursos", "CursosUsuarios_CedulaId");
            DropColumn("dbo.Cursos", "CursosUsuarios_CursoId");
            CreateIndex("dbo.CursosUsuariosCursos", "Cursos_IdCurso");
            CreateIndex("dbo.CursosUsuariosCursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            AddForeignKey("dbo.CursosUsuariosCursos", "Cursos_IdCurso", "dbo.Cursos", "IdCurso", cascadeDelete: true);
            AddForeignKey("dbo.CursosUsuariosCursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios", new[] { "CursoId", "CedulaId" }, cascadeDelete: true);
        }
    }
}
