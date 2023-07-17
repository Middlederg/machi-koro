using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machikoro.Core.Enums;
using Machikoro.Core.Negocio;

namespace Machikoro.Core.Model
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Monedas { get; set; }
        public List<Edificio> Edificios { get; set; }
        public List<PuntoInteres> PuntosDeInteres { get; set; }

        public Jugador(int id, string nombre) 
        {
            Id = id;
            Nombre = nombre;
            Reset();
        }

		public void Reset()
		{
			Edificios = new List<Edificio>();
			PuntosDeInteres = GameHelper.GetPuntosInteresBasico().ToList();
            Monedas = 3;
		}

        /// <summary>
        /// Indica si se puede permitir comprar el edificio
        /// </summary>
        /// <param name="edificio"></param>
        /// <returns></returns>
        public bool PuedeComprar(IEdificio edificio)
        {
            //Solo puedes tener un edificio violeta
            if (edificio.Tipo().Equals(TipoEdificio.Violeta) && NumeroEdificios(TipoEdificio.Violeta) > 0)
                return false;
            return (edificio.Coste <= Monedas);
        }

        /// <summary>
        /// Indica si se puede permitir comprar el punto de interés
        /// </summary>
        /// <param name="edificio"></param>
        /// <returns></returns>
        public bool PuedeComprar(PuntoInteres pinteres) => (pinteres.Coste <= Monedas);

        public bool TienePuntoInteres(PuntoInteres pi) => PuntosDeInteres.Find(x => x.Equals(pi)).Activado;

        public int NumeroEdificios(Edificio e) => Edificios.Count(x => x.Equals(e));
        public int NumeroEdificios(CampoEdificio campo) => Edificios.Count(x => x.Campo.Equals(campo));
        public int NumeroEdificios(TipoEdificio tipo) => Edificios.Count(x => x.Tipo().Equals(tipo));

        public PuntoInteres GetPuntoInteres(Punto punto) => PuntosDeInteres.Find(x => x.PuntoDeInteres.Equals(punto));
        public bool TieneEstacionTren() => GetPuntoInteres(Punto.EstacionTren).Activado;
        public bool TieneCentroComercial() => GetPuntoInteres(Punto.CentroComercial).Activado;
        public bool TieneParqueAtracciones() => GetPuntoInteres(Punto.ParqueAtracciones).Activado;
        public bool TieneTorreRadiodifusion() => GetPuntoInteres(Punto.TorreRadiodifusion).Activado;

        /// <summary>
        /// Un jugador consigue la victoria cuando tiene todos los puntos de interés
        /// </summary>
        /// <returns></returns>
        public bool Victoria() => PuntosDeInteres.All(x => x.Activado);
		
		public override string ToString() => Nombre;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Jugador)obj).Id == Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
