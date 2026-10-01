namespace Contratos;

// La implementación real: tarifa por hora más los adicionales, con el mismo
// descuento del 12% para clientes corporativos que ya viste duplicado en
// GestorReservas.cs.
public class CalculadoraPrecioEstandar : ICalculadoraDePrecio
{
    public DesglosePrecio Calcular(SolicitudDeReserva solicitud)
    {
        decimal subtotal = solicitud.TarifaHora * solicitud.Horas;
        if (solicitud.ConCatering) subtotal += 15000m;
        if (solicitud.ConProyector) subtotal += 5000m;

        decimal descuento = solicitud.TipoCliente == "CORPORATIVO" ? subtotal * 0.12m : 0m;

        return new DesglosePrecio
        {
            Subtotal = subtotal,
            Descuento = descuento,
            Total = subtotal - descuento
        };
    }
}
