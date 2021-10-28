using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //EF
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Data
{
    public class DbClinicaContext: DbContext
    {
        //Constructor

        public DbClinicaContext() : base("KeyDbClinica") { }

        //Propiedades DbSet<M>

        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<Clinica> clinicas { get; set; }
        public DbSet<Habitacion> habitaciones { get; set; }

    }
}
