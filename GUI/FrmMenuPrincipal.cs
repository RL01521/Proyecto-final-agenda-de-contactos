using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            menuStrip1.Renderer = new MyRenderer();
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
            private void sdsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void cerraSecToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void FrmMenuPrincipal_Load_1(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Opcion del menustrip que cierra todo el programa
        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // La opcion de apartado contactos que me abre el formulario Contactos Pacientes
        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactosPacientes contactosForm = new ContactosPacientes();
            contactosForm.StartPosition = FormStartPosition.CenterScreen;
            contactosForm.Show();
            this.Hide();
        }

        // La opcion de apartado contactos que me abre el formulario Contactos Empleados
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactosEmpleados contactosForm = new ContactosEmpleados();
            contactosForm.StartPosition = FormStartPosition.CenterScreen;
            contactosForm.Show();
            this.Hide();
        }

        // Opcion del menustrip que me regresa al inicio de sesion
        private void cerraSecToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login iniciodesesion = new Login();
            iniciodesesion.StartPosition = FormStartPosition.CenterScreen;
            iniciodesesion.Show();
            this.Hide();
        }
    }
}
