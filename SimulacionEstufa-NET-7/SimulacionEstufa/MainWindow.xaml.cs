using SimulacionEstufa.BLL;
using SimulacionEstufa.Entidad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimulacionEstufa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int posisicionOrnilla = 0;
        private int posisicionAperturaTanque = 0;

        Estufa estufa = new Estufa();
        CalculoSimulacion simulacion;

        float[] eficiencia = { 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
        DispatcherTimer timer;
        Stopwatch stopWatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = this.Width;
            this.MaxHeight = this.Height;
        }

        private void BtnIniciarSimulacion(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DiametroTuberiaBox.Text) || string.IsNullOrEmpty(LogintudTuberiaBox.Text) || string.IsNullOrEmpty(PresionDelTanqueBox.Text) || string.IsNullOrEmpty(CantidadMaterialBox.Text))
                MessageBox.Show("Por favor, rellena todos los campos.", "Error");
            else if (posisicionAperturaTanque == 0 || posisicionOrnilla == 0)
                MessageBox.Show("La estufa esta apagada.", "Error");
            else if (MaterialTxt.Text == "Material")
                MessageBox.Show("El recipiente esta vacio", "Error");
            else
            {
                estufa.diametroManguera = Convert.ToDouble(DiametroTuberiaBox.Text);
                estufa.longitudManguera = Convert.ToDouble(LogintudTuberiaBox.Text);
                estufa.presionTanque = Convert.ToDouble(PresionDelTanqueBox.Text);
                estufa.eficienciaTanque = eficiencia[posisicionAperturaTanque];
                estufa.capacidadRecipiente = Convert.ToDouble(CantidadMaterialBox.Text);
                estufa.eficienciaEstufa = eficiencia[posisicionOrnilla];

                simulacion = new CalculoSimulacion(estufa);
                EmpezarSimulacion();
            }
        }

        public void EmpezarSimulacion()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Tickevent;
            stopWatch.Start();
            timer.Start();
        }

        public void Tickevent(object sender, EventArgs e)
        {
            ResultadosBox.Text = "Resultado:\n";
            ResultadosBox.Text += $"Tiempo: {stopWatch.Elapsed.ToString(@"hh\:mm\:ss")}\n";
            ResultadosBox.Text += $"Temperatura: {simulacion.GetTemperatura().ToString("N2")}\n";
            ResultadosBox.Text += $"Calor necesario: {simulacion.CalorNecesario().ToString("N2")}\n";

            if (simulacion.estufa.temperaturaInicial > simulacion.estufa.temperaturaDeseada)
                timer.Stop();
        }

        private void BtnAgua(object sender, RoutedEventArgs e)
        {
            ollaImagen.Source = new BitmapImage(new Uri("/Img/recipientes/ollaAgua.png", UriKind.Relative));
            MaterialTxt.Text = "Agua";
            estufa.calorEspecifico = 4186.0;
            estufa.temperaturaDeseada = 100.0;
        }

        private void BtnAceite(object sender, RoutedEventArgs e)
        {
            ollaImagen.Source = new BitmapImage(new Uri("/Img/recipientes/ollaAceite.png", UriKind.Relative));
            MaterialTxt.Text = "Aceite";
            estufa.calorEspecifico = 2000.0;
            estufa.temperaturaDeseada = 180.0;
        }

        private void btnControlOrnillaUp(object sender, RoutedEventArgs e)
        {
            if (posisicionOrnilla < 5)
                posisicionOrnilla++;
            ControlOrnillaTXT.Text = posisicionOrnilla.ToString();
            ControlImagen.Source = ImagenControlOrnilla(posisicionOrnilla);
            ornillaImagen.Source = ImagenOrnilla(posisicionOrnilla);

            if (posisicionAperturaTanque == 0)
            {
                ornillaImagen.Source = ImagenOrnilla(0);
            }
        }

        private void btnControlOrnillaDown(object sender, RoutedEventArgs e)
        {
            if (posisicionOrnilla > 0)
                posisicionOrnilla--;
            ControlOrnillaTXT.Text = posisicionOrnilla.ToString();
            ControlImagen.Source = ImagenControlOrnilla(posisicionOrnilla);
            ornillaImagen.Source = ImagenOrnilla(posisicionOrnilla);

            if (posisicionAperturaTanque == 0)
            {
                ornillaImagen.Source = ImagenOrnilla(0);
            }
        }

        private static BitmapImage ImagenControlOrnilla(int posicion)
        {
            return new BitmapImage(new Uri("/Img/perillas/controlPosicion" + Convert.ToString(posicion) + ".png", UriKind.Relative));
        }

        private static BitmapImage ImagenOrnilla(int posicion)
        {
            return new BitmapImage(new Uri("/Img/ornillas/ornilla" + Convert.ToString(posicion) + ".png", UriKind.Relative));
        }

        private void btnAperturaTanqueDerecho(object sender, RoutedEventArgs e)
        {
            if (posisicionAperturaTanque < 5)
                posisicionAperturaTanque++;

            ornillaImagen.Source = ImagenOrnilla(posisicionOrnilla);
            ControlAperturaTanqueTXT.Text = posisicionAperturaTanque.ToString();
        }

        private void btnAperturaTanqueIzquierdo(object sender, RoutedEventArgs e)
        {
            if (posisicionAperturaTanque > 0)
                posisicionAperturaTanque--;

            if (posisicionAperturaTanque == 0)
                ornillaImagen.Source = ImagenOrnilla(0);

            ControlAperturaTanqueTXT.Text = posisicionAperturaTanque.ToString();
        }
    }
}
