namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam11 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Notas", new[] { "Cedula" });
            AlterColumn("dbo.Notas", "Cedula", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Notas", "Cedula");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Notas", new[] { "Cedula" });
            AlterColumn("dbo.Notas", "Cedula", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notas", "Cedula");
        }
    }
}
