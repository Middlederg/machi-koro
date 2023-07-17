using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Machikoro.Core.Enums;
using Machikoro.Core.Negocio;

namespace Machikoro.Core.Model
{
    public interface IEdificio
    {
        string Nombre { get; set; }
        IEnumerable<int> Numeros { get; set; }
        int Coste { get; set; }
        CampoEdificio Campo { get; set; }

        TipoEdificio Tipo();
        Color ColorEdificio();

        void Activar(Juego juego);
    }

    public abstract class Edificio : IEdificio
    {
        public Color[] colores = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Purple };

        public string Nombre { get; set; }
        public IEnumerable<int> Numeros { get; set; }
        public int Coste { get; set; }
        public CampoEdificio Campo { get; set; }
        public string CampoDescripcion => Campo.Descripcion(); 

        public Edificio(IEnumerable<int> numerosActivan, string nombre, int coste, CampoEdificio campo)
        {
            Nombre = nombre;
            Numeros = numerosActivan;
            Coste = coste;
            Campo = campo;
        }

        public bool EsEspecial() => Campo.Equals(CampoEdificio.Avanzado);

        public bool EsActivado(int num) => Numeros.Contains(num);

        public string Imagen(bool grande = true)
        {
            string res = "";
            foreach (string s in Nombre.Split(' '))
                res += s.First().ToString().ToUpper() + s.Substring(1).ToLower();
            return grande ? res + "2" : res + "1";
        }

        public override string ToString() => Nombre;
        public override bool Equals(object obj) => ((Edificio)obj).Nombre.Equals(Nombre);
        public override int GetHashCode() => Nombre.GetHashCode();

        public virtual TipoEdificio Tipo() => throw new NotImplementedException();
        public virtual Color ColorEdificio() => throw new NotImplementedException();

        public void Activar(Juego juego, int resultado)
        {
            if (Numeros.Contains(resultado))
                Activar(juego); 
        }

        public virtual void Activar(Juego juego)
        {
            throw new NotImplementedException();
        }
    }

    public class EdificioAzul : Edificio
    {
        public int Beneficio { get; set; }

        public EdificioAzul(IEnumerable<int> numerosActivan, string nombre, int coste, CampoEdificio campo, int beneficio) : 
            base(numerosActivan, nombre, coste, campo)
        {
            Beneficio = beneficio;
        }

        /// <summary>
        /// Recibes monedas de la reserva en el turno de cualquier jugador.
        /// </summary>
        /// <param name="juego"></param>
        public override void Activar(Juego juego)
        {
            foreach(Jugador j in juego.Jugadores)
                j.Monedas += Beneficio;
        }

        public override TipoEdificio Tipo() => TipoEdificio.Azul;
        public override Color ColorEdificio() => Color.Blue;
    }

    public class EdificioVerde : Edificio
    {
        public int Beneficio { get; set; }

        public EdificioVerde(IEnumerable<int> numerosActivan, string nombre, int coste, CampoEdificio campo, int beneficio) :
            base(numerosActivan, nombre, coste, campo)
        {
            Beneficio = beneficio;
        }

        /// <summary>
        /// Recibes monedas de la reserva, pero solo en tu turno.
        /// </summary>
        /// <param name="juego"></param>
        public override void Activar(Juego juego)
        {
            if (CampoDescripcion.Equals(CampoEdificio.Fabrica))
                juego.ElTurno().Monedas += Beneficio * juego.ElTurno().NumeroEdificios(Campo);
            else
                juego.ElTurno().Monedas += Beneficio + (juego.ElTurno().TieneCentroComercial() ? 1 : 0);
        }
        
        public override TipoEdificio Tipo() => TipoEdificio.Verde;
        public override Color ColorEdificio() => Color.Green;

    }

    public class EdificioRojo : Edificio
    {
        public int Penalizacion { get; set; }

        public EdificioRojo(IEnumerable<int> numerosActivan, string nombre, int coste, CampoEdificio campo, int penalizacion) :
            base(numerosActivan, nombre, coste, campo)
        {
            Penalizacion = penalizacion;
        }

        /// <summary>
        /// Debes dar monedas a otros jugadores
        /// </summary>
        /// <param name="juego"></param>
        public override void Activar(Juego juego)
        {
            if(juego.ElTurno().)
            foreach (var jugador in juego.Jugadores.Where(x=> !x.Equals(juego.ElTurno())))
            {
                int monedas = Penalizacion + (juego.ElTurno().TieneCentroComercial() ? 1 : 0);
                jugador.Monedas += 
            }

            if (CampoDescripcion.Equals(CampoEdificio.Fabrica))
                juego.ElTurno().Monedas += Beneficio * juego.ElTurno().NumeroEdificios(Campo);
            else
                juego.ElTurno().Monedas += Beneficio;
        }

        public override TipoEdificio Tipo() => TipoEdificio.Rojo;
        public override Color ColorEdificio() => Color.Red;

    }

}


