using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public interface ITarifa
    {
        string Nombre { get; }
        decimal Calcular(int minutos);
    }
}
