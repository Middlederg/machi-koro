using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machikoro.Core.Enums;

namespace Machikoro.Core
{
    public class PuntoInteres
    {
        public Punto PuntoDeInteres { get; set; }
        public string Nombre => MetaDatos().Nombre;
        public string Descripcion => MetaDatos().Descripcion;
        public int Coste => MetaDatos().Coste;
        private bool activado;
        public bool Activado { get => activado; }

        public PuntoInteres(Punto pInteres)
        {
            PuntoDeInteres = pInteres;
            activado = false;
        }
        
        public string Imagen(bool grande = true)
        {
            string res = "";
            foreach (string s in Nombre.Split(' '))
                res += s.First().ToString().ToUpper() + s.Substring(1).ToLower();
            return grande ? res + "2" : res + "1";
        }

        private PuntoAttribute MetaDatos()
        {
            Type type = PuntoDeInteres.GetType();
            PuntoAttribute atributo = Attribute.GetCustomAttribute(type.GetField(Enum.GetName(typeof(Punto), PuntoDeInteres)),
                               typeof(PuntoAttribute)) as PuntoAttribute;
            return atributo;
        }

        public override string ToString() => Nombre;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((PuntoInteres)obj).PuntoDeInteres.Equals(PuntoDeInteres);
        }

        public override int GetHashCode() => ((int)PuntoDeInteres).GetHashCode();
    }
}
