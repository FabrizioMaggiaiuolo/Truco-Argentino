using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Truco_Argentino
{
    public partial class FrmJuego : Form, ILimpiarForms
    {
        private Partida partida;
        private int ContadorDeCartasTiradas = 0;
        private bool seDijoNoAlTruco = false;
        private int puntosDeEnvido = 0;

        public delegate void Limpiar();
        Limpiar limpiarTodo;

        FrmContador frmContador;
        public FrmJuego(int id1, int id2)
        {
            InitializeComponent();
            partida = new Partida(id1,id2);
        }
        /// <summary>
        /// Reparte y asigna las cartas. Tambien prepara el delagado "limpiarTodo" para su posterios utilizacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmJuego_Load(object sender, EventArgs e)
        {
            partida.RepartirCartas();
            AsignarCartas();
            EsconderBotones(ContadorDeCartasTiradas);

            frmContador = new FrmContador(partida);
            frmContador.Show();

            this.btnTrucoP1.Click += new EventHandler(this.CambiarTextoTruco);
            this.btnTrucoP2.Click += new EventHandler(this.CambiarTextoTruco);

            limpiarTodo = (() => {
                puntosDeEnvido = 0;
                partida.SeCantoTruco = 0;
                ContadorDeCartasTiradas = 0;
            });
            limpiarTodo += LimpiarTodosLosBotones;
            limpiarTodo += LimpiarCartasEnMano;
            limpiarTodo += LimpiarLabels;
            limpiarTodo += partida.RepartirCartas;
            limpiarTodo += AsignarCartas;
        }
        /// <summary>
        /// Guarda los datos de forma local y en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmJuego_FormClosing(object sender, FormClosingEventArgs e)
        {

            frmContador.Close();
            GuardarPartidasEnArchivo();
            
            if(partida.Ronda != 1)
            {
                if(partida.IDGanador == -1)
                {
                    if(partida.PuntosJugador1 > partida.PuntosJugador2)
                    {
                        partida.IDGanador = partida.IDJugador1;
                    }
                    else
                    {
                        if (partida.PuntosJugador1 < partida.PuntosJugador2)
                        {
                            partida.IDGanador = partida.IDJugador2;
                        }
                    }
                }
                ADOPartidas ado = new ADOPartidas();
                ado.Agregar(partida);
            }
            

        }
        /// <summary>
        /// Verifica quien gano la mano, suma los puntos del truco y del envido, limpiando el form al final para volver a usarlo
        /// </summary>
        public void VerificarCartas()
        {
            int contador1 = 0;
            int contador2 = 0;

            if (ContadorDeCartasTiradas == 6)
            {
                if(partida.CompararCartas(partida.CartasJugas1Mano[0],partida.CartasJugas1Mano[1]) == 1)
                {
                    contador1++;
                }
                else
                {
                    if (partida.CompararCartas(partida.CartasJugas1Mano[0], partida.CartasJugas1Mano[1]) == 2)
                    {
                        contador2++;
                    }
                }
                if (partida.CompararCartas(partida.CartasJugas2Mano[0], partida.CartasJugas2Mano[1]) == 1)
                {
                    contador1++;
                }
                else
                {
                    if (partida.CompararCartas(partida.CartasJugas2Mano[0], partida.CartasJugas2Mano[1]) == 2)
                    {
                        contador2++;
                    }
                }
                if (partida.CompararCartas(partida.CartasJugas3Mano[0], partida.CartasJugas3Mano[1]) == 1)
                {
                    contador1++;
                }
                else
                {
                    if (partida.CompararCartas(partida.CartasJugas3Mano[0], partida.CartasJugas3Mano[1]) == 2)
                    {
                        contador2++;
                    }
                }

                int puntosASumar = 1 + partida.SeCantoTruco;

                
                    if(seDijoNoAlTruco == false && btnTrucoP1.Enabled == false && btnTrucoP2.Enabled == false)
                    {
                        puntosASumar++;
                    }
                
                partida.SumarPuntosDeEnvido(puntosDeEnvido, partida.Ronda % 2);

                if(contador1 == contador2)
                {
                    if(partida.Ronda % 2 == 1)
                    {
                        partida.PuntosJugador1 += puntosASumar;
                    }
                    else
                    {
                        partida.PuntosJugador2 += puntosASumar;
                    }
                }
                else
                {
                    if(contador1 > contador2)
                    {
                        partida.PuntosJugador1 += puntosASumar;
                    }
                    else
                    {
                        partida.PuntosJugador2 += puntosASumar;
                    }
                }

                if(partida.PuntosJugador1 > 9 || partida.PuntosJugador2 > 9)
                {
                    Close();
                }

                partida.Ronda++;

                limpiarTodo();
            }
        }
        /// <summary>
        /// Suma la carta tirada en su posicion correspondiente
        /// </summary>
        /// <param name="carta"></param>
        public void SumarATiradaCorrespondiente(Carta carta)
        {
            if (partida.CartasJugas1Mano.Count < 2)
            {
                partida.CartasJugas1Mano.Add(carta);
            }
            else
            {
                if (partida.CartasJugas2Mano.Count < 2)
                {
                    partida.CartasJugas2Mano.Add(carta);
                }
                else
                {
                    partida.CartasJugas3Mano.Add(carta);
                }
            }
        }

        /// <summary>
        /// Guarda la partida en un archivo de forma local
        /// </summary>
        public void GuardarPartidasEnArchivo()
        {
            StreamWriter escritos = new StreamWriter(".\\PartidasJugadasLocalmente");

            ADO ado = new ADO();
            List<Jugador> lista = ado.ObtenerTodaLaLista();

            string linea = "ID Jugador 1: " + partida.IDJugador1;
            linea += " - ID Jugador 2: " + partida.IDJugador2;

            foreach (Jugador jugador in lista)
            {
                if (jugador.ID == partida.IDJugador1)
                {
                    linea += " - Nombre del jugador 1: " + jugador.Nombre;
                }
                if (jugador.ID == partida.IDJugador2)
                {
                    linea += " - Nombre del jugador 2: " + jugador.Nombre;
                }
            }

            linea += " - Cantidad de manos jugadas: " + partida.Ronda;

            foreach (Jugador jugador in lista)
            {
                if (jugador.ID == partida.IDGanador)
                {
                    linea += " - Nombre del Ganador: " + jugador.Nombre;
                }
            }

            escritos.WriteLine(linea);
            escritos.Close();
        }

        /// <summary>
        /// Cambia el texto del boton TRUCO a menudo que se va usando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CambiarTextoTruco(object sender, EventArgs e)
        {
            btnTrucoP1.Text = partida.StringTruco[partida.SeCantoTruco];
            btnTrucoP2.Text = partida.StringTruco[partida.SeCantoTruco];
        }
        /// <summary>
        /// Saca la opcion de cantar envido
        /// </summary>
        public void SacarEnvido()
        {
            btnEnvidoP1.Enabled = false;
            btnRealEnvidoP1.Enabled = false;
            btnFaltaEnvidoP1.Enabled = false;

            btnEnvidoP2.Enabled = false;
            btnRealEnvidoP2.Enabled = false;
            btnFaltaEnvidoP2.Enabled = false;
        }
        public void LimpiarTodosLosBotones()
        {
            btnTirarCarta1P1.Enabled = true;
            btnTirarCarta1P2.Enabled = true;
            btnTirarCarta2P1.Enabled = true;
            btnTirarCarta2P2.Enabled = true;
            btnTirarCarta3P1.Enabled = true;
            btnTirarCarta3P2.Enabled = true;

            btnTrucoP1.Text = partida.StringTruco[partida.SeCantoTruco];
            btnTrucoP2.Text = partida.StringTruco[partida.SeCantoTruco];

            btnTrucoP1.Enabled = true;
            btnTrucoP2.Enabled = true;
            btnEnvidoP1.Enabled = true;
            btnRealEnvidoP1.Enabled = true;
            btnFaltaEnvidoP1.Enabled = true;
            btnEnvidoP2.Enabled = true;
            btnRealEnvidoP2.Enabled = true;
            btnFaltaEnvidoP2.Enabled = true;
        }
        public void LimpiarLabels()
        {
            lblCartaTirada1P1.Text = "";
            lblCartaTirada2P1.Text = "";
            lblCartaTirada3P1.Text = "";
            lblCartaTirada1P2.Text = "";
            lblCartaTirada2P2.Text = "";
            lblCartaTirada3P2.Text = "";
        }
        public void LimpiarCartasEnMano()
        {
            partida.CartasJugas1Mano.Clear();
            partida.CartasJugas2Mano.Clear();
            partida.CartasJugas3Mano.Clear();
        }
        /// <summary>
        /// Asigna las cartas a sus labels correspondientes
        /// </summary>
        public void AsignarCartas()
        {
            lblCarta1P1.Text = partida.CartasJugador1[0].ToString();
            lblCarta2P1.Text = partida.CartasJugador1[1].ToString();
            lblCarta3P1.Text = partida.CartasJugador1[2].ToString();

            lblCarta1P2.Text = partida.CartasJugador2[0].ToString();
            lblCarta2P2.Text = partida.CartasJugador2[1].ToString();
            lblCarta3P2.Text = partida.CartasJugador2[2].ToString();
        }
        public void EsconderBotones(int contador)
        {
            if (contador % 2 == 0)
            {
                btnTrucoP2.Visible = false;
                btnEnvidoP2.Visible = false;
                btnFaltaEnvidoP2.Visible = false;
                btnRealEnvidoP2.Visible = false;
                btnTirarCarta1P2.Visible = false;
                btnTirarCarta2P2.Visible = false;
                btnTirarCarta3P2.Visible = false;

                btnTrucoP1.Visible = true;
                btnEnvidoP1.Visible = true;
                btnFaltaEnvidoP1.Visible = true;
                btnRealEnvidoP1.Visible = true;
                btnTirarCarta1P1.Visible = true;
                btnTirarCarta2P1.Visible = true;
                btnTirarCarta3P1.Visible = true;
            }
            else
            {
                btnTrucoP1.Visible = false;
                btnEnvidoP1.Visible = false;
                btnFaltaEnvidoP1.Visible = false;
                btnRealEnvidoP1.Visible = false;
                btnTirarCarta1P1.Visible = false;
                btnTirarCarta2P1.Visible = false;
                btnTirarCarta3P1.Visible = false;

                btnTrucoP2.Visible = true;
                btnEnvidoP2.Visible = true;
                btnFaltaEnvidoP2.Visible = true;
                btnRealEnvidoP2.Visible = true;
                btnTirarCarta1P2.Visible = true;
                btnTirarCarta2P2.Visible = true;
                btnTirarCarta3P2.Visible = true;
            }
        }



        private void btnTirarCarta1P1_Click(object sender, EventArgs e)
        {
            if(lblCartaTirada1P1.Text == "")
            {
                lblCartaTirada1P1.Text = lblCarta1P1.Text;
            }
            else
            {
                if (lblCartaTirada2P1.Text == "") 
                {
                    lblCartaTirada2P1.Text = lblCarta1P1.Text;
                }
                else
                {
                    lblCartaTirada3P1.Text = lblCarta1P1.Text;
                }
            }
            btnTirarCarta1P1.Enabled = false;
            ContadorDeCartasTiradas++;
            SumarATiradaCorrespondiente(partida.CartasJugador1[0]);
            VerificarCartas();
            EsconderBotones(ContadorDeCartasTiradas);
        }
        private void btnTirarCarta2P1_Click(object sender, EventArgs e)
        {
            if (lblCartaTirada1P1.Text == "")
            {
                lblCartaTirada1P1.Text = lblCarta2P1.Text;
            }
            else
            {
                if (lblCartaTirada2P1.Text == "")
                {
                    lblCartaTirada2P1.Text = lblCarta2P1.Text;
                }
                else
                {
                    lblCartaTirada3P1.Text = lblCarta2P1.Text;
                }
            }
            btnTirarCarta2P1.Enabled = false;
            ContadorDeCartasTiradas++;
            SumarATiradaCorrespondiente(partida.CartasJugador1[1]);
            VerificarCartas();
            EsconderBotones(ContadorDeCartasTiradas);
        }
        private void btnTirarCarta3P1_Click(object sender, EventArgs e)
        {
            if (lblCartaTirada1P1.Text == "")
            {
                lblCartaTirada1P1.Text = lblCarta3P1.Text;
            }
            else
            {
                if (lblCartaTirada2P1.Text == "")
                {
                    lblCartaTirada2P1.Text = lblCarta3P1.Text;
                }
                else
                {
                    lblCartaTirada3P1.Text = lblCarta3P1.Text;
                }
            }
            btnTirarCarta3P1.Enabled = false;
            ContadorDeCartasTiradas++;
            SumarATiradaCorrespondiente(partida.CartasJugador1[2]);
            VerificarCartas();
            EsconderBotones(ContadorDeCartasTiradas);
        }
        private void btnTirarCarta1P2_Click(object sender, EventArgs e)
        {
            if (lblCartaTirada1P2.Text == "")
            {
                lblCartaTirada1P2.Text = lblCarta1P2.Text;
            }
            else
            {
                if (lblCartaTirada2P2.Text == "")
                {
                    lblCartaTirada2P2.Text = lblCarta1P2.Text;
                }
                else
                {
                    lblCartaTirada3P2.Text = lblCarta1P2.Text;
                }
            }
            btnTirarCarta1P2.Enabled = false;
            ContadorDeCartasTiradas++;
            SumarATiradaCorrespondiente(partida.CartasJugador2[0]);
            VerificarCartas();
            EsconderBotones(ContadorDeCartasTiradas);
        }
        private void btnTirarCarta2P2_Click(object sender, EventArgs e)
        {
            if (lblCartaTirada1P2.Text == "")
            {
                lblCartaTirada1P2.Text = lblCarta2P2.Text;
            }
            else
            {
                if (lblCartaTirada2P2.Text == "")
                {
                    lblCartaTirada2P2.Text = lblCarta2P2.Text;
                }
                else
                {
                    lblCartaTirada3P2.Text = lblCarta2P2.Text;
                }
            }
            btnTirarCarta2P2.Enabled = false;
            ContadorDeCartasTiradas++;
            SumarATiradaCorrespondiente(partida.CartasJugador2[1]);
            VerificarCartas();
            EsconderBotones(ContadorDeCartasTiradas);
        }
        private void btnTirarCarta3P2_Click(object sender, EventArgs e)
        {
            if (lblCartaTirada1P2.Text == "")
            {
                lblCartaTirada1P2.Text = lblCarta3P2.Text;
            }
            else
            {
                if (lblCartaTirada2P2.Text == "")
                {
                    lblCartaTirada2P2.Text = lblCarta3P2.Text;
                }
                else
                {
                    lblCartaTirada3P2.Text = lblCarta3P2.Text;
                }
            }
            btnTirarCarta3P2.Enabled = false;
            ContadorDeCartasTiradas++;
            SumarATiradaCorrespondiente(partida.CartasJugador2[2]);
            VerificarCartas();
            EsconderBotones(ContadorDeCartasTiradas);
        }

        private void btnTrucoP1_Click(object sender, EventArgs e)
        {
            if(partida.Mensaje("Canto " + partida.StringTruco[partida.SeCantoTruco],"Acepta el " + partida.StringTruco[partida.SeCantoTruco] + "?") == true)
            {
                if(partida.SeCantoTruco < 2)
                {
                    partida.SeCantoTruco++;

                    SacarEnvido();

                    btnTrucoP1.Enabled = false;
                    btnTrucoP2.Enabled = true;
                }
                else 
                {
                    btnTrucoP1.Enabled = false;
                    btnTrucoP2.Enabled = false;
                }
            }
            else
            {
                btnTrucoP1.Enabled = false;
                btnTrucoP2.Enabled = false;
            }
        }
        private void btnTrucoP2_Click(object sender, EventArgs e)
        {
            if (partida.Mensaje("Canto " + partida.StringTruco[partida.SeCantoTruco], "Acepta el " + partida.StringTruco[partida.SeCantoTruco] + "?") == true)
            {
                if (partida.SeCantoTruco < 2)
                {
                    partida.SeCantoTruco++;

                    SacarEnvido();

                    btnTrucoP1.Enabled = true;
                    btnTrucoP2.Enabled = false;
                }
                else
                {
                    btnTrucoP1.Enabled = false;
                    btnTrucoP2.Enabled = false;
                }
            }
            else
            {
                btnTrucoP1.Enabled = false;
                btnTrucoP2.Enabled = false;
            }
        }

        private void btnEnvidoP1_Click(object sender, EventArgs e)
        {
            if (partida.Envido() == true)
            {
                partida.SeCantoEnvido++;

                btnEnvidoP1.Enabled = false;

                btnRealEnvidoP1.Enabled = false;
                btnFaltaEnvidoP1.Enabled = false;

                btnRealEnvidoP2.Enabled = true;
                btnFaltaEnvidoP2.Enabled = true;


                puntosDeEnvido += 2;
            }
            else
            {
                SacarEnvido();
            }
        }
        private void btnEnvidoP2_Click(object sender, EventArgs e)
        {
            if (partida.Envido() == true)
            {
                partida.SeCantoEnvido++;

                btnEnvidoP2.Enabled = false;

                btnRealEnvidoP1.Enabled = true;
                btnFaltaEnvidoP1.Enabled = true;

                btnRealEnvidoP2.Enabled = false;
                btnFaltaEnvidoP2.Enabled = false;

                puntosDeEnvido += 2;
            }
            else
            {
                SacarEnvido();
            }
        }
        private void btnRealEnvidoP1_Click(object sender, EventArgs e)
        {
            if (partida.RealEnvido() == true)
            {
                partida.SeCantoEnvido = 2;

                btnEnvidoP1.Enabled = false;
                btnEnvidoP2.Enabled = false;
                btnRealEnvidoP1.Enabled = false;
                btnRealEnvidoP2.Enabled = false;
                btnFaltaEnvidoP2.Enabled = true;
                btnFaltaEnvidoP1.Enabled = false;

                puntosDeEnvido += 3;
            }
            else
            {
                SacarEnvido();
            }
        }
        private void btnRealEnvidoP2_Click(object sender, EventArgs e)
        {
            if (partida.RealEnvido() == true)
            {
                partida.SeCantoEnvido = 2;

                btnEnvidoP1.Enabled = false;
                btnEnvidoP2.Enabled = false;
                btnRealEnvidoP1.Enabled = false;
                btnRealEnvidoP2.Enabled = false;
                btnFaltaEnvidoP1.Enabled = true;
                btnFaltaEnvidoP2.Enabled = false;

                puntosDeEnvido += 3;
            }
            else
            {
                SacarEnvido();
            }
        }
        private void btnFaltaEnvidoP2_Click(object sender, EventArgs e)
        {
            if (partida.FaltaEnvido() == true)
            {
                partida.SeCantoEnvido = 3;

                SacarEnvido();

                puntosDeEnvido = 30-partida.PuntosJugador1;
            }
            else
            {
                SacarEnvido();
            }
        }
        private void btnFaltaEnvidoP1_Click(object sender, EventArgs e)
        {
            if (partida.FaltaEnvido() == true)
            {
                partida.SeCantoEnvido = 3;

                SacarEnvido();

                puntosDeEnvido = 30 - partida.PuntosJugador2;
            }
            else
            {
                SacarEnvido();
            }
        }

    }
}
