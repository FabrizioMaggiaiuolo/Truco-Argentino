
namespace Truco_Argentino
{
    partial class FrmHistorial
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
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.txtPuntosJugador1 = new System.Windows.Forms.TextBox();
            this.txtPuntosJugador2 = new System.Windows.Forms.TextBox();
            this.txtGanador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblJugador1 = new System.Windows.Forms.Label();
            this.lblJugador2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPartidas
            // 
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.ItemHeight = 15;
            this.lstPartidas.Location = new System.Drawing.Point(12, 42);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(185, 244);
            this.lstPartidas.TabIndex = 0;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);
            // 
            // txtPuntosJugador1
            // 
            this.txtPuntosJugador1.Location = new System.Drawing.Point(241, 86);
            this.txtPuntosJugador1.Name = "txtPuntosJugador1";
            this.txtPuntosJugador1.ReadOnly = true;
            this.txtPuntosJugador1.Size = new System.Drawing.Size(100, 23);
            this.txtPuntosJugador1.TabIndex = 1;
            // 
            // txtPuntosJugador2
            // 
            this.txtPuntosJugador2.Location = new System.Drawing.Point(241, 149);
            this.txtPuntosJugador2.Name = "txtPuntosJugador2";
            this.txtPuntosJugador2.ReadOnly = true;
            this.txtPuntosJugador2.Size = new System.Drawing.Size(100, 23);
            this.txtPuntosJugador2.TabIndex = 2;
            // 
            // txtGanador
            // 
            this.txtGanador.Location = new System.Drawing.Point(241, 220);
            this.txtGanador.Name = "txtGanador";
            this.txtGanador.ReadOnly = true;
            this.txtGanador.Size = new System.Drawing.Size(100, 23);
            this.txtGanador.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista de partidas";
            // 
            // lblJugador1
            // 
            this.lblJugador1.AutoSize = true;
            this.lblJugador1.Location = new System.Drawing.Point(241, 68);
            this.lblJugador1.Name = "lblJugador1";
            this.lblJugador1.Size = new System.Drawing.Size(60, 15);
            this.lblJugador1.TabIndex = 5;
            this.lblJugador1.Text = "Puntos de";
            // 
            // lblJugador2
            // 
            this.lblJugador2.AutoSize = true;
            this.lblJugador2.Location = new System.Drawing.Point(241, 131);
            this.lblJugador2.Name = "lblJugador2";
            this.lblJugador2.Size = new System.Drawing.Size(60, 15);
            this.lblJugador2.TabIndex = 6;
            this.lblJugador2.Text = "Puntos de";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ganador";
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 344);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblJugador2);
            this.Controls.Add(this.lblJugador1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGanador);
            this.Controls.Add(this.txtPuntosJugador2);
            this.Controls.Add(this.txtPuntosJugador1);
            this.Controls.Add(this.lstPartidas);
            this.Name = "FrmHistorial";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.TextBox txtPuntosJugador1;
        private System.Windows.Forms.TextBox txtPuntosJugador2;
        private System.Windows.Forms.TextBox txtGanador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblJugador1;
        private System.Windows.Forms.Label lblJugador2;
        private System.Windows.Forms.Label label4;
    }
}