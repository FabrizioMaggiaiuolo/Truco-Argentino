using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco_Argentino
{
    public class Carta
    {
        private int valor;
        private EPalo palo;
        private int numero;

        public Carta(int valor, EPalo palo, int numero)
        {
            this.valor = valor;
            this.palo = palo;
            this.numero = numero;
        }

        public override string ToString()
        {
            return this.numero + " " + this.palo;
        }

        public int Valor { get { return this.valor; } }
        public EPalo Palo { get { return this.palo; } }
        public int Numero { get { return this.numero; } }

        public Mazo Mazo
        {
            get => default;
            set
            {
            }
        }
    }


}
