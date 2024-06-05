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
    public partial class FrmHistorial : Form
    {
        List<Partida> partidas;
        public FrmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda la lista de partidas de la base de datos en la lista local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            ADOPartidas adoPartida = new ADOPartidas();

            partidas = adoPartida.ObtenerTodaLaLista();

            foreach(Partida partida in partidas)
            {
                lstPartidas.Items.Add(partida.ToString());
            }
            
        }
        /// <summary>
        /// Al seleccionar una partida muestra la informacion de esta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGanador.Text = "";
            LimpiarLabels();

            Partida partida = null;
            foreach(Partida partidaAux in partidas)
            {
                if(partidaAux.IDPartida == int.Parse(lstPartidas.SelectedIndex.ToString().Substring(lstPartidas.SelectedIndex.ToString().IndexOf(" ")+1, lstPartidas.SelectedIndex.ToString().Length)))
                {
                    partida = partidaAux;
                    break;
                }
            }

            List<Jugador> jugadores;

            ADO ado = new ADO();
            jugadores = ado.ObtenerTodaLaLista();
            foreach (Jugador jugador in jugadores)
            {
                if (partida.IDJugador1 == jugador.ID)
                {
                    lblJugador1.Text += jugador.Nombre;
                }
                if (partida.IDJugador2 == jugador.ID)
                {
                    lblJugador2.Text += jugador.Nombre;
                }
                if(partida.IDGanador == jugador.ID)
                {   
                    txtGanador.Text = jugador.Nombre;
                }
                else
                {
                    if(partida.IDGanador == -1 && txtGanador.Text == "")
                    {
                        txtGanador.Text = "Empate";
                    }
                }
            }

            txtPuntosJugador1.Text = partida.PuntosJugador1.ToString();
            txtPuntosJugador2.Text = partida.PuntosJugador2.ToString();


        }

        /// <summary>
        /// Limpia los labels para poder agregar los nombres de los jugadores
        /// </summary>
        public void LimpiarLabels()
        {
            lblJugador1.Text = "Puntos de ";
            lblJugador2.Text = "Puntos de ";
        }
    }
}
