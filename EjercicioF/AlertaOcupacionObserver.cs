namespace GuiaEjercitacion2.EjercicioF
{
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        public const int Umbral = 2;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres <= Umbral)
                Console.WriteLine($"[Alerta] ¡Quedan {evento.LugaresLibres} lugares!");
        }
    }

}
