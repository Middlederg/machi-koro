using System;

namespace Machikoro.Core.Enums
{
    [AttributeUsage(AttributeTargets.All)]
    public class PuntoAttribute : Attribute
    {
        public string Nombre { get; set; }
        public int Coste { get; set; }
        public string Descripcion { get; set; }

        public PuntoAttribute(string nombre, int coste, string desc)
        {
            Nombre = nombre;
            Coste = coste;
            Descripcion = desc;
        }
    }
}
