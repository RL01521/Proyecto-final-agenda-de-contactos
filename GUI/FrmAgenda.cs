using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI
{
    public partial class FrmAgenda : Form
    {
        private readonly ContactoBLL contactoBLL;
        private readonly BindingSource bs;

        public FrmAgenda()
        {
            InitializeComponent();

            contactoBLL = new ContactoBLL();
            bs = new BindingSource();

            // Evento Click botones
            btnBuscar.Click += btnBuscar_Click;
            btnEliminar.Click += btnEliminar_Click;
            // El evento btnEditar
            btnVolver.Click += btnVolver_Click;

            // Eventos del grid
            dgvContactos.CellDoubleClick += dgvContactos_CellDoubleClick;
            dgvContactos.CellContentClick += dgvContactos_CellContentClick;

            // Enlazo BindingSource al grid
            dgvContactos.DataSource = bs;

            // Cargo datos
            CargarTodos();
        }

        private void CargarTodos()
        {
            try
            {
                bs.DataSource = contactoBLL.ObtenerTodos();
                bs.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los contactos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();
                var lista = string.IsNullOrEmpty(filtro)
                    ? contactoBLL.ObtenerTodos()
                    : contactoBLL.Buscar(filtro);

                bs.DataSource = lista;
                bs.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.CurrentRow == null) return;

            var contacto = (Contacto)dgvContactos.CurrentRow.DataBoundItem;
            var dr = MessageBox.Show(
                $"¿Eliminar a {contacto.Nombre} (ID {contacto.Id})?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;
            try
            {
                contactoBLL.Eliminar(contacto.Id);
                CargarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.CurrentRow == null) return;

            var contacto = (Contacto)dgvContactos.CurrentRow.DataBoundItem;

            var frm = new FrmEditarContacto(contacto.Id);
            frm.Show();
            frm.FormClosed += (s, args) =>
            {
                if (frm.DialogResult == DialogResult.OK)
                {
                    CargarTodos();
                }
            };
        }

        private void dgvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            => btnEditar_Click(sender, e);

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
            => this.Close();

        private void FrmAgenda_Load(object sender, EventArgs e)
        {

        }
    }
}