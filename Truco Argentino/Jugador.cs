using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Truco_Argentino
{
    public class Jugador
    {
        private int id;
        private string nombre;
        private string contraseña;

        public Jugador(string nombre, string contraseña)
        {
            this.id = 0;
            this.nombre = nombre;
            this.contraseña = contraseña;
        }
        public Jugador(string nombre, string contraseña, int id) : this(nombre,contraseña)
        {
            this.id = id;
        }

        public int ID { get { return this.id; } }
        public string Nombre { get { return this.nombre; } }
        public string Contraseña { get { return this.contraseña; } }
    }
}
