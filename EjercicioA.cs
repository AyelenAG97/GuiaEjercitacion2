using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2
{
    internal class EjercicioA
    {
        /*A1. Las tres reglas del Singleton (2 pts)
       ¿Cuál de las tres reglas es la que impide que otra clase escriba new AppLogger()?
       c) El constructor private AppLogger() { }.
       //Descarte las otras opciones porque el campo estático o el punto de acceso publico no impide que otra clase haga new.
       
       A2.Lazy initialization(2 pts)
       En la propiedad Instancia del Singleton, ¿qué significa que la inicialización sea "lazy" (perezosa)?
       a) La instancia se crea la primera vez que alguien la pide, no antes.
       
       A3.Qué resuelve Strategy (2 pts)
       ¿Cuál es el problema principal que resuelve el patrón Strategy?
       d) Reemplazar un condicional que elige entre variantes de un algoritmo por clases intercambiables detrás de una interfaz.
       
       A4.El contexto en Strategy(2 pts)
       En Strategy, ¿qué hace el "contexto" (por ejemplo, Cuenta o CalculadoraPrecio)?
       b) Usa una estrategia a través de la interfaz y le delega el cálculo, sin saber cuál es.
      
       A5.Cuándo se justifica una factory(2 pts)
       ¿En cuál de estos casos SÍ se justifica una factory?
       c) El medio de pago llega como texto("QR", "EFECTIVO") desde un ComboBox y desde un JSON, y hay que crear el objeto correcto en varios lugares.
       //Descarte la opción A) porque no hay un if o switch que elija entre varias clases, sino que siempre se crea la misma clase. 
       
        A6.Simple Factory vs Factory Method (2 pts)
       ¿Qué distingue al Factory Method del GoF de una Simple Factory?
       a) En Factory Method, una superclase con lógica de negocio declara el método de creación y cada subclase decide qué producto concreto crear.

       A7. Qué guarda el notificador (2 pts)
       En Observer, ¿qué guarda el notificador?
       b) Una lista de referencias a objetos que implementan la interfaz suscriptora.
      
       A8. El suscriptor olvidado (2 pts)
       Un FormTablero se suscribe al controller al abrirse, pero NO se desuscribe al cerrarse. ¿Qué pasa en la siguiente notificación?
       d) El controller le sigue avisando a un formulario destruido: puede saltar una excepción y el objeto nunca se libera de memoria.
       
       A9. Observer en WinForms (2 pts)
       En la línea btnGuardar.Click += btnGuardar_Click; ¿qué rol del patrón Observer cumple btnGuardar_Click?
       b) Suscriptor.
       
       A10. Open/Closed en la práctica (2 pts)
       Con Observer bien aplicado, gerencia pide un aviso nuevo cada vez que se cancela un envío. ¿Qué hacés?
       c) Creás una clase que implementa la interfaz suscriptora y la suscribís en Program.cs.
      // Elimine la opción A) porque el controller quedaría acoplado al aviso y cada pedido nuevo obligaría a reabrirlo. rompiedo Open/Closed


         */

    }
}
