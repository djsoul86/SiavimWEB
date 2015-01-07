namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siamr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Horarios", "IdCurso", "dbo.Cursos");
            AddColumn("dbo.Horarios", "Cursos_IdCurso", c => c.Int());
            CreateIndex("dbo.Horarios", "Cursos_IdCurso");
            AddForeignKey("dbo.Horarios", "Cursos_IdCurso", "dbo.Cursos", "IdCurso");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Horarios", "Cursos_IdCurso", "dbo.Cursos");
            DropIndex("dbo.Horarios", new[] { "Cursos_IdCurso" });
            DropColumn("dbo.Horarios", "Cursos_IdCurso");
            AddForeignKey("dbo.Horarios", "IdCurso", "dbo.Cursos", "IdCurso");
        }
    }
}
