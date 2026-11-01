using System;
using System.Collections.Generic;
using System.Linq;


namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }
    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);

        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");
          
            foreach (var o in _observadores.ToList())   // Corregido
                o.Actualizar(this);
        }
    }
    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }
    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var alarma = new Alarma();
            alarma.Suscribir(new AvisoUnico());
            alarma.Suscribir(new Luz());
            alarma.Sonar();
        }
    }

    /*
     *¿Cuál es el error y de qué tipo es?: El error se da en la ejecución, es una excepción de tipo InvalidOperationException
     ¿Por qué ocurre?: Desuscribir modifica la lista con Remove en medio del foreach y por ello nunca llega al aviso de a clase luz
     ¿Cómo se corrige?: Se recorre una copia de la lista con .ToList(). Entonces el foreach recorre la copia, y Desuscribir modifica la lista original sin afectar el recorrido
     */
}

namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }

    public class TarifaMoto : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 1500m + pesoKg * 100m;
    }

    public class TarifaCamion : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 8000m + pesoKg * 40m;
    }

    public class TarifaComun : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 3000m + pesoKg * 70m;
    }

    public class CalculadoraEnvio
    {
        private readonly IEnvioStrategy _tarifa;
        public CalculadoraEnvio(IEnvioStrategy tarifa) => _tarifa = tarifa;
        public decimal Costo(decimal pesoKg) => _tarifa.Calcular(pesoKg);
    }


    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine($"Moto 5 kg: {new CalculadoraEnvio(new TarifaMoto()).Costo(5):0}");
            Console.WriteLine($"Camión 5 kg: {new CalculadoraEnvio(new TarifaCamion()).Costo(5):0}");
            Console.WriteLine($"Común 5 kg: {new CalculadoraEnvio(new TarifaComun()).Costo(5):0}");
        }
    }

    /*¿Cuál es el error y de qué tipo es?: El error es que no aplica las estrategias del patrón Strategy y utiliza un condicional (if) enlugar de hacerlo cada una con su clase. Es un error de diseño
    ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?: Se modifica la clase EnvioStrategy sumandole un nuevo condicional, (if (_tipo == "Bicicleta")). Rompe el principio Open/Closed .
    ¿Cómo se corrige? (escribí las clases): Se crea una clase por cada estrategia de envío que implemente la interfaz IEnvioStrategy.
    */
}

namespace EjercicioC3
{
    
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }
    public class NotificadorMail : INotificador 
    {
        public void Enviar(string destino, string mensaje)
            => Console.WriteLine($"[MAIL a {destino}] {mensaje}");
    }
    public class NotificadorSms : INotificador 
    {
        public void Enviar(string destino, string mensaje)
            => Console.WriteLine($"[SMS a {destino}] {mensaje}");
    }
    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL") return new NotificadorMail();
            if (canal == "SMS") return new NotificadorSms();
            throw new ArgumentException ($"Canal desconocido: {canal}");  
        } 
    }
    

    /*¿Cuál es el error y de qué tipo es?: Es un error de compilación, porque al final del método Crear no hay un return, asi que si no es un Mail o un SMS no devuelve nada.
    ¿Cómo se corrige?: Se corrige agrengando una excepción, throw new ArgumentException(...), al final del método.
    ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?: Conviene lanzar un excepción porque el error así es más facil de detectar donde está el error. Si se devuelve un null, el error puede persistir y será más dificil de detectarse
    */
}
