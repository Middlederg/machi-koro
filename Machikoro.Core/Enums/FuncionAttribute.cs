using System;

namespace Machikoro.Core.Enums
{
    [AttributeUsage(AttributeTargets.All)]
    public class FuncionAttribute : Attribute
    {
        public string Funcion { get; set; }
        public FuncionAttribute(string funcion)
        {
            Funcion = funcion;
        }
    }
}
