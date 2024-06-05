using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Truco_Argentino
{
    public partial class FrmContador : Form
    {
        Partida partida;

        CancellationTokenSource token = new CancellationTokenSource();
        CancellationToken cancelarToken;

        public FrmContador(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
            cancelarToken = token.Token;
        }
        /// <summary>
        /// Genera el contador de puntos de la partida en un hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmContador_Load(object sender, EventArgs e)
        {
            Task hilo = new Task(() => Contador(cancelarToken));
            
            hilo.Start();
        }
        /// <summary>
        /// Detiene el Hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmContador_FormClosing(object sender, FormClosingEventArgs e)
        {
            token.Cancel();
        }

        private void Contador(CancellationToken token)
        {
            while (true)
            {
                Thread.Sleep(1000);
                SumarPuntosEnElForm();
            }
        }

        private void SumarPuntosEnElForm()
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            if (this.txtPuntosJugador1.InvokeRequired)
            {
                Action d = new Action(this.CambiarPuntos);

                this.txtPuntosJugador1.Invoke(d);
            }
            else
            {
                CambiarPuntos();
            }

            if (this.txtPuntosJugador2.InvokeRequired)
            {
                Action d = new Action(this.CambiarPuntos);

                this.txtPuntosJugador2.Invoke(d);
            }
            else
            {
                CambiarPuntos();
            }
        }

        private void CambiarPuntos()
        {
            if (partida.PuntosJugador1 != int.Parse(this.PuntosJugador1))
            {
                this.PuntosJugador1 = partida.PuntosJugador1.ToString();
            }

            if (partida.PuntosJugador2 != int.Parse(this.PuntosJugador2))
            {
                this.PuntosJugador2 = partida.PuntosJugador2.ToString();
            }
        }

        private string PuntosJugador1 { set { txtPuntosJugador1.Text = value; }  get { return txtPuntosJugador1.Text; } }
        private string PuntosJugador2 { set { txtPuntosJugador2.Text = value; } get { return txtPuntosJugador2.Text; } }
    }
}
