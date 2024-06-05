
namespace Truco_Argentino
{
    partial class FrmIniciarJugadores
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnJugar = new System.Windows.Forms.Button();
            this.txtNombreJugador1 = new System.Windows.Forms.TextBox();
            this.txtNombreJugador2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContraseñaJugador1 = new System.Windows.Forms.TextBox();
            this.txtContraseñaJugador2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresen sus nombres";
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(115, 201);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(96, 30);
            this.btnJugar.TabIndex = 1;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // txtNombreJugador1
            // 
            this.txtNombreJugador1.Location = new System.Drawing.Point(12, 112);
            this.txtNombreJugador1.Name = "txtNombreJugador1";
            this.txtNombreJugador1.PlaceholderText = "Nombre de usuario";
            this.txtNombreJugador1.Size = new System.Drawing.Size(111, 23);
            this.txtNombreJugador1.TabIndex = 2;
            // 
            // txtNombreJugador2
            // 
            this.txtNombreJugador2.Location = new System.Drawing.Point(197, 112);
            this.txtNombreJugador2.Name = "txtNombreJugador2";
            this.txtNombreJugador2.PlaceholderText = "Nombre de usuario";
            this.txtNombreJugador2.Size = new System.Drawing.Size(111, 23);
            this.txtNombreJugador2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jugador 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Jugador 2";
            // 
            // txtContraseñaJugador1
            // 
            this.txtContraseñaJugador1.Location = new System.Drawing.Point(12, 141);
            this.txtContraseñaJugador1.Name = "txtContraseñaJugador1";
            this.txtContraseñaJugador1.PasswordChar = '*';
            this.txtContraseñaJugador1.PlaceholderText = "Contraseña";
            this.txtContraseñaJugador1.Size = new System.Drawing.Size(111, 23);
            this.txtContraseñaJugador1.TabIndex = 6;
            // 
            // txtContraseñaJugador2
            // 
            this.txtContraseñaJugador2.Location = new System.Drawing.Point(197, 141);
            this.txtContraseñaJugador2.Name = "txtContraseñaJugador2";
            this.txtContraseñaJugador2.PasswordChar = '*';
            this.txtContraseñaJugador2.PlaceholderText = "Contraseña";
            this.txtContraseñaJugador2.Size = new System.Drawing.Size(111, 23);
            this.txtContraseñaJugador2.TabIndex = 7;
            // 
            // FrmIniciarJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 298);
            this.Controls.Add(this.txtContraseñaJugador2);
            this.Controls.Add(this.txtContraseñaJugador1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreJugador2);
            this.Controls.Add(this.txtNombreJugador1);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.label1);
            this.Name = "FrmIniciarJugadores";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmIniciarJugadores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.TextBox txtNombreJugador1;
        private System.Windows.Forms.TextBox txtNombreJugador2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContraseñaJugador1;
        private System.Windows.Forms.TextBox txtContraseñaJugador2;
    }
}