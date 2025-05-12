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
    public partial class ContactosEmpleados : Form
    {
        private readonly ContactoBLL contactoBLL;
        private readonly BindingSource bs;
        public ContactosEmpleados()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            this.Load += new System.EventHandler(this.ContactosEmpleados_Load);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private readonly BLL.ContactoBLL _contactoBLL = new BLL.ContactoBLL();

        private void CargarEmpleados()
        {
            var lista = _contactoBLL.ObtenerTodosEmpleados();
            dataGridViewEmpleados.DataSource = null;
            dataGridViewEmpleados.DataSource = lista;
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


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 AgregarConctacto = new Form2();
            AgregarConctacto.Show();
            this.Hide(); // Lo que hace es que me ocultara el formulario actual
        }

        private void ContactosEmpleados_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarEmpleados();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal inicioForm = new FrmMenuPrincipal();
            inicioForm.StartPosition = FormStartPosition.CenterScreen;
            inicioForm.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactosPacientes contactosForm = new ContactosPacientes();
            contactosForm.StartPosition = FormStartPosition.CenterScreen;
            contactosForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void cerraSecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login iniciodesesion = new Login();
            iniciodesesion.StartPosition = FormStartPosition.CenterScreen;
            iniciodesesion.Show();
            this.Hide();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form2 AgregarConctacto = new Form2();
            AgregarConctacto.Show();
            this.Hide(); // Lo que hace es que me ocultara el formulario actual
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

            // Render
            menuStrip1.Renderer = new MyRenderer();
        }

        // Boton buscar puede encontrar todos los contcatos segun como se alla colocado en el datagridview
        private void txtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtFiltro.Text.Trim();

                // aqui verificar si el filtro está vacío
                if (string.IsNullOrEmpty(filtro))
                {
                    CargarEmpleados(); // Recargar todos los pacientes si no hay filtro
                }
                else if (int.TryParse(filtro, out int id))
                {
                    // Si es un número, buscar por el ID
                    var empleadosFiltrado = _contactoBLL.ObtenerTodosEmpleados()
                                                         .Where(c => c.Id == id)
                                                         .ToList();
                    // Asignar la lista filtrada al DataGridView
                    dataGridViewEmpleados.DataSource = empleadosFiltrado;
                }
                else
                {
                    // Si no es un número, buscar por nombre o apellido usando Contains correctamente
                    var empleadosFiltradosPorNombreApellido = _contactoBLL.ObtenerTodosEmpleados()
                                                                          .Where(c => c.Nombre.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                      c.Apellido.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                                                                          .ToList();

                    // Asignar la lista filtrada al DataGridView
                    dataGridViewEmpleados.DataSource = empleadosFiltradosPorNombreApellido;
                }

                // Refrescar el DataGridView
                dataGridViewEmpleados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var contacto = (Contacto)dataGridViewEmpleados.CurrentRow.DataBoundItem;
            int id = contacto.Id;

            var confirmar = MessageBox.Show("¿Está seguro que desea eliminar este empleado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                _contactoBLL.Eliminar(id);
                CargarEmpleados();
                MessageBox.Show("Empleado eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Recargar_Click(object sender, EventArgs e)
        {
            ContactosEmpleados contactosEmpleados = new ContactosEmpleados();
            contactosEmpleados.Show();
            this.Hide(); // Lo que hace es que me ocultara el formulario actual
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para editar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el objeto Contacto seleccionado
            var contacto = (Contacto)dataGridViewEmpleados.CurrentRow.DataBoundItem;

            // Abrir el formulario de edición
            var frm = new FrmEditarEmpleados(contacto.Id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            // Recargar la lista si el usuario guardó los cambios
            if (frm.DialogResult == DialogResult.OK)
            {
                CargarEmpleados();
            }
        }
    }
}
