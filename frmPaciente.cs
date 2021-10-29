using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Admin;
using Datos.Models;

namespace WindowsFormsApp1
{
    public partial class frmPaciente : Form
    {
        public frmPaciente()
        {
            InitializeComponent();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            traerPaciente();
        }

        public void traerPaciente()
        {
            gridPacientes.DataSource = AdmPaciente.Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente() { Nombre = "Ana", Apellido = "Fernandez", FechaNacimiento = new DateTime(1980, 12, 20), NroHistoriaClinica = 22, MedicoID = 1 };

            int filasAfectadas = AdmPaciente.Insertar(paciente);
            if (filasAfectadas > 0)
            {
                gridPacientes.DataSource = AdmPaciente.Listar();
            }
        }
    }
}
