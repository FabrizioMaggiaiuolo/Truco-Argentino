using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;


namespace Truco_Argentino
{
    public class ADO 
    {

        private static string cadenaConexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static ADO()
        {
            ADO.cadenaConexion = @"Server=DESKTOP-PFME98P;Database=Laboratorio;Trusted_Connection=True;";
        }

        public ADO()
        {
            this.conexion = new SqlConnection(ADO.cadenaConexion);
        }
        /// <summary>
        /// Agregar un jugador a la base de datos
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public bool Agregar(Jugador jugador)
        {
            bool retorno = true;
            ADO ado = new ADO();
            ado.comando = new SqlCommand();


            try
            {
                ado.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                ado.comando.Parameters.AddWithValue("@contraseña", jugador.Contraseña);

                ado.comando.CommandType = CommandType.Text;
                ado.comando.CommandText = "INSERT INTO Jugadores (nombre, contraseña) VALUES (@nombre,@contraseña)";
                ado.comando.Connection = ado.conexion;

                ado.conexion.Open();

                int filasAgragadas = ado.comando.ExecuteNonQuery();
                if (filasAgragadas == 0)
                {
                    retorno = false;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                if(ado.conexion.State == ConnectionState.Open)
                {
                    ado.conexion.Close();
                }
                ado.conexion.Close();
            }

            return retorno;
        }
        /// <summary>
        /// Devuelve toda la lista de jugadores en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Jugador> ObtenerTodaLaLista()
        {
            
            List<Jugador> jugadores = new List<Jugador>();

            this.comando = new SqlCommand();
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = "SELECT * FROM Jugadores";
            this.comando.Connection = this.conexion;
            
            this.conexion.Open();

            this.lector = this.comando.ExecuteReader();

            int id;
            string nombre;
            string contraseña;

            while (this.lector.Read())
            {
                id = this.lector.GetInt32(0);
                nombre = this.lector.GetString(1);
                contraseña = this.lector.GetString(2);

                Jugador jugador = new Jugador(nombre.Substring(0,nombre.IndexOf(" ")),contraseña.Substring(0,contraseña.IndexOf(" ")),id);

                jugadores.Add(jugador);

            }

            this.lector.Close();

            this.conexion.Close();

            return jugadores;
        }

    }

    public class ADOPartidas
    {
        private static string cadenaConexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static ADOPartidas()
        {
            ADOPartidas.cadenaConexion = @"Server=DESKTOP-PFME98P;Database=Laboratorio;Trusted_Connection=True;";
        }

        public ADOPartidas()
        {
            this.conexion = new SqlConnection(ADOPartidas.cadenaConexion);
        }
        /// <summary>
        /// Agrega una partida a la base de datos
        /// </summary>
        /// <param name="partida"></param>
        /// <returns></returns>
        public bool Agregar(Partida partida)
        {
            bool retorno = true;
            ADOPartidas ado = new ADOPartidas();
            ado.comando = new SqlCommand();

            try
            {
                ado.comando.Parameters.AddWithValue("@idJugador1", partida.IDJugador1);
                ado.comando.Parameters.AddWithValue("@idJugador2", partida.IDJugador2);
                ado.comando.Parameters.AddWithValue("@cantidadManos", partida.Ronda);
                ado.comando.Parameters.AddWithValue("@puntosJugador1", partida.PuntosJugador1);
                ado.comando.Parameters.AddWithValue("@puntosJugador2", partida.PuntosJugador2);
                ado.comando.Parameters.AddWithValue("@idGanador", partida.IDGanador);

                ado.comando.CommandType = CommandType.Text;
                ado.comando.CommandText = "INSERT INTO Partidas (idJugador1, idJugador2,cantidadRondas,puntosJugador1,puntosJugador2,idGanador) VALUES (@idJugador1,@idJugador2,@cantidadManos,@puntosJugador1,@puntosJugador2,@idGanador)";
                ado.comando.Connection = ado.conexion;

                ado.conexion.Open();

                int filasAgragadas = ado.comando.ExecuteNonQuery();
                if (filasAgragadas == 0)
                {
                    retorno = false;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                if (ado.conexion.State == ConnectionState.Open)
                {
                    ado.conexion.Close();
                }
                ado.conexion.Close();
            }

            return retorno;
        }
        /// <summary>
        /// Devuelve toda las lista de partidas que hay en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Partida> ObtenerTodaLaLista()
        {

            List<Partida> partidas = new List<Partida>();

            this.comando = new SqlCommand();
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = "SELECT * FROM Partidas";
            this.comando.Connection = this.conexion;

            this.conexion.Open();

            this.lector = this.comando.ExecuteReader();

            int idPartida, id1, id2, cantidadManos, puntos1, puntos2, idGanador;

            while (this.lector.Read())
            {
                idPartida = this.lector.GetInt32(0);
                id1 = this.lector.GetInt32(1);
                id2 = this.lector.GetInt32(2);
                cantidadManos = this.lector.GetInt32(3);
                puntos1 = this.lector.GetInt32(4);
                puntos2 = this.lector.GetInt32(5);
                idGanador = this.lector.GetInt32(6);

                Partida partida = new Partida(idPartida,id1,id2,cantidadManos,puntos1,puntos2,idGanador);

                partidas.Add(partida);

            }

            this.lector.Close();

            this.conexion.Close();

            return partidas;
        }
    }
}
