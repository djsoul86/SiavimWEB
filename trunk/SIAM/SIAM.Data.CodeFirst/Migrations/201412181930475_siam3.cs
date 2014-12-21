namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursoes", "IdProfesor", c => c.String());
            DropColumn("dbo.Cursoes", "NombreProfesor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursoes", "NombreProfesor", c => c.String());
            DropColumn("dbo.Cursoes", "IdProfesor");
        }
    }
}
