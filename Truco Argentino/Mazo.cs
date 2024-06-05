using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Truco_Argentino
{
    public class Mazo
    {
        private List<Carta> cartas;

        public Mazo()
        {
            this.cartas = new List<Carta>();

            this.ReponerCartas();
        }
        /// <summary>
        /// Limpia y carga todas las cartas del truco en el mazo
        /// </summary>
        public void ReponerCartas()
        {

            cartas.Clear();
            
           #region cartas

            cartas.Add(new Carta(140, EPalo.Espada, 1));

            cartas.Add(new Carta(130, EPalo.Basto, 1));

            cartas.Add(new Carta(120, EPalo.Espada, 7));

            cartas.Add(new Carta(110, EPalo.Oro, 7));

            cartas.Add(new Carta(100, EPalo.Espada, 3));
            cartas.Add(new Carta(100, EPalo.Oro, 3));
            cartas.Add(new Carta(100, EPalo.Copa, 3));
            cartas.Add(new Carta(100, EPalo.Basto, 3));

            cartas.Add(new Carta(90, EPalo.Espada, 2));
            cartas.Add(new Carta(90, EPalo.Oro, 2));
            cartas.Add(new Carta(90, EPalo.Copa, 2));
            cartas.Add(new Carta(90, EPalo.Basto, 2));

            cartas.Add(new Carta(80, EPalo.Oro, 1));
            cartas.Add(new Carta(80, EPalo.Copa, 1));

            cartas.Add(new Carta(70, EPalo.Espada, 12));
            cartas.Add(new Carta(70, EPalo.Oro, 12));
            cartas.Add(new Carta(70, EPalo.Copa, 12));
            cartas.Add(new Carta(70, EPalo.Basto, 12));

            cartas.Add(new Carta(60, EPalo.Espada, 11));
            cartas.Add(new Carta(60, EPalo.Oro, 11));
            cartas.Add(new Carta(60, EPalo.Copa, 11));
            cartas.Add(new Carta(60, EPalo.Basto, 11));

            cartas.Add(new Carta(50, EPalo.Espada, 10));
            cartas.Add(new Carta(50, EPalo.Oro, 10));
            cartas.Add(new Carta(50, EPalo.Copa, 10));
            cartas.Add(new Carta(50, EPalo.Basto, 10));

            cartas.Add(new Carta(40, EPalo.Basto, 7));
            cartas.Add(new Carta(40, EPalo.Copa, 7));

            cartas.Add(new Carta(30, EPalo.Espada, 6));
            cartas.Add(new Carta(30, EPalo.Oro, 6));
            cartas.Add(new Carta(30, EPalo.Copa, 6));
            cartas.Add(new Carta(30, EPalo.Basto, 6));

            cartas.Add(new Carta(20, EPalo.Espada, 5));
            cartas.Add(new Carta(20, EPalo.Oro, 5));
            cartas.Add(new Carta(20, EPalo.Copa, 5));
            cartas.Add(new Carta(20, EPalo.Basto, 5));

            cartas.Add(new Carta(10, EPalo.Espada, 4));
            cartas.Add(new Carta(10, EPalo.Oro, 4));
            cartas.Add(new Carta(10, EPalo.Copa, 4));
            cartas.Add(new Carta(10, EPalo.Basto, 4));

            #endregion


            /* INTENTO DE DESERIALIZARLO DE UN ARCHIVO (TIRA EXCEPCION de STACKOVERFLOW)
            StreamReader jsonStream = new StreamReader(".\\mazo.json");

            var json = jsonStream.ReadToEnd();
            
            this.cartas = JsonConvert.DeserializeObject<Mazo>(json).Cartas;
            

            jsonStream.Close();
            */
        }
        /// <summary>
        /// Devuelve que carta es de mayor valor o en caso contrario si son iguales
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
                respuesta = 2;
            }
            return respuesta;
        }
        public List<Carta> Cartas { get { return this.cartas; } }
    }
}
