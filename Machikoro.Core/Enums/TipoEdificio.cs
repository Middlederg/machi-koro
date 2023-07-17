using System.ComponentModel;

namespace Machikoro.Core.Enums
{
    /// <summary>
    /// Tipo de edificio según el color y su funcionalidad
    /// </summary>
    public enum TipoEdificio
    {
        [Funcion("Recibes monedas de la reserva en el turno de cualquier jugador")]
        [Description("Sector primario")]
        Azul = 1,

        [Funcion("Recibes monedas de la reserva, pero solo en tu turno")]
        [Description("Tiendas, fábricas, mercados")]
        Verde = 2,

        [Funcion("Recibes monedas del jugador que haya lanzado los dados")]
        [Description("Restaurantes y cafeterías")]
        Rojo = 3,

        [Funcion("Recibes monedas de otros jugadores, pero solo en tu turno")]
        [Description("Edificios avanzados")]
        Violeta = 4
    }
}
