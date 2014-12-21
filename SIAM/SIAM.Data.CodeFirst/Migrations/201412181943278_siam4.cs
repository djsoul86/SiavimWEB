namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        IdHorario = c.Int(nullable: false, identity: true),
                        IdCurso = c.Int(nullable: false),
                        Lunes = c.String(),
                        Martes = c.String(),
                        Miercoles = c.String(),
                        Jueves = c.String(),
                        Viernes = c.String(),
                        Sabado = c.String(),
                    })
                .PrimaryKey(t => t.IdHorario)
                .ForeignKey("dbo.Cursoes", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Horarios", "IdCurso", "dbo.Cursoes");
            DropIndex("dbo.Horarios", new[] { "IdCurso" });
            DropTable("dbo.Horarios");
        }
    }
}
