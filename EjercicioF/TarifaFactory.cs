using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public static class TarifaFactory
    {
        public static ITarifa Crear(string codigo)
        {
            switch (codigo)
            {
                case "HORA": return new TarifaHora();
                case "ESTADIA": return new TarifaEstadia();
                case "NOCHE": return new TarifaNocturna();
                default: throw new ArgumentException($"Código de tarifa desconocido: {codigo}");
            }
        }

        public static List<string> CodigosDisponibles()
         => new List<string> { "HORA", "ESTADIA", "NOCHE" };
    }

}
