
using System.ComponentModel;

namespace Machikoro.Core.Enums
{
    /// <summary>
    /// Campo en el que se engloba el edificio
    /// </summary>
    public enum CampoEdificio
    {
        [Description("Trigo")]
        Trigo = 1,

        [Description("Ganado")]
        Ganado = 2,

        [Description("Comida")]
        Comida = 3,

        [Description("Bebida")]
        Bebida = 4,

        [Description("Tecnología")]
        Tecnologia = 5,

        [Description("Avanzado")]
        Avanzado = 6,

        [Description("Fábrica")]
        Fabrica = 7,

        [Description("Pesca")]
        Pesca = 8,
    }
}
