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
    public class Partida
    {
        private int idPartida = 0;
        private int idJugador1;
        private int idJugador2;

        private int puntosJugador1;
        private int puntosJugador2;

        private int idGanador;

        private Mazo mazo;
        private List<Carta> cartasJugador1 = new List<Carta>();
        private List<Carta> cartasJugador2 = new List<Carta>();

        private List<Carta> cartasJugadas1Mano = new List<Carta>();
        private List<Carta> cartasJugadas2Mano = new List<Carta>();
        private List<Carta> cartasJugadas3Mano = new List<Carta>();

        private int ronda = 1;
        private int seCantoTruco = 0;
        private int seCantoEnvido = 0;

        string[] stringTruco = { "Truco","Retruco","Vale Cuatro"};

        public Partida(int id1, int id2)
        {
            this.idJugador1 = id1;
            this.idJugador2 = id2;

            this.idGanador = -1;

            this.puntosJugador1 = 0;
            this.puntosJugador2 = 0;

            mazo = new Mazo();
        }

        public Partida(int idPartida,int id1,int id2,int cantidadManos, int puntos1,int puntos2,int idGanador)
        {
            this.idPartida = idPartida;
            this.idJugador1 = id1;
            this.idJugador2 = id2;
            this.ronda = cantidadManos;
            this.puntosJugador1 = puntos1;
            this.puntosJugador2 = puntos2;
            this.idGanador = idGanador;
        }

        /// <summary>
        /// Revisa a que jugador se le debe sumar los puntos del envido
        /// </summary>
        /// <param name="puntosDeEnvido">Los puntos acumulados</param>
        /// <param name="jugadorMano">El jugador que es mano</param>
        public void SumarPuntosDeEnvido(int puntosDeEnvido, int jugadorMano)
        {
            int puntosEnvidoJugador1 = 0;
            int puntosEnvidoJugador2 = 0;
            
            for(int i = 0;i<2;i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if(cartasJugador1[i].Palo == cartasJugador1[j].Palo)
                    {
                        puntosEnvidoJugador1 = 20;
                        if(cartasJugador1[i].Numero < 10)
                        {
                            puntosEnvidoJugador1 += cartasJugador1[i].Numero;
                        }
                        if (cartasJugador1[j].Numero < 10)
                        {
                            puntosEnvidoJugador1 += cartasJugador1[j].Numero;
                        }
                    }
                    if (cartasJugador2[i].Palo == cartasJugador2[j].Palo)
                    {
                        puntosEnvidoJugador2 = 20;
                        if (cartasJugador2[i].Numero < 10)
                        {
                            puntosEnvidoJugador2 += cartasJugador2[i].Numero;
                        }
                        if (cartasJugador2[j].Numero < 10)
                        {
                            puntosEnvidoJugador2 += cartasJugador2[j].Numero;
                        }
                    }
                }
            }

            if(puntosJugador1 > puntosJugador2)
            {
                this.puntosJugador1 += puntosDeEnvido;
            }
            else
            {
                if (puntosJugador1 < puntosJugador2)
                {
                    this.puntosJugador2 += puntosDeEnvido;
                }
                else
                {
                    if(jugadorMano == 1)
                    {
                        this.puntosJugador1 += puntosDeEnvido;
                    }
                    else
                    {
                        this.puntosJugador2 += puntosDeEnvido;
                    }
                }
            }
        }
        /// <summary>
        /// Reparte las cartas
        /// </summary>
        public void RepartirCartas()
        {
            cartasJugador1.Clear();
            cartasJugador2.Clear();

            Random random = new Random();
            int numero = random.Next(0, 39);
            cartasJugador1.Add(mazo.Cartas[numero]);
            mazo.Cartas.RemoveAt(numero);
            numero = random.Next(0, 38);
            cartasJugador1.Add(mazo.Cartas[numero]);
            mazo.Cartas.RemoveAt(numero);
            numero = random.Next(0, 37);
            cartasJugador1.Add(mazo.Cartas[numero]);
            mazo.Cartas.RemoveAt(numero);

            numero = random.Next(0, 36);
            cartasJugador2.Add(mazo.Cartas[numero]);
            mazo.Cartas.RemoveAt(numero);
            numero = random.Next(0, 35);
            cartasJugador2.Add(mazo.Cartas[numero]);
            mazo.Cartas.RemoveAt(numero);
            numero = random.Next(0, 34);
            cartasJugador2.Add(mazo.Cartas[numero]);
            mazo.Cartas.RemoveAt(numero);

            mazo.ReponerCartas();
        }
        /// <summary>
        /// Devuelve cual de las 2 cartas es de mayor valor o en caso contrario si son de igual valor
        /// </summary>
        /// <param name="carta1"></param>
        /// <param name="carta2"></param>
        /// <returns></returns>
        public int CompararCartas(Carta carta1, Carta carta2)
        {
            int respuesta = -1;
            if (carta1.Valor > carta2.Valor)
            {
                respuesta = 1;
            }
            else
            {
                if (carta1.Valor < carta2.Valor)
                {
                    respuesta = 2;
                }
            }
            return respuesta;
        }

        public bool Mensaje(string mensaje, string titulo)
        {
            bool retorno = false;
            if (MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                retorno = true;
            }
            return retorno;
        }

        public bool Envido()
        {
            return Mensaje("Canto envido", "Acepta el envido?");
        }
        public bool RealEnvido()
        {
            return Mensaje("Canto feal envido", "Acepta el real envido?");
        }
        public bool FaltaEnvido()
        {
            return Mensaje("Canto falta envido", "Acepta la falta envido?");
        }

        public int IDPartida { get { return this.idPartida; } }
        public int IDJugador1 { get { return this.idJugador1; } }
        public int IDJugador2 { get { return this.idJugador2; } }
        public int IDGanador { set { this.idGanador = value; } get { return this.idGanador; } }

        public int PuntosJugador1 { set { this.puntosJugador1 = value; } get { return this.puntosJugador1; } }
        public int PuntosJugador2 { set { this.puntosJugador2 = value; } get { return this.puntosJugador2; } }
        public List<Carta> CartasJugador1 { get { return this.cartasJugador1; } }
        public List<Carta> CartasJugador2 { get { return this.cartasJugador2; } }

        public List<Carta> CartasJugas1Mano { set { this.cartasJugadas1Mano = value; } get { return this.cartasJugadas1Mano; } }
        public List<Carta> CartasJugas2Mano { set { this.cartasJugadas2Mano = value; } get { return this.cartasJugadas2Mano; } }
        public List<Carta> CartasJugas3Mano { set { this.cartasJugadas3Mano = value; } get { return this.cartasJugadas3Mano; } }
        public int Ronda { set { this.ronda = value; } get { return this.ronda; } }
        public int SeCantoTruco { set { this.seCantoTruco = value; } get { return this.seCantoTruco; } }
        public int SeCantoEnvido { set { this.seCantoEnvido = value; } get { return this.seCantoEnvido; } }
        public string[] StringTruco { get { return this.stringTruco; } }

        public override string ToString()
        {
            return "Partida " + this.idPartida;
        }
    }
}
