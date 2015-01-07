namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam : DbMigration
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
                        FechaCreacionAlerta = c.DateTime(nullable: false),
                        UsuarioCreacion = c.String(),
                        IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAlerta)
                .ForeignKey("dbo.Cursos", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        NombreCurso = c.String(nullable: false),
                        IntensidadHoraria = c.Int(nullable: false),
                        IdProfesor = c.String(),
                        Silabo_Id = c.Int(),
                        CursosUsuarios_CursoId = c.Int(),
                        CursosUsuarios_CedulaId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdCurso)
                .ForeignKey("dbo.Silaboes", t => t.Silabo_Id)
                .ForeignKey("dbo.CursosUsuarios", t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId })
                .Index(t => t.Silabo_Id)
                .Index(t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId });
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        IdHorario = c.Int(nullable: false, identity: true),
                        IdCurso = c.Int(nullable: false),
                        LunesInicio = c.String(),
                        LunesFin = c.String(),
                        MartesInicio = c.String(),
                        MartesFin = c.String(),
                        MiercolesInicio = c.String(),
                        MiercolesFin = c.String(),
                        JuevesInicio = c.String(),
                        JuevesFin = c.String(),
                        ViernesInicio = c.String(),
                        ViernesFin = c.String(),
                        SabadoInicio = c.String(),
                        SabadoFin = c.String(),
                    })
                .PrimaryKey(t => t.IdHorario)
                .ForeignKey("dbo.Cursos", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        IdNota = c.Int(nullable: false, identity: true),
                        FechaNota = c.DateTime(nullable: false),
                        NombreNota = c.String(nullable: false),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Corte = c.Int(nullable: false),
                        PorcentajeCorte = c.Int(nullable: false),
                        Cedula = c.String(nullable: false, maxLength: 128),
                        IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdNota)
                .ForeignKey("dbo.Cursos", t => t.IdCurso)
                .ForeignKey("dbo.Usuarios", t => t.Cedula)
                .Index(t => t.Cedula)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Cedula = c.String(nullable: false, maxLength: 128),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        Carrera = c.String(),
                        Telefono = c.String(maxLength: 15),
                        CursosUsuarios_CursoId = c.Int(),
                        CursosUsuarios_CedulaId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Cedula)
                .ForeignKey("dbo.CursosUsuarios", t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId })
                .Index(t => new { t.CursosUsuarios_CursoId, t.CursosUsuarios_CedulaId });
            
            CreateTable(
                "dbo.Silaboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        NombreTema = c.String(nullable: false),
                        Contenido = c.String(nullable: false),
                        Evaluaciones = c.String(),
                        Bibliografia = c.String(),
                        IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.CursosUsuarios",
                c => new
                    {
                        CursoId = c.Int(nullable: false),
                        CedulaId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CursoId, t.CedulaId });
            
            CreateTable(
                "dbo.UsuarioCursos",
                c => new
                    {
                        Usuario_Cedula = c.String(nullable: false, maxLength: 128),
                        Cursos_IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Cedula, t.Cursos_IdCurso })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Cedula, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.Cursos_IdCurso, cascadeDelete: true)
                .Index(t => t.Usuario_Cedula)
                .Index(t => t.Cursos_IdCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios");
            DropForeignKey("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" }, "dbo.CursosUsuarios");
            DropForeignKey("dbo.Alertas", "IdCurso", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "Silabo_Id", "dbo.Silaboes");
            DropForeignKey("dbo.Silaboes", "IdCurso", "dbo.Cursos");
            DropForeignKey("dbo.Notas", "Cedula", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioCursos", "Cursos_IdCurso", "dbo.Cursos");
            DropForeignKey("dbo.UsuarioCursos", "Usuario_Cedula", "dbo.Usuarios");
            DropForeignKey("dbo.Notas", "IdCurso", "dbo.Cursos");
            DropForeignKey("dbo.Horarios", "IdCurso", "dbo.Cursos");
            DropIndex("dbo.UsuarioCursos", new[] { "Cursos_IdCurso" });
            DropIndex("dbo.UsuarioCursos", new[] { "Usuario_Cedula" });
            DropIndex("dbo.Silaboes", new[] { "IdCurso" });
            DropIndex("dbo.Usuarios", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            DropIndex("dbo.Notas", new[] { "IdCurso" });
            DropIndex("dbo.Notas", new[] { "Cedula" });
            DropIndex("dbo.Horarios", new[] { "IdCurso" });
            DropIndex("dbo.Cursos", new[] { "CursosUsuarios_CursoId", "CursosUsuarios_CedulaId" });
            DropIndex("dbo.Cursos", new[] { "Silabo_Id" });
            DropIndex("dbo.Alertas", new[] { "IdCurso" });
            DropTable("dbo.UsuarioCursos");
            DropTable("dbo.CursosUsuarios");
            DropTable("dbo.Silaboes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Notas");
            DropTable("dbo.Horarios");
            DropTable("dbo.Cursos");
            DropTable("dbo.Alertas");
        }
    }
}
