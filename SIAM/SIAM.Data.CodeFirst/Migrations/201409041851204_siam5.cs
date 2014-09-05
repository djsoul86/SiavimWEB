namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Curso_IdCurso", c => c.Int());
            CreateIndex("dbo.Usuarios", "Curso_IdCurso");
            AddForeignKey("dbo.Usuarios", "Curso_IdCurso", "dbo.Cursoes", "IdCurso");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Curso_IdCurso", "dbo.Cursoes");
            DropIndex("dbo.Usuarios", new[] { "Curso_IdCurso" });
            DropColumn("dbo.Usuarios", "Curso_IdCurso");
        }
    }
}
