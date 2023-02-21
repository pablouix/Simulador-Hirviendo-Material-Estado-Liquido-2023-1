using SimulacionEstufa.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionEstufa.BLL
{
    public class CalculoSimulacion
    {
        // Definimos el tiempo de actualización de la temperatura en segundos
        private int tiempoActualizacion = 1;

        public Estufa estufa;

        public CalculoSimulacion(Estufa estufa)
        {
            this.estufa = estufa;
        }

        public double GetTemperatura()
        {
            return estufa.temperaturaInicial += TemperaturaIncrementada();
        }

        // Calculamos la cantidad de calor necesaria para calentar el agua
        public double CalorNecesario()
        {
            return (estufa.temperaturaDeseada - estufa.temperaturaInicial) * estufa.capacidadRecipiente * estufa.calorEspecifico;
        }

        // Tiempo necesario para calentar el agua en segundos
        private double TiempoGas()
        {
            return CalorNecesario() / estufa.calorEspecifico;
        }

        // Cantidad de gas necesario en kg
        private double gasNecesario()
        {
            return estufa.presionTanque * estufa.volumenGasTanque * estufa.densidadGas;
        }

        // Flujo de gas necesario en kg/s
        private double VolumenGas()
        {
            return (gasNecesario() / TiempoGas()) * estufa.eficienciaTanque;
        }

        // Velocidad del gas en el tubo en m/s
        public double VelocidadGas()
        {
            return VolumenGas() / VolumenManguera();
        }

        // Calculamos la potencia efectiva de la estufa
        private double PotenciaEfectiva()
        {
            return VelocidadGas() * estufa.eficienciaEstufa;
        }

        // Calculamos la cantidad de calor generada por la estufa en un segundo
        private double CalorGenerado()
        {
            return PotenciaEfectiva() * tiempoActualizacion;
        }

        // Calculamos la temperatura incrementada por segundo
        private double TemperaturaIncrementada()
        {
            return CalorGenerado() / (estufa.capacidadRecipiente * estufa.calorEspecifico);
        }

        // Calculamos el volumen de la manguera conectada al tanque
        private double VolumenManguera()
        {
            /*Área transversal del tubo en metros cuadrados multiplicada por la longitud
                resultando en su volumen en metros cubicos*/
            return estufa.longitudManguera * (Math.PI * (estufa.diametroManguera * estufa.diametroManguera) / 4.0);
        }

        public void Resultado()
        {
        }
    }
}
