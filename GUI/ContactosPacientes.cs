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
using static GUI.FrmMenuPrincipal;

namespace GUI
{
    public partial class ContactosPacientes : Form
    {
        public ContactosPacientes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Render
            menuStrip1.Renderer = new MyRenderer();
        }

        private readonly BLL.ContactoBLL _contactoBLL = new BLL.ContactoBLL();
        private void CargarPacientes()
        {
            var lista = _contactoBLL.ObtenerTodosPacientes();
            dataGridViewPacientes.DataSource = null;
            dataGridViewPacientes.DataSource = lista;
        }
        public class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    // Esto es para Para cuando pase el maus tenga un color diferente (hover)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(102, 155, 188)), e.Item.ContentRectangle);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        private void Contactos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'clinicaDentalDatabaseDataSet.Contactoes' Puede moverla o quitarla según sea necesario.
            //this.contactoesTableAdapter.Fill(this.clinicaDentalDatabaseDataSet.Contactoes);
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarPacientes();
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        => btnEditar_Click(sender, e);

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void conctactosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal inicioForm = new FrmMenuPrincipal();
            inicioForm.StartPosition = FormStartPosition.CenterScreen;
            inicioForm.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactosEmpleados contactosForm = new ContactosEmpleados();
            contactosForm.StartPosition = FormStartPosition.CenterScreen;
            contactosForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cerraSecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login iniciodesesion = new Login();
            iniciodesesion.StartPosition = FormStartPosition.CenterScreen;
            iniciodesesion.Show();
            this.Hide();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Boton Editar Paciente
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para editar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el objeto Contacto seleccionado
            var contacto = (Contacto)dataGridViewPacientes.CurrentRow.DataBoundItem;

            // Abrir el formulario de edición
            var frm = new FrmEditarPacientes(contacto.Id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            // Recargar la lista si el usuario guardó los cambios
            if (frm.DialogResult == DialogResult.OK)
            {
                CargarPacientes();
            }
        }


         // Boton Buscar 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtFiltro.Text.Trim();

                // aqui verificar si el filtro está vacío
                if (string.IsNullOrEmpty(filtro))
                {
                    CargarPacientes(); // Recargar todos los pacientes si no hay filtro
                }
                else if (int.TryParse(filtro, out int id))
                {
                    // Si es un número, buscar por el ID
                    var pacienteFiltrado = _contactoBLL.ObtenerTodosPacientes()
                                                         .Where(c => c.Id == id)
                                                         .ToList();
                    // Asignar la lista filtrada al DataGridView
                    dataGridViewPacientes.DataSource = pacienteFiltrado;
                }
                else
                {
                    // Si no es un número, buscar por nombre o apellido usando Contains correctamente
                    var pacientesFiltradosPorNombreApellido = _contactoBLL.ObtenerTodosPacientes()
                                                                          .Where(c => c.Nombre.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                      c.Apellido.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                                                                          .ToList();

                    // Asignar la lista filtrada al DataGridView
                    dataGridViewPacientes.DataSource = pacientesFiltradosPorNombreApellido;
                }

                // Refrescar el DataGridView
                dataGridViewPacientes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Boton eliminar a un paciente
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var contacto = (Contacto)dataGridViewPacientes.CurrentRow.DataBoundItem;
            int id = contacto.Id;

            var confirmar = MessageBox.Show("¿Está seguro que desea eliminar este paciente?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                _contactoBLL.Eliminar(id);
                CargarPacientes();
                MessageBox.Show("Paciente eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Boton para agregar un nuevo paciente
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form1 AgregarConctacto = new Form1();
            AgregarConctacto.Show();
            this.Hide(); // Lo que hace es que me ocultara el formulario actual
        }

        private void Recargar_Click(object sender, EventArgs e)
        {
            ContactosPacientes contactosPacientes = new ContactosPacientes();
            contactosPacientes.Show();
            this.Hide(); // Lo que hace es que me ocultara el formulario actual
        }
    }

}