﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EL;
using BLL;

namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly ContactoBLL _contactoBLL = new ContactoBLL();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dtpNacimiento.Value = DateTime.Today.AddYears(-18); // Establecer fecha por defecto (18 años atrás)
        } 
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ContactosPacientes contactosForm = new ContactosPacientes();
            contactosForm.StartPosition = FormStartPosition.CenterScreen;
            contactosForm.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            ContactosPacientes contactosForm = new ContactosPacientes();
            contactosForm.StartPosition = FormStartPosition.CenterScreen;
            contactosForm.Show();
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // Validación mejorada
            if (!ValidarDatos())
                return;

            try
            {
                var nuevoPaciente = new Paciente(
                    nombre: txtNombre.Text.Trim(),
                    apellido: txtApellido.Text.Trim(),
                    telefono: txtTelefono.Text.Trim(),
                    correo: txtCorreo.Text.Trim(),
                    fechaNacimiento: dtpNacimiento.Value.Date,
                    historialClinico: txtHistorialClinico.Text.Trim()
                );

                _contactoBLL.Insertar(nuevoPaciente);

                MessageBox.Show("Paciente agregado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                // O this.Close() si deseas cerrar después de agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el paciente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (dtpNacimiento.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNacimiento.Focus();
                return false;
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
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

        private void txtHistorialClinico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si NO es letra
            }
        }
    }

}
