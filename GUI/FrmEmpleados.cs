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
using EL;

namespace GUI
{
    public partial class FrmEmpleados : Form
    {
        private readonly EmpleadoBLL _empleadoBLL = new EmpleadoBLL();

        public FrmEmpleados()
        {
            InitializeComponent();
            dtpFechaContratacion.Value = DateTime.Today;
            this.Load += FrmEmpleados_Load;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            cmbCargo.DataSource = Enum.GetValues(typeof(Cargo));


            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                //  generación automática de columnas 
                dgvEmpleados.AutoGenerateColumns = true;

                // Obtener lista de empleados
                var lista = _empleadoBLL.ObtenerTodos();

                // Asignar DataSource
                dgvEmpleados.DataSource = lista;

            
                if (dgvEmpleados.Columns.Contains("Id"))
                {
                    dgvEmpleados.Columns["Id"].Visible = true;
                }

                // Ajustar tamaño de columnas
                dgvEmpleados.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                var nuevoEmpleado = new Empleado(
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    (Cargo)cmbCargo.SelectedItem,
                    dtpFechaContratacion.Value.Date
                );

                _empleadoBLL.Insertar(nuevoEmpleado);

                MessageBox.Show("Empleado agregado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarEmpleados(); 
            }
            catch (Exception ex)
            {
                string detalle = ex.InnerException?.InnerException?.Message
                                 ?? ex.InnerException?.Message
                                 ?? ex.Message;
                MessageBox.Show($"Error al agregar el empleado:\n{detalle}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus(); return false;
            }
            if (cmbCargo.SelectedItem == null)
            {
                MessageBox.Show("El cargo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCargo.Focus(); return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbCargo.SelectedIndex = -1;
            dtpFechaContratacion.Value = DateTime.Today;
            txtNombre.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



