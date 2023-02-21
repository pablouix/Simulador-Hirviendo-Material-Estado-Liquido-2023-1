using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirviendoLiquido.bll
{
    public class calculosSimulacion
    {
        // Definimos la temperatura inicial del agua
        private float temperaturaInicial = 20;

        // Definimos la temperatura deseada del agua
        private float temperaturaDeseada = 70;

        double diametroManguera = 0.01; // Diámetro del tubo en metros
        double longitudManguera = 1.0; // Longitud del tubo en metros

        // Definimos la potencia de la estufa en vatios
        // Cambiar esto por el tanque de gas.
        private float potenciaEstufa = 1000;

        // Definimos la capacidad del recipiente en litros
        private float capacidadRecipiente = 10;

        // Definimos la eficiencia de la estufa
        private float eficienciaEstufa = 0.2f;

        // Definimos la constante de calor específico del agua
        private float calorEspecifico = 4.186f; // 2.000f en caso del aceite

        // Definimos la variable de tiempo en segundos
        private float tiempo = 0;

        // Definimos el tiempo de actualización de la temperatura en segundos
        private float tiempoActualizacion = 1;

        public void CapacidadTubo()
        {
            while (temperaturaInicial < temperaturaDeseada)
            {
                // Actualizamos la temperatura del agua
                temperaturaInicial += TemperaturaIncrementada();

                // Aumentamos el tiempo
                tiempo += tiempoActualizacion;

                // Mostramos la temperatura del agua y el tiempo transcurrido
                /*Tiempo [tiempo] segundos
                Temperatura del agua [temperaturaInicial] grados Celsius*/
            }
        }
        
        // Calculamos la cantidad de calor necesaria para calentar el agua
        public float CalorNecesario() {
            return (temperaturaDeseada - temperaturaInicial) * capacidadRecipiente * calorEspecifico;
        }

        // Calculamos la potencia efectiva de la estufa
        public float PotenciaEfectiva() {
            return potenciaEstufa * eficienciaEstufa;
        }
        
        // Calculamos la cantidad de calor generada por la estufa en un segundo
        public float CalorGenerado() {
            return PotenciaEfectiva() * tiempoActualizacion;
        }

        // Calculamos la temperatura incrementada por segundo
        public float TemperaturaIncrementada() {
            return CalorGenerado() / (capacidadRecipiente * calorEspecifico);
        }

        public double AreaManguera() {
            return Math.PI * diametroManguera * diametroManguera / 4.0; // Área transversal del tubo en metros cuadrados
        }

        public void PresionTanque() {
            
        }

        public void Resultado() {
            
        }
    }
}