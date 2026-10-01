# Ejercicio de seguimiento — desacoplar de dónde sale la solicitud

Esto no tiene nota. Es el siguiente paso después de la demo de interfaces, sobre
el mismo proyecto (`Contratos`).

## El problema

Ahora mismo, en todo el proyecto, la única forma de obtener un
`SolicitudDeReserva` es construirlo a mano:

```csharp
var solicitud = new SolicitudDeReserva { TipoCliente = "CORPORATIVO", TarifaHora = 10000m, Horas = 4 };
```

Eso funciona en las pruebas porque los datos ya están ahí. Pero en un programa
real nadie "ya tiene los datos": alguien tiene que pedirlos — por consola, un
formulario, un archivo. Si ese "alguien" queda escrito directamente adentro
del código que hace el cálculo, pasa lo mismo que ya vieron con
`ProcesadorDeReservaAcoplado`: funciona, pero no se puede probar sin ese
origen real, ni cambiarlo sin tocar todo lo que lo usa.

## Lo que tienen que construir

**1. Una interfaz propia**, en un archivo nuevo dentro de `src/`. Ustedes
eligen el nombre (debe empezar con `I` y decir qué hace, no cómo — por
ejemplo algo como `IProveedorDeSolicitud`, pero puede ser otro). Un solo
método, que no reciba nada y devuelva un `SolicitudDeReserva`.

Arriba de la interfaz, como comentario, respondan las cuatro preguntas de
siempre:

```
// ¿Qué recibe?
// ¿Qué devuelve?
// ¿Qué garantiza?
// ¿Qué promete NO hacer?
```

**2. Dos implementaciones:**

- Una real: pide los cinco datos por consola (`Console.ReadLine`) y arma el
  `SolicitudDeReserva` con lo que el usuario escribió.
- Una falsa (doble de prueba): devuelve siempre el mismo `SolicitudDeReserva`
  fijo, sin tocar la consola — sigan el patrón de `CalculadoraPrecioFalsa.cs`.

**3. Un consumidor que use el contrato por constructor.** La forma más
simple: agregar su interfaz como segundo parámetro al constructor de
`ProcesadorDeReserva` (además de `ICalculadoraDePrecio`), de modo que pida la
solicitud a través de ella en vez de recibirla como parámetro de
`CalcularTotal`. Si prefieren no tocar la clase que ya existe, pueden crear
una nueva en su lugar.

**4. Al menos una prueba nueva**, en `pruebas/EjercicioTests.cs`, que use la
implementación falsa — tiene que poder correr sola, sin que nadie teclee
nada.

## Cómo saber si está bien

```
cd pruebas
dotnet test
```

Todas las pruebas deben pasar: las que ya estaban (`ContratosTests.cs`) y la
nueva. Si alguna de las viejas deja de pasar, algo se rompió al extender el
proyecto — revisen antes de seguir.

## La pregunta que se tienen que poder responder

¿Por qué esta prueba nueva puede correr sola, sin que nadie esté sentado
tecleando en la consola?
