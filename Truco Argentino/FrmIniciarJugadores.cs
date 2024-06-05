using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Truco_Argentino
{
    public partial class FrmIniciarJugadores : Form
    {
        public FrmIniciarJugadores()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Revisa la existencia de ambos usuarios ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJugar_Click(object sender, EventArgs e)
        {
            if(txtNombreJugador1.Text != "" && txtContraseñaJugador1.Text != "" && txtNombreJugador2.Text != "" && txtContraseñaJugador2.Text != "")
            {
                int id1 = -1, id2 = -1;
                bool bool1 = false, bool2 = false;

                List<Jugador> listaDeJugadores;
                ADO ado = new ADO();
                listaDeJugadores = ado.ObtenerTodaLaLista();



                foreach (Jugador jugador in listaDeJugadores)
                {
                    if (bool1 == false || bool2 == false)
                    {
                        if (jugador.Nombre == txtNombreJugador1.Text && jugador.Contraseña == txtContraseñaJugador1.Text)
                        {
                            id1 = jugador.ID;
                            bool1 = true;
                        }
                        if (jugador.Nombre == txtNombreJugador2.Text && jugador.Contraseña == txtContraseñaJugador2.Text)
                        {
                            id2 = jugador.ID;
                            bool2 = true;
                        }
                    }
                }

                if (id1 == -1)
                {
                    MessageBox.Show("No se encontro el usuario nummero 1. Ingrese nuevamente el nombre y la contraseña", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseñaJugador1.Clear();
                    txtNombreJugador1.Clear();
                }
                else
                {
                    if (id2 == -1)
                    {
                        MessageBox.Show("No se encontro el usuario nummero 2. Ingrese nuevamente el nombre y la contraseña", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtContraseñaJugador2.Clear();
                        txtNombreJugador2.Clear();
                    }
                    else
                    {
                        FrmJuego juego = new FrmJuego(id1, id2);
                        juego.Show();
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se lleno alguno de los campos", "Atencion usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void FrmIniciarJugadores_Load(object sender, EventArgs e)
        {

        }
    }
}
