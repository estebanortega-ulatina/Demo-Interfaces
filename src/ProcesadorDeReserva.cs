namespace Contratos;

// Buen diseño: recibe el contrato por constructor. No le importa qué
// implementación use, mientras cumpla ICalculadoraDePrecio.
public class ProcesadorDeReserva
{
    private readonly ICalculadoraDePrecio _calculadora;

    public ProcesadorDeReserva(ICalculadoraDePrecio calculadora)
    {
        _calculadora = calculadora;
    }

    public decimal CalcularTotal(SolicitudDeReserva solicitud)
    {
        return _calculadora.Calcular(solicitud).Total;
    }
}
