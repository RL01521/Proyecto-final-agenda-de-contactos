namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtHistorialClinico = new System.Windows.Forms.TextBox();
            this.labelHistorial = new System.Windows.Forms.Label();
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.labelFecha = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labelApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.txtHistorialClinico);
            this.groupBox1.Controls.Add(this.labelHistorial);
            this.groupBox1.Controls.Add(this.dtpNacimiento);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.labelTelefono);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.labelCorreo);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.labelApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.labelNombre);
            this.groupBox1.Location = new System.Drawing.Point(191, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(675, 454);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Contacto:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(553, 398);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 28);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(445, 398);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 28);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // txtHistorialClinico
            // 
            this.txtHistorialClinico.Location = new System.Drawing.Point(25, 369);
            this.txtHistorialClinico.Margin = new System.Windows.Forms.Padding(4);
            this.txtHistorialClinico.Name = "txtHistorialClinico";
            this.txtHistorialClinico.Size = new System.Drawing.Size(403, 22);
            this.txtHistorialClinico.TabIndex = 11;
            this.txtHistorialClinico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHistorialClinico_KeyPress);
            // 
            // labelHistorial
            // 
            this.labelHistorial.AutoSize = true;
            this.labelHistorial.Location = new System.Drawing.Point(21, 350);
            this.labelHistorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHistorial.Name = "labelHistorial";
            this.labelHistorial.Size = new System.Drawing.Size(100, 16);
            this.labelHistorial.TabIndex = 10;
            this.labelHistorial.Text = "Historial clinico:";
            // 
            // dtpNacimiento
            // 
            this.dtpNacimiento.Location = new System.Drawing.Point(25, 309);
            this.dtpNacimiento.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNacimiento.Name = "dtpNacimiento";
            this.dtpNacimiento.Size = new System.Drawing.Size(265, 22);
            this.dtpNacimiento.TabIndex = 9;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(21, 288);
            this.labelFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(135, 16);
            this.labelFecha.TabIndex = 8;
            this.labelFecha.Text = "Fecha de nacimiento:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(25, 247);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(265, 22);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(21, 228);
            this.labelTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(64, 16);
            this.labelTelefono.TabIndex = 6;
            this.labelTelefono.Text = "Telefono:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(25, 188);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(403, 22);
            this.txtCorreo.TabIndex = 5;
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(21, 169);
            this.labelCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(51, 16);
            this.labelCorreo.TabIndex = 4;
            this.labelCorreo.Text = "Correo:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(25, 126);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(403, 22);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(21, 106);
            this.labelApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(60, 16);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(25, 63);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(403, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(21, 43);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(59, 16);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(1056, 584);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtHistorialClinico;
        private System.Windows.Forms.Label labelHistorial;
        private System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelNombre;
    }
}