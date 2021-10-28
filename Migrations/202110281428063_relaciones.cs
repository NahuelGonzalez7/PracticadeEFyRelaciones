namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Matricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoID);
            
            AddColumn("dbo.Paciente", "MedicoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Paciente", "MedicoID");
            AddForeignKey("dbo.Paciente", "MedicoID", "dbo.Medicos", "MedicoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "MedicoID", "dbo.Medicos");
            DropIndex("dbo.Paciente", new[] { "MedicoID" });
            DropColumn("dbo.Paciente", "MedicoID");
            DropTable("dbo.Medicos");
        }
    }
}
