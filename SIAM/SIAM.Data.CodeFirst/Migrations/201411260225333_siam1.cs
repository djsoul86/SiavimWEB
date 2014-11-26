namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam1 : DbMigration
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
                .ForeignKey("dbo.Cursoes", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        NombreCurso = c.String(nullable: false),
                        IntensidadHoraria = c.Int(nullable: false),
                        Silabo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdCurso)
                .ForeignKey("dbo.Silaboes", t => t.Silabo_Id)
                .Index(t => t.Silabo_Id);
            
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
                .ForeignKey("dbo.Cursoes", t => t.IdCurso)
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
                        IdCurso = c.Int(),
                    })
                .PrimaryKey(t => t.Cedula)
                .ForeignKey("dbo.Cursoes", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
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
                .ForeignKey("dbo.Cursoes", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alertas", "IdCurso", "dbo.Cursoes");
            DropForeignKey("dbo.Cursoes", "Silabo_Id", "dbo.Silaboes");
            DropForeignKey("dbo.Silaboes", "IdCurso", "dbo.Cursoes");
            DropForeignKey("dbo.Notas", "Cedula", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "IdCurso", "dbo.Cursoes");
            DropForeignKey("dbo.Notas", "IdCurso", "dbo.Cursoes");
            DropIndex("dbo.Silaboes", new[] { "IdCurso" });
            DropIndex("dbo.Usuarios", new[] { "IdCurso" });
            DropIndex("dbo.Notas", new[] { "IdCurso" });
            DropIndex("dbo.Notas", new[] { "Cedula" });
            DropIndex("dbo.Cursoes", new[] { "Silabo_Id" });
            DropIndex("dbo.Alertas", new[] { "IdCurso" });
            DropTable("dbo.Silaboes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Notas");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Alertas");
        }
    }
}
