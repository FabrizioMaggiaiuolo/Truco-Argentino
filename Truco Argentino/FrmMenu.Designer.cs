
namespace Truco_Argentino
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.btnJugarContraIA = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnNuevoJuego = new System.Windows.Forms.Button();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJugarContraIA
            // 
            this.btnJugarContraIA.Location = new System.Drawing.Point(68, 165);
            this.btnJugarContraIA.Name = "btnJugarContraIA";
            this.btnJugarContraIA.Size = new System.Drawing.Size(110, 63);
            this.btnJugarContraIA.TabIndex = 5;
            this.btnJugarContraIA.Text = "Jugar contra IA";
            this.btnJugarContraIA.UseVisualStyleBackColor = true;
            this.btnJugarContraIA.Click += new System.EventHandler(this.btnJugarContraIA_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(512, 165);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(110, 63);
            this.btnHistorial.TabIndex = 4;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnNuevoJuego
            // 
            this.btnNuevoJuego.Location = new System.Drawing.Point(68, 97);
            this.btnNuevoJuego.Name = "btnNuevoJuego";
            this.btnNuevoJuego.Size = new System.Drawing.Size(110, 62);
            this.btnNuevoJuego.TabIndex = 3;
            this.btnNuevoJuego.Text = "Nuevo juego";
            this.btnNuevoJuego.UseVisualStyleBackColor = true;
            this.btnNuevoJuego.Click += new System.EventHandler(this.btnNuevoJuego_Click);
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Location = new System.Drawing.Point(512, 97);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(110, 62);
            this.btnCrearCuenta.TabIndex = 6;
            this.btnCrearCuenta.Text = "Crear cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(221, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 124);
            this.label1.TabIndex = 7;
            this.label1.Text = "Truco\r\nArgentino\r\n";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(685, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.btnJugarContraIA);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnNuevoJuego);
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJugarContraIA;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnNuevoJuego;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Label label1;
    }
}