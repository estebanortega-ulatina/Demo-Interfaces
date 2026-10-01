namespace Contratos;

// El mismo contrato que se escribió en vivo en la sesión 3.
// No escribe en disco, no envía correos, no depende de la hora del sistema.
public interface ICalculadoraDePrecio
{
    DesglosePrecio Calcular(SolicitudDeReserva solicitud);
}
