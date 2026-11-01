namespace GuiaEjercitacion2.EjercicioF
{
        public class PantallaLugares : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            Console.WriteLine($" [Pantalla] Lugares libres : {evento.LugaresLibres}");
        }
    }
}
