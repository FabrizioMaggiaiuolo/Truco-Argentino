
namespace Truco_Argentino
{
    partial class FrmContador
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuntosJugador1 = new System.Windows.Forms.TextBox();
            this.txtPuntosJugador2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puntos del jugador 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puntos del jugador 2";
            // 
            // txtPuntosJugador1
            // 
            this.txtPuntosJugador1.Enabled = false;
            this.txtPuntosJugador1.Location = new System.Drawing.Point(12, 37);
            this.txtPuntosJugador1.Name = "txtPuntosJugador1";
            this.txtPuntosJugador1.Size = new System.Drawing.Size(116, 23);
            this.txtPuntosJugador1.TabIndex = 2;
            this.txtPuntosJugador1.Text = "0";
            // 
            // txtPuntosJugador2
            // 
            this.txtPuntosJugador2.Enabled = false;
            this.txtPuntosJugador2.Location = new System.Drawing.Point(165, 37);
            this.txtPuntosJugador2.Name = "txtPuntosJugador2";
            this.txtPuntosJugador2.Size = new System.Drawing.Size(116, 23);
            this.txtPuntosJugador2.TabIndex = 3;
            this.txtPuntosJugador2.Text = "0";
            // 
            // FrmContador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 88);
            this.Controls.Add(this.txtPuntosJugador2);
            this.Controls.Add(this.txtPuntosJugador1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmContador";
            this.Text = "FrmContador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmContador_FormClosing);
            this.Load += new System.EventHandler(this.FrmContador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPuntosJugador1;
        private System.Windows.Forms.TextBox txtPuntosJugador2;
    }
}