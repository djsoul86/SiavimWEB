namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioCursos", "Usuario_Cedula", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioCursos", "Cursos_IdCurso", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios");
            DropIndex("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            DropIndex("dbo.UsuarioCursos", new[] { "Usuario_Cedula" });
            DropIndex("dbo.UsuarioCursos", new[] { "Cursos_IdCurso" });
            CreateTable(
                "dbo.CursosUsuariosCursos",
                c => new
                    {
                        CursosUsuarios_CursoId = c.Int(nullable: false),
                        CursosUsuarios_CedulaId = c.String(nullable: false, maxLength: 128),
                        Cursos_IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId, t.Cursos_IdCurso })
                .ForeignKey("dbo.CursosUsuarios", t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId }, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.Cursos_IdCurso, cascadeDelete: true)
                .Index(t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId })
                .Index(t => t.Cursos_IdCurso);
            
            DropColumn("dbo.Cursos", "CursosUsuarios_CursoId");
            DropColumn("dbo.Cursos", "CursosUsuarios_CedulaId");
            DropTable("dbo.UsuarioCursos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioCursos",
                c => new
                    {
                        Usuario_Cedula = c.String(nullable: false, maxLength: 128),
                        Cursos_IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Cedula, t.Cursos_IdCurso });
            
            AddColumn("dbo.Cursos", "CursosUsuarios_CedulaId", c => c.String(maxLength: 128));
            AddColumn("dbo.Cursos", "CursosUsuarios_CursoId", c => c.Int());
            DropForeignKey("dbo.CursosUsuariosCursos", "Cursos_IdCurso", "dbo.Cursos");
            DropForeignKey("dbo.CursosUsuariosCursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios");
            DropIndex("dbo.CursosUsuariosCursos", new[] { "Cursos_IdCurso" });
            DropIndex("dbo.CursosUsuariosCursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            DropTable("dbo.CursosUsuariosCursos");
            CreateIndex("dbo.UsuarioCursos", "Cursos_IdCurso");
            CreateIndex("dbo.UsuarioCursos", "Usuario_Cedula");
            CreateIndex("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            AddForeignKey("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios", new[] { "CursoId", "CedulaId" });
            AddForeignKey("dbo.UsuarioCursos", "Cursos_IdCurso", "dbo.Cursos", "IdCurso", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioCursos", "Usuario_Cedula", "dbo.Usuarios", "Cedula", cascadeDelete: true);
        }
    }
}
