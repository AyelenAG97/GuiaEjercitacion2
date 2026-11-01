using System;
using System.Collections.Generic;
using System.Linq;


namespace EjercicioB1
{
    public class Contador
    {
        private static Contador _instancia;
        private int _valor = 0;
        private Contador() { Console.WriteLine("Creando contador"); }
        public static Contador Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Contador();
                return _instancia;
            }
        }
        public int Siguiente()
        {
            _valor++;
            return _valor;
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var a = Contador.Instancia;
            var b = Contador.Instancia;
            Console.WriteLine(a.Siguiente());
            Console.WriteLine(b.Siguiente());
            Console.WriteLine(Contador.Instancia.Siguiente());
            Console.WriteLine(ReferenceEquals(a, b));
        }
    }

    /*
     ¿Qué imprime?:Imprime la suma de de instancia y contador , es decir 1,2,3 y true.
    ¿Cuántas veces aparece "Creando contador" y por qué?: Aparece una sola vez, porque implenta Singleton.
    ¿Por qué b.Siguiente() no devuelve 1?: Porque B es la misma instancia que A y el valor se incrementa con cada llamada a Siguiente()
     */
}

namespace EjercicioB2
{
    public interface IPropina
    {
        string Nombre { get; }
        decimal Calcular(decimal total);
    }
    public class SinPropina : IPropina
    {
        public string Nombre => "Sin propina";
        public decimal Calcular(decimal total) => 0;
    }
    public class Propina10 : IPropina
    {
        public string Nombre => "10%";
        public decimal Calcular(decimal total) => total * 0.10m;
    }
    public class PropinaFija : IPropina
    {
        private readonly decimal _monto;
        public PropinaFija(decimal monto) => _monto = monto;
        public string Nombre => "Fija";
        public decimal Calcular(decimal total) => _monto;
    }

    public class Cuenta
    {
        private IPropina _propina;
        public Cuenta(IPropina propina) => _propina = propina;
        public void CambiarPropina(IPropina propina) => _propina = propina;
        public void Mostrar(decimal total)
        {
            decimal final = total + _propina.Calcular(total);
            Console.WriteLine($"{_propina.Nombre}: {final:0}");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var cuenta = new Cuenta(new SinPropina());
            cuenta.Mostrar(20000);
            cuenta.CambiarPropina(new Propina10());
            cuenta.Mostrar(20000);
            cuenta.CambiarPropina(new PropinaFija(1500));
            cuenta.Mostrar(20000);
        }
    }

    /*
     ¿Qué imprime?: Imprime el total de la cuenta primero sin propina, luego con una propina del % y por último con la propina fija de 1500.
    En este código, ¿quién es el contexto y quiénes son las estrategias?: El contexto será la calse Cuenta y sis estrategias son las tres formas de calcular el precio de la cuenta (sin propina, con propina del 10% y  propina fija).
    ¿Qué hubo que modificar de Cuenta para poder usar PropinaFija? ¿Qué principio se cumple?: No se modifico nada en Cuenta.Esto cumple con el principio Open/Close porque agrego una nueva clase sin modificar el codigo.
     */
}

namespace EjercicioB3
{
    public interface IObservador
    {
        void Actualizar(string video);
    }
    public class Canal
    {
        private readonly List<IObservador> _suscriptores = new List<IObservador>();
        public void Suscribir(IObservador o) => _suscriptores.Add(o);
        public void Desuscribir(IObservador o) => _suscriptores.Remove(o);
        public void Publicar(string video)
        {
            Console.WriteLine($"Nuevo video: {video}");
            foreach (var s in _suscriptores.ToList())
                s.Actualizar(video);
        }
    }
    public class Fan : IObservador
    {
        private readonly string _nombre;
        public Fan(string nombre) => _nombre = nombre;
        public void Actualizar(string video) => Console.WriteLine($" {_nombre} mira {video}");
    }
    public class Estadisticas : IObservador
    {
        private int _avisos = 0;
        public void Actualizar(string video)
        {
            _avisos++;
            Console.WriteLine($" Avisos registrados: {_avisos}");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var canal = new Canal();
            var lu = new Fan("Lu");
            canal.Suscribir(lu);
            canal.Suscribir(new Fan("Tomi"));
            canal.Suscribir(new Estadisticas());
            canal.Publicar("Patrones en C#");
            canal.Desuscribir(lu);
            canal.Publicar("Observer en WinForms");
        }
    }

    /*
      ¿Qué imprime?:Imprimira en la primera publicación el nuevo video y las estadisticas de los avisos, con Lu y Tomi. En la segunda publicación imprime solo a Tomi, con la estadistica de los avisos, porque Lu se desuscribio del canal.
        ¿Por qué Lu no aparece en la segunda publicación?: Lu no aparece porque se desuscribio del canal y Publicar solo le avisa a sus suscriptores
        ¿Canal conoce la clase Fan? ¿Cómo te das cuenta mirando el código?: No la conoce. Me doy cuenta porque la clase Canal solo conoce la interfaz de IObservador.
     */
}
