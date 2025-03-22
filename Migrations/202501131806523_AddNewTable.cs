namespace Terapp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ADJUNTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConsultaID = c.Int(nullable: false),
                        PathArchivoAdjunto = c.String(nullable: false, maxLength: 500),
                        NombreArchivo = c.String(nullable: false, maxLength: 500),
                        ExtensionArchivo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ADJUNTO");
        }
    }
}
