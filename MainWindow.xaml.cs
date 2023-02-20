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
        
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = this.Width;
            this.MaxHeight = this.Height;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAgua(object sender, RoutedEventArgs e)
        {
            ollaImagen.Source = new BitmapImage(new Uri("/Img/recipientes/ollaAgua.png", UriKind.Relative));
            MaterialTxt.Text = "Agua";
        }

        private void BtnAceite(object sender, RoutedEventArgs e)
        {
            ollaImagen.Source = new BitmapImage(new Uri("/Img/recipientes/ollaAceite.png", UriKind.Relative));
            MaterialTxt.Text = "Aceite";
        }

        private void btnControlOrnillaUp(object sender, RoutedEventArgs e)
        {
            if(posisicionOrnilla < 5)
                posisicionOrnilla++;
            ControlOrnillaTXT.Text = posisicionOrnilla.ToString();
            ControlImagen.Source = ImagenControlOrnilla(posisicionOrnilla);
            ornillaImagen.Source = ImagenOrnilla(posisicionOrnilla);
        }

        private void btnControlOrnillaDown(object sender, RoutedEventArgs e)
        {
            if(posisicionOrnilla > 0)
                posisicionOrnilla--;
            ControlOrnillaTXT.Text = posisicionOrnilla.ToString();
            ControlImagen.Source = ImagenControlOrnilla(posisicionOrnilla);
            ornillaImagen.Source = ImagenOrnilla(posisicionOrnilla);
        }

        private static BitmapImage ImagenControlOrnilla(int posicion)
        {
            return new BitmapImage(new Uri("/Img/perillas/controlPosicion"+ Convert.ToString(posicion) + ".png", UriKind.Relative));
        }

        private static BitmapImage ImagenOrnilla(int posicion)
        {
            return new BitmapImage(new Uri("/Img/ornillas/ornilla" + Convert.ToString(posicion) + ".png", UriKind.Relative));
        }
    }
}
