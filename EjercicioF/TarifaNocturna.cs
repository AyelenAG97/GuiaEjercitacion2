using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaNocturna : ITarifa
    {
        public const decimal PrecioFijo = 4500m;
        public string Nombre => "Nocturna";
        public decimal Calcular(int minutos) => PrecioFijo; 
    }

}
