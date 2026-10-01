namespace Contratos;

// Los datos que necesita cualquier cálculo de precio, y solo esos.
public class SolicitudDeReserva
{
    public string TipoCliente = "REGULAR";   // "REGULAR", "CORPORATIVO", "ESTUDIANTIL"
    public decimal TarifaHora;
    public int Horas;
    public bool ConCatering;
    public bool ConProyector;
}
