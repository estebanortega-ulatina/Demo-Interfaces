# Práctica — El contrato de la calculadora de precio

Esto no tiene nota. Es para reforzar lo que empezamos a construir en vivo en
la sesión 3: el mismo `ICalculadoraDePrecio` que se escribió en la
diapositiva del momento en vivo, ahora completo y con pruebas. Sigue el
mismo flujo que ya practicaste con el ejemplo de Liskov -- ábrelo, corre las
pruebas, y esta vez también practica el debug.

## Qué contiene esta carpeta

- `src/ICalculadoraDePrecio.cs` -- el contrato: recibe una `SolicitudDeReserva`,
  devuelve un `DesglosePrecio`.
- `src/CalculadoraPrecioEstandar.cs` -- la implementación real, con el mismo
  descuento del 12% para clientes corporativos que viste en `GestorReservas.cs`.
- `src/CalculadoraPrecioFalsa.cs` -- un doble de prueba: cumple el contrato
  pero siempre devuelve el mismo resultado fijo, sin calcular nada.
- `src/ProcesadorDeReserva.cs` -- recibe el contrato por constructor (buen
  diseño).
- `src/ProcesadorDeReservaAcoplado.cs` -- crea su propia calculadora adentro,
  en vez de recibirla (mal diseño, solo para comparar).
- `pruebas/ContratosTests.cs` -- tres pruebas.

## Parte A -- Correr las pruebas

```
cd Demo-Interfaces/pruebas
dotnet test
```

Las tres deberían pasar en verde.

## Parte B -- Practica el debug

1. Abre `pruebas/ContratosTests.cs` en VS Code.
2. Pon un punto de interrupción (clic a la izquierda del número de línea) en
   la línea `var total = procesador.CalcularTotal(solicitud);` de
   `ProcesadorDeReserva_SePruebaConUnDoble_SinTocarLaCalculadoraReal`.
3. Abre el panel de **Testing** (el ícono del frasco de laboratorio) y haz
   clic en el ícono de depurar (▷ con un bicho) junto a esa prueba, no en
   "Run".
4. Cuando pare en el punto de interrupción, entra paso a paso (`F11`) dentro
   de `CalcularTotal` -- vas a caer en `CalculadoraPrecioFalsa.Calcular`, no
   en la lógica real. Esa es la prueba visual de que el doble está
   sustituyendo a la calculadora real.
5. Repite lo mismo con `ProcesadorDeReservaAcoplado_SoloSePuedeProbarConLaLogicaReal`
   -- esta vez vas a caer dentro de `CalculadoraPrecioEstandar`, con toda su
   lógica de descuento. No hay forma de evitarlo: el procesador la crea él
   mismo.

## La idea que te tienes que llevar

`ProcesadorDeReserva` (el que recibe el contrato) se puede probar sin tocar
la calculadora real -- si mañana le cambian las reglas de descuento, esa
prueba ni se entera. `ProcesadorDeReservaAcoplado` no tiene esa opción:
está pegado a una implementación concreta, así que probarlo es probar
también esa implementación. Esa es la ventaja de programar contra una
interfaz en vez de instanciar la clase directamente.
