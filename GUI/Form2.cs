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
    public partial class Form2 : Form
    {
        private readonly EmpleadoBLL _empleadoBLL = new EmpleadoBLL();

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
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

        private void labelHistorial_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                // Convertir el valor seleccionado de cmbCargo a un enum Cargo
                if (Enum.TryParse(cmbCargo.SelectedItem.ToString(), out Cargo cargoSeleccionado))
                {
                    var nuevoEmpleado = new Empleado(
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        correo: txtCorreo.Text.Trim(),
                        telefono: txtTelefono.Text.Trim(),
                        cargo: cargoSeleccionado,  // Aquí ya usamos el enum
                        fechaContratacion: dtpFechaContratacion.Value  // Convertir a DateTime
                    );

                    // Insertar el nuevo empleado
                    _empleadoBLL.Insertar(nuevoEmpleado);

                    MessageBox.Show("Empleado agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("El cargo seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //private void LimpiarFormulario()
        //{
        //    //txtNombre.Clear();
        //    //txtApellido.Clear();
        //    //txtTelefono.Clear();
        //    //txtCorreo.Clear();
        //    //cmbCargo.SelectedIndex = -1;
        //    //dtpFechaContratacion.Value = DateTime.Today;
        //    //txtNombre.Focus();
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ContactosEmpleados EmpleadosForm = new ContactosEmpleados();
            EmpleadosForm.StartPosition = FormStartPosition.CenterScreen;
            EmpleadosForm.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cmbCargo.DataSource = Enum.GetValues(typeof(Cargo));

            CargarEmpleados(); // Si necesitas cargar empleados en el DataGridView
        }

        private void CargarEmpleados()
        {
            //try
            //{
            //    //  generación automática de columnas 
            //    dgvEmpleados.AutoGenerateColumns = true;

            //    // Obtener lista de empleados
            //    var lista = _empleadoBLL.ObtenerTodos();

            //    // Asignar DataSource
            //    dgvEmpleados.DataSource = lista;


            //    if (dgvEmpleados.Columns.Contains("Id"))
            //    {
            //        dgvEmpleados.Columns["Id"].Visible = true;
            //    }

            //    // Ajustar tamaño de columnas
            //    dgvEmpleados.AutoResizeColumns();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al cargar empleados: {ex.Message}",
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si NO es letra
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si NO es letra
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir solo si es dígito y hay menos de 8 caracteres
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar) || textBox.Text.Length >= 8)
                {
                    e.Handled = true; // Bloquea la tecla
                }
            }
        }
    }
}
