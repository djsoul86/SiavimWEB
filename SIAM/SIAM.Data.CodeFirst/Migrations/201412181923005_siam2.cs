namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursoes", "IdProfesor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cursoes", "IdProfesor");
        }
    }
}
