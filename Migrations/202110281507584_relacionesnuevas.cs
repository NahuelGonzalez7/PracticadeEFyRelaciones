namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionesnuevas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaInicioActivades = c.DateTime(nullable: false, storeType: "date"),
                        IdHabitacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habitacions",
                c => new
                    {
                        IdHabitacion = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 12, unicode: false),
                    })
                .PrimaryKey(t => t.IdHabitacion)
                .ForeignKey("dbo.Clinicas", t => t.IdHabitacion)
                .Index(t => t.IdHabitacion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Habitacions", "IdHabitacion", "dbo.Clinicas");
            DropIndex("dbo.Habitacions", new[] { "IdHabitacion" });
            DropTable("dbo.Habitacions");
            DropTable("dbo.Clinicas");
        }
    }
}
