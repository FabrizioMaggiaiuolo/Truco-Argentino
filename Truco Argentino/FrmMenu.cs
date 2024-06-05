using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Truco_Argentino
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevoJuego_Click(object sender, EventArgs e)
        {
            FrmIniciarJugadores frm = new FrmIniciarJugadores();
            frm.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorial frm = new FrmHistorial();
            frm.Show();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            FrmCrearCuenta frm = new FrmCrearCuenta();
            frm.Show();
        }

        private void btnJugarContraIA_Click(object sender, EventArgs e)
        {
            FrmBot frm = new FrmBot();
            frm.Show();
        }
    }
}
