namespace Machikoro.Core.Enums
{
    public enum Punto
    {
        [Punto("Estación de tren", 4, "Permite lanzar dos dados")]
        EstacionTren = 1,

        [Punto("Centro comercial", 10,"Añade una moneda extra por edificio de comida")]
        CentroComercial = 2,

        [Punto("Parque de atracciones", 16,"Permite efectuar un turno extra al sacar dobles")]
        ParqueAtracciones = 3,

        [Punto("Torre de radiodifusión", 22,"Permite relanzar los dados")]
        TorreRadiodifusion = 4
    }
}
