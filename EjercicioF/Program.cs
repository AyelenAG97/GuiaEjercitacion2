using System;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace GuiaEjercitacion2.EjercicioF
{
    /*
    Singleton: Utilice este patrón para la bitacora del programa ya que evita que cada clase haga su propia bitacora (new) y quede el historial repartido en varios listas.
    Con este patron queda todo en una sola bitacora y al tener un contructor privado, nadie puede hacer new
    
    Strategy: Utilice este patrón para ITarifa, TarifaHora, TarifaEstadia y TarifaNocturna. Ya que hay tres formas distintas de cobrar lo mismo segun su tarifa. 
    Sin este patrón, Egresar estaría dentro de un switch o if y en caso de querer sumar una nueva tarifa, se tendría que abirir y modificar Playa también. Rompiendo con el princio Open/Close
    
    Factory: Utilice este patrón de diseño en TarifaFactory porque el problema a resolver es que recibia la tarifa como texto (hora,estadia y noche) y en tiempo de ejecución se lo debe convertir a un objeto. 
    Además es el único con un new de las tarifas, si no se aplicaría factory este switch debería quedar dentro de Playa y en caso de error puede resultar en un null o cobro equivocado, sin aviso (sin un ArgumentException)
    
    Observer:Lo utilice para Playa, IPlayaObserver y suscriptores. El problema que tenía el programa es que debía avisar en distintos lugares a la vez lo mismo, (pantalla, caja,alerta y bitacora). Así IPlayaObserver avisa a cada uno de sus suscriptores y estos resuelven que deben hacer.
    Sin este patrón, Egresar e Ingresar debería llamar a cada uno a mano y para sumar un aviso nuevo se tendría que modificar Playa. Con este patrón se respeta el principio de Open/Close.
   
    */

    public static class Demo
    {
        public static void Ejecutar()
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-AR");

            // El cliente arma el sistema y decide quién escucha.
            var playa = new Playa(10);
            var pantalla = new PantallaLugares();
            playa.Suscribir(pantalla);
            playa.Suscribir(new CajaObserver());
            playa.Suscribir(new AlertaOcupacionObserver());
            playa.Suscribir(new BitacoraObserver());


            playa.Ingresar("AB123CD", "HORA");
            playa.Ingresar("AC456EF", "ESTADIA");
            playa.Ingresar("AD789GH", "NOCHE");
            playa.Ingresar("AE111AA", "HORA");
            playa.Ingresar("AF222BB", "ESTADIA");
            playa.Ingresar("AG333CC", "NOCHE");
            playa.Ingresar("AH444DD", "HORA");
            playa.Ingresar("AJ555EE", "HORA");          

            playa.Egresar("AB123CD", 150);
            playa.Egresar("AC456EF", 900);
            playa.Desuscribir(pantalla);
            playa.Egresar("AD789GH", 600);

            try
            {
                playa.Ingresar("AZ999ZZ", "SEMANAL");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Bitacora.Instancia.MostrarTodo();
        }
    }

}
