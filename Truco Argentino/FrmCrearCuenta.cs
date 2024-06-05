using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truco_Argentino
{
    public partial class FrmCrearCuenta : Form
    {
        public FrmCrearCuenta()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Agrega un nuevo jugador a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarNuevoJugador_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "" && txtContraseña.Text != "" && txtConfirmarContraseña.Text != "")
            {
                if (txtContraseña.Text == txtConfirmarContraseña.Text)
                {
                    ADO ado = new ADO();
                    Jugador jugador = new Jugador(txtNombre.Text, txtContraseña.Text);

                    ado.Agregar(jugador);
                    Close();
                }
                else
                {
                    MessageBox.Show("Revise que se haya introducido la misma contraseña en ambos campos", "Atencion usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Asegurese de completar todos los campos", "Atencion usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
