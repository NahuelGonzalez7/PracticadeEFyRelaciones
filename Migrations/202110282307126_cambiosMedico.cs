namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosMedico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Medicos", "IdEspecialidad", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicos", "IdEspecialidad");
            AddForeignKey("dbo.Medicos", "IdEspecialidad", "dbo.Especialidad", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "IdEspecialidad", "dbo.Especialidad");
            DropIndex("dbo.Medicos", new[] { "IdEspecialidad" });
            DropColumn("dbo.Medicos", "IdEspecialidad");
            DropTable("dbo.Especialidad");
        }
    }
}
