namespace Terapp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EjerciciosAgregados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TIPO_TRATAMIENTO", "NombreTratamiento", c => c.String());
            AddColumn("dbo.TIPO_TRATAMIENTO", "PathImagen", c => c.String());
            AddColumn("dbo.TRATAMIENTO", "NombreTratamiento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TRATAMIENTO", "NombreTratamiento");
            DropColumn("dbo.TIPO_TRATAMIENTO", "PathImagen");
            DropColumn("dbo.TIPO_TRATAMIENTO", "NombreTratamiento");
        }
    }
}
