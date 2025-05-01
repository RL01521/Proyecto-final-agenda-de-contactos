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
            AsociarEventos();
        }

        private void AsociarEventos()
        {
            // Agenda
            agendaToolStripMenuItem.Click += agendaToolStripMenuItem_Click;


            // Empleados
            trabajadoresToolStripMenuItem.Click += TrabajadoresToolStripMenuItem_Click;

            // Pacientes
            pacientesToolStripMenuItem.Click += PacientesToolStripMenuItem_Click;

            // Agregar Contacto
            agregarContactoToolStripMenuItem.Click += AgregarContactoToolStripMenuItem_Click;

            // Cerrar Sesión y Salir
            var sesiónMenu = new ToolStripMenuItem("Sesión");
            var cerrarSesion = new ToolStripMenuItem("Cerrar Sesión", null, CerrarSesion_Click);
            var salir = new ToolStripMenuItem("Salir", null, Salir_Click);
            sesiónMenu.DropDownItems.Add(cerrarSesion);
            sesiónMenu.DropDownItems.Add(salir);
            menuStrip1.Items.Add(sesiónMenu);
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ocultar el menú mientras Form1 esté abierto
            this.Hide();

            using (var f1 = new FrmAgenda())
            {
                f1.ShowDialog();    // Abre Form1 
            }

            // Cuando Form1 se cierra, vuelvo aquí
            this.Show();      
        }

        private void TrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var f1 = new FrmEmpleados())
            {
                f1.ShowDialog();    
            }

      
            this.Show();     
        }

        private void PacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Hide();

            using (var f1 = new FrmPacientes())
            {
                f1.ShowDialog();    
            }

    
            this.Show();
        }

        private void AgregarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            this.Hide();

            using (var f1 = new Form1())
            {
                f1.ShowDialog();    
            }

      
            this.Show();
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {

            this.Hide();
            using (var login = new FrmLogin())
            {
                login.ShowDialog();
            }
            
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
