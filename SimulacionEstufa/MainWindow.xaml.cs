using System;
using System.Collections.Generic;
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

namespace SimulacionEstufa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int posisicionOrnilla = 0;
        public int posisicionAperturaTanque = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = this.Width;
            this.MaxHeight = this.Height;
        }

        private void BtnIniciarSimulacion(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DiametroTuberiaBox.Text) || string.IsNullOrEmpty(LogintudTuberiaBox.Text) || string.IsNullOrEmpty(PresionDelTanqueBox.Text) || string.IsNullOrEmpty(CantidadMaterialBox.Text) || string.IsNullOrEmpty(ResultadosBox.Text))
            {
                MessageBox.Show("Por favor, rellena todos los campos.", "Error");
            }
            else if (posisicionAperturaTanque == 0 || posisicionOrnilla == 0)
            {
                MessageBox.Show("La estufa esta apagada.", "Error");
            }
            else
            {
                DiametroTuberiaBox.Text = "";
                LogintudTuberiaBox.Text = "";
                PresionDelTanqueBox.Text = "";
                CantidadMaterialBox.Text = "";
                ResultadosBox.Text = "";
            }
          
        }


        private void BtnAgua(object sender, RoutedEventArgs e)
        {
            ollaImagen.Source = new BitmapImage(new Uri("/Img/ollaAgua.png", UriKind.Relative));
            MaterialTxt.Text = "Agua";
        }
        private void BtnAceite(object sender, RoutedEventArgs e)
        {
            ollaImagen.Source = new BitmapImage(new Uri("/Img/ollaAceite.png", UriKind.Relative));
            MaterialTxt.Text = "Aceite";
        }

        private void btnControlOrnillaUp(object sender, RoutedEventArgs e)
        {
            if(posisicionOrnilla<5)
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
            if(posisicionOrnilla>0)
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
            if(posicion == 0)
                return new BitmapImage(new Uri("/Img/controlPosicion0.png", UriKind.Relative));
            else if(posicion == 1)
                return new BitmapImage(new Uri("/Img/controlPosicion1.png", UriKind.Relative));
            else if(posicion==2)
                return new BitmapImage(new Uri("/Img/controlPosicion2.png", UriKind.Relative));
            else if (posicion == 3)
                return new BitmapImage(new Uri("/Img/controlPosicion3.png", UriKind.Relative));
            else if (posicion == 4)
                return new BitmapImage(new Uri("/Img/controlPosicion4.png", UriKind.Relative));
            else
                return new BitmapImage(new Uri("/Img/controlPosicion5.png", UriKind.Relative));
        }


        private static BitmapImage ImagenOrnilla(int posicion)
        {
            if (posicion == 0)
                return new BitmapImage(new Uri("/Img/ornilla0.png", UriKind.Relative));
            else if (posicion == 1)
                return new BitmapImage(new Uri("/Img/ornilla1.png", UriKind.Relative));
            else if (posicion == 2)
                return new BitmapImage(new Uri("/Img/ornilla2.png", UriKind.Relative));
            else if (posicion == 3)
                return new BitmapImage(new Uri("/Img/ornilla3.png", UriKind.Relative));
            else if (posicion == 4)
                return new BitmapImage(new Uri("/Img/ornilla4.png", UriKind.Relative));
            else
                return new BitmapImage(new Uri("/Img/ornilla5.png", UriKind.Relative));
        }

        private void btnAperturaTanqueDerecho(object sender, RoutedEventArgs e)
        {

            if (posisicionAperturaTanque < 5)
                posisicionAperturaTanque++;
            ornillaImagen.Source = ImagenOrnilla(posisicionOrnilla);
           ControlAperturaTanqueTXT.Text= posisicionAperturaTanque.ToString();
        }

        private void btnAperturaTanqueIzquierdo(object sender, RoutedEventArgs e)
        {
            if (posisicionAperturaTanque > 0)
                posisicionAperturaTanque--;
            if (posisicionAperturaTanque== 0)
            {
                ornillaImagen.Source = ImagenOrnilla(0);
            }
            ControlAperturaTanqueTXT.Text = posisicionAperturaTanque.ToString();
        }
    }
}
