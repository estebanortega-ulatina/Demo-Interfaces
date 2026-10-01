using Contratos;
using Xunit;

namespace Contratos.Pruebas;

public class ContratosTests
{
    [Fact]
    public void CalculadoraEstandar_AplicaDescuentoCorporativo()
    {
        var calculadora = new CalculadoraPrecioEstandar();
        var solicitud = new SolicitudDeReserva { TipoCliente = "CORPORATIVO", TarifaHora = 10000m, Horas = 4 };

        var desglose = calculadora.Calcular(solicitud);

        Assert.Equal(40000m, desglose.Subtotal);
        Assert.Equal(4800m, desglose.Descuento);
        Assert.Equal(35200m, desglose.Total);
    }

    [Fact]
    public void ProcesadorDeReserva_SePruebaConUnDoble_SinTocarLaCalculadoraReal()
    {
        // La ventaja de depender del contrato: esta prueba no conoce ni le
        // importa la lógica de descuentos real. Si mañana CalculadoraPrecioEstandar
        // cambia sus reglas, esta prueba ni se entera.
        var procesador = new ProcesadorDeReserva(new CalculadoraPrecioFalsa());
        var solicitud = new SolicitudDeReserva();   // no importa qué traiga -- el doble la ignora

        var total = procesador.CalcularTotal(solicitud);

        Assert.Equal(100000m, total);
    }

    [Fact]
    public void ProcesadorDeReservaAcoplado_SoloSePuedeProbarConLaLogicaReal()
    {
        // Aquí no hay forma de meter un doble: el procesador crea su propia
        // calculadora adentro. Esta prueba SÍ depende de la lógica real de
        // CalculadoraPrecioEstandar -- exactamente lo que un contrato evita.
        var procesador = new ProcesadorDeReservaAcoplado();
        var solicitud = new SolicitudDeReserva { TipoCliente = "REGULAR", TarifaHora = 10000m, Horas = 2 };

        var total = procesador.CalcularTotal(solicitud);

        Assert.Equal(20000m, total);
    }
}
