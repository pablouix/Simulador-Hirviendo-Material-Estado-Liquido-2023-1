using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionEstufa.Entidad
{
    public class Estufa
    {
        // Temperatura deseada, el punto de ebullicion
        public double temperaturaDeseada { get; set; }
        // Temperatura inicial, temperatura ambiente
        public double temperaturaInicial { get; set; } = 20.0;
        // Capacidad del recipiente en litros
        public double capacidadRecipiente { get; set; }
        // Constante de calor específico del liquido
        public double calorEspecifico { get; set; }

        // Diámetro del tubo en metros
        public double diametroManguera { get; set; }
        // Longitud del tubo en metros
        public double longitudManguera { get; set; }

        // Capacidad de la estufa en vatios
        public double potenciaEstufa = 200.0;
        // Que tan fuerte esta la ornilla de la estufa
        public double eficienciaEstufa { get; set; }

        // Que tan abierta esta la valvula del tanque
        public double eficienciaTanque { get; set; }
        // Presión del gas en el tanque en psi
        public double presionTanque { get; set; }
        public double densidadGas = 1.52;
        public double volumenGasTanque = 100.0;
    }
}
