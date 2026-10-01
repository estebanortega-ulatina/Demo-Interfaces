namespace Contratos;

// Mal diseño, solo para comparar: crea su propia calculadora adentro, en vez
// de recibirla. Funciona igual de bien hoy, pero no se puede sustituir ni
// probar aislado -- mira ContratosTests.cs para ver la diferencia.
public class ProcesadorDeReservaAcoplado
{
    public decimal CalcularTotal(SolicitudDeReserva solicitud)
    {
        var calculadora = new CalculadoraPrecioEstandar();
        return calculadora.Calcular(solicitud).Total;
    }
}
