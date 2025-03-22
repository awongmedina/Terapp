namespace Terapp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CONFIGURACION",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CantidadPacientes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CONSULTA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PacienteID = c.Int(nullable: false),
                        FechaConsulta = c.DateTime(nullable: false),
                        EscalaDolor = c.Int(),
                        MotivoConsulta = c.String(maxLength: 500),
                        Valoracion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PACIENTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Ocupacion = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PADECIMIENTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Padecimiento = c.String(nullable: false, maxLength: 500),
                        Descripcion = c.String(maxLength: 500),
                        Activo = c.Decimal(nullable: false, precision: 1, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PUNTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConsultaID = c.Int(nullable: false),
                        TipoPuntos = c.String(nullable: false, maxLength: 50),
                        Coordenadas = c.String(nullable: false),
                        ColorRGB = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TIPO_TRATAMIENTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoTratamiento = c.String(nullable: false, maxLength: 500),
                        Descripcion = c.String(maxLength: 500),
                        Activo = c.Decimal(nullable: false, precision: 1, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TRATAMIENTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConsultaID = c.Int(nullable: false),
                        Tiempo = c.Int(nullable: false),
                        TipoTratamiento = c.String(nullable: false, maxLength: 500),
                        Comentarios = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TRATAMIENTO");
            DropTable("dbo.TIPO_TRATAMIENTO");
            DropTable("dbo.PUNTO");
            DropTable("dbo.PADECIMIENTO");
            DropTable("dbo.PACIENTE");
            DropTable("dbo.CONSULTA");
            DropTable("dbo.CONFIGURACION");
        }
    }
}
