using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }

        [Required] // Not Null
        [Column(TypeName = "varchar")] //Tipo de dato de SQL SERVER
        [MaxLength(12)] // Hasta 50
        public string Estado { get; set; }

        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }
    }
}
