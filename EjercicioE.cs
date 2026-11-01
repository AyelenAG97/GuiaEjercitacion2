using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2
{
    internal class EjercicioE
    { /*
       * E1. Escenario (2 pts)
        Una app de delivery calcula el costo del envío de forma distinta si va en moto, en bicicleta o en auto. El usuario elige el vehículo al confirmar el pedido, y el mes que viene se suma el envío con dron.
        Patrón y por qué: El patron a implementar es Strategy porque hay varias formas de hacer lo mismo (un envio) y el cliente eligirá cual a través de un switch o if. El nuevo tipo de envio (dron) se agregara una nueva clase.
        E2. Escenario (2 pts)
        Cuando un pedido de un restaurante pasa a "listo", tienen que enterarse la pantalla de la cocina, la tablet del mozo y la caja. El dueño ya avisó que más adelante quiere sumar un aviso por WhatsApp al cliente.
        Patrón y por qué: Aplicaria el patrón Observer, porque dben notificarse varias pantallas a la vez cuando el pedido a pasa a listo. Se le avisa a una lista de suscriptores sin saber quiénes son. Y cuando suma el aviso por WhatsApp, no hay que modificar el código de la clase que notifica, sino agregar una nueva clase que implemente la interfaz suscriptora.
        E3. Escenario (2 pts)
        Todas las pantallas del sistema leen la moneda, el nombre de la sucursal y la carpeta de datos. Hoy cada formulario crea su propio objeto de configuración y, si se cambia la sucursal en una pantalla, las otras siguen mostrando la anterior.
        Patrón y por qué: El patrón a aplicar es Singleton, ya que el problema plantea que cada formulario crea su objeto. Al aplicar este patron habrá un solo objeto y todas las pantallas mostraran la misma sucursal
        E4. Escenario (2 pts)
        El sistema lee un archivo JSON donde cada pago guardado tiene su medio como texto: "TARJETA", "EFECTIVO" o "QR". Al cargar el archivo hay que reconstruir, para cada pago, el objeto que sabe calcular su recargo.
        Patrón y por qué: El patrón a aplicar es Factory, ya que el medio de pago llega como texto desde un JSON. Y se deberá crear el objecto correcto en varios lugares, centralizando en uno solo su creación. 
        E5. Escenario (2 pts) 
        En Program.cs se crea un único JsonRepository<Cliente> al iniciar y se le pasa por constructor al ClienteController. Nunca cambia durante la ejecución. Un compañero propone agregarle una factory "para que quede más profesional".
        Patrón y por qué: No es necesario aplicar ningún patrón, no hay ninguna decisión que tomar en ejecución, que es lo que justifica una factory.
       */

    }
}
