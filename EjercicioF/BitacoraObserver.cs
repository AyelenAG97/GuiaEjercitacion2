using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class BitacoraObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento) 
        {
            if (evento.Tipo == TipoEventoPlaya.Ingreso)
                Bitacora.Instancia.Registrar($"Ingreso {evento.Patente}");
            else
                Bitacora.Instancia.Registrar($"Egresó {evento.Patente}-{evento.Importe:C0}");
        }
 
    }
}
