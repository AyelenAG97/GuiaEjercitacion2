using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class CajaObserver : IPlayaObserver
    {
        private decimal _recaudado = 0m;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo != TipoEventoPlaya.Egreso)
                return;

            _recaudado += evento.Importe;
            Console.WriteLine($"[Caja] Cobrado {evento.Importe:C0} a {evento.Patente}. Recaudado: {_recaudado:C0}");
        }
    }

}
