namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        FechaNota = c.DateTime(nullable: false),
                        NombreNota = c.String(),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsuarioID = c.String(),
                        Usuarios_Cedula = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdCurso)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_Cedula)
                .Index(t => t.Usuarios_Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notas", "Usuarios_Cedula", "dbo.Usuarios");
            DropIndex("dbo.Notas", new[] { "Usuarios_Cedula" });
            DropTable("dbo.Notas");
        }
    }
}
