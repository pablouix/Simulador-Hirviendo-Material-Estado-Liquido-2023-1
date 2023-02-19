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
        }
        private void btnControlOrnillaDown(object sender, RoutedEventArgs e)
        {
            if(posisicionOrnilla>0)
                posisicionOrnilla--;
            ControlOrnillaTXT.Text = posisicionOrnilla.ToString();  
        }
    }
}
