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
    public partial class FrmEditarPacientes : Form
    {
        // Variables para manejar la lógica de negocio y el ID del paciente
        private readonly ContactoBLL _contactoBLL;
        private readonly int _contactoId;
        private Contacto _contactoActual;

        // Constructor del formulario, recibe el ID del paciente a editar
        public FrmEditarPacientes(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dtpNacimiento.Value = DateTime.Today.AddYears(-18); // Fecha por defecto 18 años atras

            _contactoId = id;
            _contactoBLL = new ContactoBLL();

            // Carga el evento Load
            this.Load += FrmEditarPacientes_Load;
        }

        // Limpia los campos del formulario
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtHistorialClinico.Clear();
            dtpNacimiento.Value = DateTime.Today.AddYears(-18);
            txtNombre.Focus();
        }

        // Valida los datos ingresados por el usuario
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

            if (dtpNacimiento.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.");
                dtpNacimiento.Focus();
                return false;
            }

            return true;
        }

        // Cierra el formulario sin guardar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Libera recursos utilizados
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactoBLL.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        // Evento Load del formulario, carga los datos del paciente
        private void FrmEditarPacientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Carga los datos del paciente usando el ID
        private void CargarDatos()
        {
            try
            {
                _contactoActual = _contactoBLL.ObtenerPorId(_contactoId);
                if (_contactoActual == null)
                    throw new Exception("No existe el contacto con ID " + _contactoId);

                txtNombre.Text = _contactoActual.Nombre;
                txtApellido.Text = _contactoActual.Apellido;
                txtTelefono.Text = _contactoActual.Telefono;
                txtCorreo.Text = _contactoActual.Correo;

                // 👇 Si es paciente, cargamos datos específicos
                if (_contactoActual is Paciente paciente)
                {
                    dtpNacimiento.Value = paciente.FechaNacimiento;
                    txtHistorialClinico.Text = paciente.HistorialClinico;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el contacto: {ex.Message}");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Guarda los cambios realizados en los datos del paciente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                _contactoActual.Nombre = txtNombre.Text.Trim();
                _contactoActual.Apellido = txtApellido.Text.Trim();
                _contactoActual.Telefono = txtTelefono.Text.Trim();
                _contactoActual.Correo = txtCorreo.Text.Trim();

                // 👇 Si es paciente, actualizamos campos específicos
                if (_contactoActual is Paciente paciente)
                {
                    paciente.FechaNacimiento = dtpNacimiento.Value;
                    paciente.HistorialClinico = txtHistorialClinico.Text.Trim();
                }

                _contactoBLL.Actualizar(_contactoActual);

                MessageBox.Show("Paciente actualizado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el paciente: {ex.Message}");
            }
        }

        // Cancela la operación y el de cierre de formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Eventos que no se implemento nada con ellos
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtApellido_TextChanged(object sender, EventArgs e) { }
        private void txtCorreo_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void dtpNacimiento_ValueChanged(object sender, EventArgs e) { }
        private void txtHistorialClinico_TextChanged(object sender, EventArgs e) { }

        }
    
    }
