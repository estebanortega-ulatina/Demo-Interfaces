namespace Contratos;

// Un doble de prueba: cumple el contrato, pero no calcula nada real -- siempre
// devuelve el mismo desglose fijo. Sirve para probar a quien USA la calculadora
// sin depender de su lógica interna, ni de disco ni de red.
public class CalculadoraPrecioFalsa : ICalculadoraDePrecio
{
    public DesglosePrecio Calcular(SolicitudDeReserva solicitud)
    {
        return new DesglosePrecio { Subtotal = 100000m, Descuento = 0m, Total = 100000m };
    }
}
