namespace SIAM.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siam41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Horarios", "LunesInicio", c => c.String());
            AddColumn("dbo.Horarios", "LunesFin", c => c.String());
            AddColumn("dbo.Horarios", "MartesInicio", c => c.String());
            AddColumn("dbo.Horarios", "MartesFin", c => c.String());
            AddColumn("dbo.Horarios", "MiercolesInicio", c => c.String());
            AddColumn("dbo.Horarios", "MiercolesFin", c => c.String());
            AddColumn("dbo.Horarios", "JuevesInicio", c => c.String());
            AddColumn("dbo.Horarios", "JuevesFin", c => c.String());
            AddColumn("dbo.Horarios", "ViernesInicio", c => c.String());
            AddColumn("dbo.Horarios", "ViernesFin", c => c.String());
            AddColumn("dbo.Horarios", "SabadoInicio", c => c.String());
            AddColumn("dbo.Horarios", "SabadoFin", c => c.String());
            DropColumn("dbo.Horarios", "Lunes");
            DropColumn("dbo.Horarios", "Martes");
            DropColumn("dbo.Horarios", "Miercoles");
            DropColumn("dbo.Horarios", "Jueves");
            DropColumn("dbo.Horarios", "Viernes");
            DropColumn("dbo.Horarios", "Sabado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Horarios", "Sabado", c => c.String());
            AddColumn("dbo.Horarios", "Viernes", c => c.String());
            AddColumn("dbo.Horarios", "Jueves", c => c.String());
            AddColumn("dbo.Horarios", "Miercoles", c => c.String());
            AddColumn("dbo.Horarios", "Martes", c => c.String());
            AddColumn("dbo.Horarios", "Lunes", c => c.String());
            DropColumn("dbo.Horarios", "SabadoFin");
            DropColumn("dbo.Horarios", "SabadoInicio");
            DropColumn("dbo.Horarios", "ViernesFin");
            DropColumn("dbo.Horarios", "ViernesInicio");
            DropColumn("dbo.Horarios", "JuevesFin");
            DropColumn("dbo.Horarios", "JuevesInicio");
            DropColumn("dbo.Horarios", "MiercolesFin");
            DropColumn("dbo.Horarios", "MiercolesInicio");
            DropColumn("dbo.Horarios", "MartesFin");
            DropColumn("dbo.Horarios", "MartesInicio");
            DropColumn("dbo.Horarios", "LunesFin");
            DropColumn("dbo.Horarios", "LunesInicio");
        }
    }
}
