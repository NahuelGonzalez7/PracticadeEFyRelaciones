using Datos.Admin;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMedico : Form
    {
        public frmMedico()
        {
            InitializeComponent();
        }

        private void frmMedico_Load(object sender, EventArgs e)
        {
            TraerMedicos();
            llenarComboEspecialidad();
            llenarComboTraerEspecialidad();
            //llenarComboId();
        }

        private void TraerMedicos()
        {
            gridMedicos.DataSource = AdmMedico.Listar();
        }
        private void llenarComboEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.DisplayMember = "Nombre";
            cbEspecialidad.ValueMember = "Id";
        }

        private void llenarComboTraerEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            especialidades.Insert(0, new Especialidad()
            {
                Id = 0,
                Nombre = "[TODAS]"
            });
            cbBuscarEspecialidad.DataSource = especialidades;
            cbBuscarEspecialidad.DisplayMember = "Nombre";
            cbBuscarEspecialidad.ValueMember = "Id";

        }
        //private void llenarComboId()
        //{
        //    List<Medico> medicos = AdmMedico.Listar();
        //    cbBuscarId.DataSource = medicos;
        //    cbBuscarId.DisplayMember = "MedicoId";
        //    cbBuscarId.ValueMember = "MedicoId";

        //}

    
        //private void cbBuscarId_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    int Id = Convert.ToInt32(cbBuscarId.SelectedValue);
        //    gridMedicos.DataSource = AdmMedico.ListarId(Id);

        //}

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            int filasAfectadas = AdmMedico.Eliminar(id);
            if (filasAfectadas > 0)
            {
                TraerMedicos();
                // Para este ejemplo no haria falta pero nunca está de más 
                llenarComboEspecialidad();
                llenarComboTraerEspecialidad();
                //llenarComboId();
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            Medico medicoModificado = new Medico()
            {
                MedicoId = Convert.ToInt32(txtID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                EspecialidadId = Convert.ToInt32(cbEspecialidad.SelectedValue)
            };
            int filasAfectadas = AdmMedico.Modificar(medicoModificado);
            if (filasAfectadas > 0)
            {
                TraerMedicos();

            }
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            Medico medico = new Medico()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                EspecialidadId = Convert.ToInt32(cbEspecialidad.SelectedValue)
            };
            int filasAfectadas = AdmMedico.Insertar(medico);
            if (filasAfectadas > 0)
            {
                TraerMedicos();
            }
        }

        private void cbBuscarEspecialidad_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            int especialidad = Convert.ToInt32(cbBuscarEspecialidad.SelectedValue);
            if (especialidad == 0)
            {
                TraerMedicos();
            }
            else
            {
                gridMedicos.DataSource = AdmMedico.ListarEspecialidadId(especialidad);
            }
        }
    }
}
