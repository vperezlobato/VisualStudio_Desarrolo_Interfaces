namespace _01_HolaMundoWindowsForms_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSaludo = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido1 = new System.Windows.Forms.Label();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.lblApellido2 = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(128, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnSaludo
            // 
            this.btnSaludo.Location = new System.Drawing.Point(181, 165);
            this.btnSaludo.Name = "btnSaludo";
            this.btnSaludo.Size = new System.Drawing.Size(75, 23);
            this.btnSaludo.TabIndex = 4;
            this.btnSaludo.Text = "Saludar";
            this.btnSaludo.UseVisualStyleBackColor = true;
            this.btnSaludo.Click += new System.EventHandler(this.btnSaludo_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(181, 17);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(135, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // lblApellido1
            // 
            this.lblApellido1.AutoSize = true;
            this.lblApellido1.Location = new System.Drawing.Point(118, 53);
            this.lblApellido1.Name = "lblApellido1";
            this.lblApellido1.Size = new System.Drawing.Size(60, 13);
            this.lblApellido1.TabIndex = 5;
            this.lblApellido1.Text = "Apellido 1º:";
            // 
            // txtApellido1
            // 
            this.txtApellido1.Location = new System.Drawing.Point(181, 50);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(135, 20);
            this.txtApellido1.TabIndex = 1;
            // 
            // txtApellido2
            // 
            this.txtApellido2.Location = new System.Drawing.Point(181, 87);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(135, 20);
            this.txtApellido2.TabIndex = 2;
            // 
            // lblApellido2
            // 
            this.lblApellido2.AutoSize = true;
            this.lblApellido2.Location = new System.Drawing.Point(113, 90);
            this.lblApellido2.Name = "lblApellido2";
            this.lblApellido2.Size = new System.Drawing.Size(65, 13);
            this.lblApellido2.TabIndex = 8;
            this.lblApellido2.Text = "Apellidos 2º:";
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(181, 126);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(211, 20);
            this.dateFecha.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha Nacimiento:";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSaludo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.lblApellido2);
            this.Controls.Add(this.txtApellido2);
            this.Controls.Add(this.txtApellido1);
            this.Controls.Add(this.lblApellido1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnSaludo);
            this.Controls.Add(this.lblNombre);
            this.Name = "Form1";
            this.Text = "Formulario C Sharp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSaludo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido1;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.Label lblApellido2;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label1;
    }
}

