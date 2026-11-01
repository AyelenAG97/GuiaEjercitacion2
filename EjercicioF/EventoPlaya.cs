namespace GuiaEjercitacion2.EjercicioF
{
    //Contexto de la notificación
    public class EventoPlaya
    {
        public TipoEventoPlaya Tipo { get; }
        public string Patente { get; }
        public decimal Importe { get; }        
        public int LugaresLibres { get; }

        public EventoPlaya(TipoEventoPlaya tipo, string patente, decimal importe, int lugaresLibres)
        {
            Tipo = tipo; 
            Patente = patente; 
            Importe = importe; 
            LugaresLibres = lugaresLibres;
        }
    }

}
