namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionHabClinica : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Clinicas", newName: "Clinica");
            DropForeignKey("dbo.Habitacions", "IdHabitacion", "dbo.Clinicas");
            RenameColumn(table: "dbo.Habitacions", name: "IdHabitacion", newName: "ClinicaId");
            RenameIndex(table: "dbo.Habitacions", name: "IX_IdHabitacion", newName: "IX_ClinicaId");
            DropPrimaryKey("dbo.Habitacions");
            AddColumn("dbo.Habitacions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Habitacions", "Id");
            AddForeignKey("dbo.Habitacions", "ClinicaId", "dbo.Clinica", "Id", cascadeDelete: true);
            DropColumn("dbo.Clinica", "IdHabitacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinica", "IdHabitacion", c => c.Int(nullable: false));
            DropForeignKey("dbo.Habitacions", "ClinicaId", "dbo.Clinica");
            DropPrimaryKey("dbo.Habitacions");
            DropColumn("dbo.Habitacions", "Id");
            AddPrimaryKey("dbo.Habitacions", "IdHabitacion");
            RenameIndex(table: "dbo.Habitacions", name: "IX_ClinicaId", newName: "IX_IdHabitacion");
            RenameColumn(table: "dbo.Habitacions", name: "ClinicaId", newName: "IdHabitacion");
            AddForeignKey("dbo.Habitacions", "IdHabitacion", "dbo.Clinicas", "Id");
            RenameTable(name: "dbo.Clinica", newName: "Clinicas");
        }
    }
}
