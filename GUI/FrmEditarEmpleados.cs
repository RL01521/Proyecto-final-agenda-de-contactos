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
    public partial class FrmEditarEmpleados : Form
    {
        // Variables para manejar la lógica de negocio y el ID del paciente
        private readonly EmpleadoBLL _empleadoBLL;
        private readonly int _empleadoId;
        private Empleado _empleadoActual;

        public FrmEditarEmpleados(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dtpFechaContratacion.Value = DateTime.Today.AddYears(-18); // Fecha por defecto 18 años atras

            _empleadoId = id;
            _empleadoBLL = new EmpleadoBLL();

            // Carga el evento Load
            this.Load += FrmEditarEmpleados_Load;
        }

        private void FrmEditarEmpleados_Load(object sender, EventArgs e)
        {
            // Cargamos los datos del empleado cuando el formulario se carga
            CargarDatos();

            // Llenar el ComboBox con los valores del enum Cargo
            cmbCargo.DataSource = Enum.GetValues(typeof(Cargo));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CargarDatos()
        {
            try
            {
                _empleadoActual = _empleadoBLL.ObtenerPorId(_empleadoId);
                if (_empleadoActual == null)
                    throw new Exception("No existe el empleado con ID " + _empleadoId);

                // Carga los datos en los campos
                txtNombre.Text = _empleadoActual.Nombre;
                txtApellido.Text = _empleadoActual.Apellido;
                txtTelefono.Text = _empleadoActual.Telefono;
                txtCorreo.Text = _empleadoActual.Correo;
                cmbCargo.SelectedItem = _empleadoActual.CargoEmpleado; // Cargo del empleado
                dtpFechaContratacion.Value = _empleadoActual.FechaContratacion; // Fecha de contratación
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el empleado: {ex.Message}");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.");
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.");
                txtTelefono.Focus();
                return false;
            }

            if (cmbCargo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cargo.");
                cmbCargo.Focus();
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                _empleadoActual.Nombre = txtNombre.Text.Trim();
                _empleadoActual.Apellido = txtApellido.Text.Trim();
                _empleadoActual.Telefono = txtTelefono.Text.Trim();
                _empleadoActual.Correo = txtCorreo.Text.Trim();
                _empleadoActual.CargoEmpleado = (Cargo)cmbCargo.SelectedItem; // Cargo seleccionado
                _empleadoActual.FechaContratacion = dtpFechaContratacion.Value; // Fecha de contratación

                _empleadoBLL.Actualizar(_empleadoActual); // Se actualiza el empleado

                MessageBox.Show("Empleado actualizado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el empleado: {ex.Message}");
            }
        }

        private void dtpFechaContratacion_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
