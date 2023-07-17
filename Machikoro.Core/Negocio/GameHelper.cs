using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using Machikoro.Core.Enums;
using Machikoro.Core.Model;

namespace Machikoro.Core.Negocio
{
    public static class GameHelper
    {
        private static string[] nombres = { "Ricardio", "Vicente", "Emiliano", "Felix",
                                   "Verónica", "Montserrat", "Andrea", "Olga", "Nacho", "Domingo",
                                   "César", "Agustín", "Hugo", "Tomás", "Rafael", "Donatello", "Miguel Angel",
                            "Leonardo", "Nieves", "Isabel", "Irene", "Mar", "Alicia", "Carla", "Eva",
                            "Lidia", "Aurora", "Celia", "Claudia", "Amparo", "Sebastián", "Samuel" };

        /// <summary>
        /// Obtiene lista de nombres aleatorios
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetNombres(int numero)
        {
            var copiaNombres = nombres.ToList();
            foreach (int i in Enumerable.Range(0, numero))
            {
                string nombre = General.ElementoAleatorio(copiaNombres);
                copiaNombres.Remove(nombre);
                yield return nombre;
            }
        }

        /// <summary>
        /// Obtiene Los cuatro puntos de interés básicos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<PuntoInteres> GetPuntosInteresBasico()
        {
            foreach (int i in Enumerable.Range(1, 4))
                yield return new PuntoInteres((Punto)i);
        }

        /// <summary>
        /// Obtiene mazo de cartas básico
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Edificio> GetReservaBasico()
        {
            foreach (int i in Enumerable.Range(0, 6))
            {
                yield return GetCampoTrigo();
                yield return GetGranjaGanado();
                yield return GetPanaderia();
                yield return GetCafeteria();
                yield return GetSupermercado();
                yield return GetBosque();
                yield return GetFabricaQueso();
                yield return GetFabricaMuebles();
                yield return GetMina();
                yield return GetRestaurante();
                yield return GetManzanar();
                yield return GetMercado();
            }
            foreach (int i in Enumerable.Range(0, 5))
            {
                yield return GetEstadio();
                yield return GetEstudiosTV();
                yield return GetCentronegocios();
            }
        }

        public static Edificio GetCampoTrigo() => new EdificioAzul(new int[] { 1 }, "Campo de trigo", 1, CampoEdificio.Trigo, 1);
        public static Edificio GetGranjaGanado() => new EdificioAzul(new int[] { 2 }, "Granja de ganado", 1, CampoEdificio.Ganado, 1);
        public static Edificio GetPanaderia() => new EdificioVerde(new int[] { 2, 3 }, "Panadería", 1, CampoEdificio.Comida, 1);
        public static Edificio GetCafeteria() => new Edificio(new int[] { 3 }, "Cafetería", TipoEdificio.Rojo, 2, CampoEdificio.Bebida);
        public static Edificio GetSupermercado() => new EdificioVerde(new int[] { 4 }, "Supermercado", 3, CampoEdificio.Comida, 3);
        public static Edificio GetBosque() => new EdificioAzul(new int[] { 5 }, "Bosque", 3, CampoEdificio.Tecnologia, 1);
        public static Edificio GetEstadio() => new Edificio(new int[] { 6 }, "Estadio", TipoEdificio.Violeta, 6, CampoEdificio.Avanzado);
        public static Edificio GetEstudiosTV() => new Edificio(new int[] { 6 }, "Estudios de TV", TipoEdificio.Violeta, 6, CampoEdificio.Avanzado);
        public static Edificio GetCentronegocios() => new Edificio(new int[] { 6 }, "Centro de negocios", TipoEdificio.Violeta, 6, CampoEdificio.Avanzado);
        public static Edificio GetFabricaQueso() => new EdificioVerde(new int[] { 7 }, "Fábrica de queso", 5, CampoEdificio.Fabrica, 3);
        public static Edificio GetFabricaMuebles() => new EdificioVerde(new int[] { 8 }, "Fábrica de muebles", 5, CampoEdificio.Fabrica, 3);
        public static Edificio GetMina() => new EdificioAzul(new int[] { 9 }, "Mina", 6, CampoEdificio.Tecnologia, 6);
        public static Edificio GetRestaurante() => new Edificio(new int[] { 9, 10 }, "Restaurante", TipoEdificio.Rojo, 3, CampoEdificio.Comida);
        public static Edificio GetManzanar() => new EdificioAzul(new int[] { 10 }, "Manzanar", 3, CampoEdificio.Trigo, 3);
        public static Edificio GetMercado() => new EdificioVerde(new int[] { 11, 12 }, "Mercado", 2, CampoEdificio.Fabrica, 2);


        private static IEnumerable<int> Resultados(int dados = 1)
        {
            foreach (int i in Enumerable.Range(0, dados))
                yield return General.NumAleatorio(1, 6);
        }

        public static Dados LanzarDados(int dados = 1) => new Dados(Resultados());

        /// <summary>
        /// Sortea el jugador inicial de la partida
        /// </summary>
        /// <param name="numjugadores"></param>
        /// <returns></returns>
        public static int PrepararJugadorInicial(int numJugadores) => General.NumAleatorio(0, numJugadores - 1);
        

        #region Ficheros

        //public static List<Record> LeerBestScores()
        //{
        //    string ruta = Properties.Resources.BestScorePath;

        //    try
        //    {
        //        FileStream fs = new FileStream(ruta, FileMode.Open);
        //        BinaryFormatter binForm = new BinaryFormatter();
        //        List<Record> lista = (List<Record>)binForm.Deserialize(fs);
        //        fs.Close();
        //        return lista;
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return new List<Record>();
        //    }
        //}

        //public static void GuardarPuntuacion(Record score)
        //{
        //    var scores = LeerBestScores();
        //    scores.Add(score);
        //    FileStream fs = new FileStream(Properties.Resources.BestScorePath, FileMode.Create);
        //    BinaryFormatter binForm = new BinaryFormatter();
        //    binForm.Serialize(fs, scores);
        //    fs.Close();
        //}

        #endregion
    }
}