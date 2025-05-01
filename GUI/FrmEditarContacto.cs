using System;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI
{
    public partial class FrmEditarContacto : Form
    {
        private readonly ContactoBLL _contactoBLL;
        private readonly int _contactoId;
        private Contacto _contactoActual;

        public FrmEditarContacto(int id)
        {
            InitializeComponent();

            _contactoId = id;
            _contactoBLL = new ContactoBLL();

     
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;

            this.Load += FrmEditarContacto_Load;
        }

        private void FrmEditarContacto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                _contactoActual = _contactoBLL.ObtenerPorId(_contactoId);
                if (_contactoActual == null)
                    throw new Exception("No existe el contacto con ID " + _contactoId);

                // Llenar con los datos actuales
                txtNombre.Text = _contactoActual.Nombre;
                txtApellido.Text = _contactoActual.Apellido;
                txtTelefono.Text = _contactoActual.Telefono;
                txtCorreo.Text = _contactoActual.Correo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el contacto: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("El nombre es obligatorio.");

                // Actualizar la entidad con los valores del formulario
                _contactoActual.Nombre = txtNombre.Text.Trim();
                _contactoActual.Apellido = txtApellido.Text.Trim();
                _contactoActual.Telefono = txtTelefono.Text.Trim();
                _contactoActual.Correo = txtCorreo.Text.Trim();

                // Guardar cambios en la BLL
                _contactoBLL.Actualizar(_contactoActual);

         
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactoBLL.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
