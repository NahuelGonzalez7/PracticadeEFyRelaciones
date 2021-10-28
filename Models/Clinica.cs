using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    [Table("Clinica")]
    public class Clinica
    {
        public int Id { get; set; }

        [Required] // Not Null
        [Column(TypeName = "varchar")] //Tipo de dato de SQL SERVER
        [MaxLength(50)] // Hasta 50
        public string Nombre { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaInicioActivades { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
    }
}
