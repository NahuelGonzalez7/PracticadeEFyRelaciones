using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Medico
    {
        public int MedicoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }

        public int IdEspecialidad { get; set; }

        //Propiedad de Navegacion

        //public List<Paciente> Pacientes { get; set; }

        //[ForeignKey("IdEspecialidad")]
        //public Especialidad especialidad { get; set; }

    }
}
