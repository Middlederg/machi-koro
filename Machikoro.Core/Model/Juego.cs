using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machikoro.Core.Negocio;
using Machikoro.Core.Enums;

namespace Machikoro.Core.Model
{
    public class Juego
    {
        public int Id { get; set; }
        public List<Jugador> Jugadores { get; set; }
        public List<Edificio> Reserva { get; set; }
        public int Turno { get; set; }
        public List<string> Log { get; set; }

     
        public Juego(string[] nombres)
        {
            Jugadores = new List<Jugador>();
            for (int i = 0; i < nombres.Length; i++)
                Jugadores.Add(new Jugador(i, nombres[i]));

            Log = new List<string> { "Comienza el juego. Partida a " + Jugadores.Count + " jugadores" };
            ResetGame();
        }

        /// <summary>
        /// Reinicia el juego
        /// </summary>
        public void ResetGame()
        {
            Id++;
            if (Id > 1) Log.Add("Partida reiniciada");
            Jugadores.ForEach(x => x.Reset());
            Turno = GameHelper.PrepararJugadorInicial(Jugadores.Count);
            Log.Add(Jugadores[Turno].Nombre + " comienza la partida");
            Reserva = GameHelper.GetReservaBasico().ToList();
        }

        /// <summary>
        /// Devuelve el jugador que tiene el turno
        /// </summary>
        /// <returns></returns>
        public Jugador ElTurno() => Jugadores[Turno];

        /// <summary>
        /// El turno pasa al siguiente jugador
        /// </summary>
        public void AvanzaTurno() => Turno = (Turno == Jugadores.Count - 1) ? 0 : Turno + 1;


        public Edificio ComprarEdificio(Edificio e, Jugador jug = null)
        {
            if (jug == null) jug = ElTurno();
            if (!Reserva.Contains(e)) throw new ArgumentException(e.ToString() + " no se puede comprar");
            Reserva.Remove(e);
            jug.Edificios.Add(e);
            return e;
        }

        public void ActivarEdificios(int resultado)
        {
            Jugadores.ForEach( jug=>
                jug.Edificios.ForEach(e=>
                {
                    if (!(e.Tipo().Equals(TipoEdificio.Rojo) && ElTurno().Equals(jug)))
                        e.Activar(this);
                })
             );
            //foreach (Jugador jug in Jugadores)
            //{
            //    foreach (var edificio in jug.Edificios)
            //    {
            //        if(!(edificio.Tipo().Equals(TipoEdificio.Rojo) && ElTurno().Equals(jug)))
            //            edificio.Activar(this);
            //    }
            //}
        }
    }

    public class JuegoHelper
    {
        /// <summary>
        /// Ordena los jugadores a partir de un jugador en concreto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Jugador> OrdenarDesde(this List<Jugador> jugs, Jugador jugActivo)
        {
            bool found = false;
            var copiaJugs = new List<Jugador>() { jugActivo };
            foreach (Jugador j in jugs)
            {
                if (found)
                    copiaJugs.Add(j);
                if(j.Equals(jugActivo))
                    found = true;
            }
            foreach (Jugador j in jugs)
                if()
        }
    }
}
