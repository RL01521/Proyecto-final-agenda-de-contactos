using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmPacientes : Form
    {
        private readonly ContactoBLL _ContactoBLL = new ContactoBLL();

        public FrmPacientes()
        {
            InitializeComponent();
          
            this.Load += FrmPacientes_Load;
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            // Cargar todos los pacientes del DataGridView
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            try
            {
                // Generación automática de columnas
                dataGridView1.AutoGenerateColumns = true;

                // Obtener lista de pacientes de BLL
                var lista = _ContactoBLL.ObtenerTodosPacientes();

                // Asignar la lista como origen de datos
                dataGridView1.DataSource = lista;

                // Ocultar columna "Id" si existe
                if (dataGridView1.Columns.Contains("Id"))
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }

                // Ajustar tamaño de columnas al contenido
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
