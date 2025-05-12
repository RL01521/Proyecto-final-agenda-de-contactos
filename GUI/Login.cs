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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // almacenar el valor de los campos de texto en variables
            string user = txtUsuario.Text;
            string password = txtContraseña.Text;

            // validar que el usuario y contraseña sean correctos
            // AND, OR, NOT
            if (user == "administrador" && password == "123") // usando operador AND
            {
                // Creando un objeto de tipo menuprincipal
                FrmMenuPrincipal menuPrincipal = new FrmMenuPrincipal();

                menuPrincipal.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // Boton para poder salir de la programa
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
