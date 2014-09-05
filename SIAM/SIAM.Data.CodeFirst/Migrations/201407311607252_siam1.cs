namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        Carrera = c.String(),
                        Telefono = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
