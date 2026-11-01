using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaEstadia : ITarifa
    {
        public const decimal PrecioFijo = 6000m;
        public const int MinutosIncluidos = 12 * 60;
        public const decimal PrecioHoraExtra = 1200m;
        public string Nombre => "Estadia";

        public decimal Calcular (int minutos )
        {
            if (minutos <= MinutosIncluidos)
                return PrecioFijo;

            decimal horaExtra = (decimal)Math.Ceiling((minutos - MinutosIncluidos) / 60.0);
            return PrecioFijo + horaExtra * PrecioHoraExtra;        }
    }

 }
