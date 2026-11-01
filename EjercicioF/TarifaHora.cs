using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaHora : ITarifa
    
    {
        public const decimal PrecioPorHora = 1200m;
        public string Nombre => "POr hora";

        public decimal Calcular(int minutos)
        {
            decimal horas = (decimal)Math.Ceiling(minutos / 60.0);
            return horas * PrecioPorHora;

        }
    }

}
