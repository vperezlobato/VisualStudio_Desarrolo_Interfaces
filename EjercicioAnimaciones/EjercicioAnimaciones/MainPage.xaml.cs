using EjercicioAnimaciones.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace EjercicioAnimaciones
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPageVM vMGame { get; }
        public MainPage()
        {
            this.InitializeComponent();
            vMGame = (MainPageVM)this.DataContext;

            moverEstrellas.Begin();
            cambiarColor.Begin();            
            animacionEjeY.From = 10;
            animacionColor.From = Colors.Red;

            for (int i = 0; i < 50; i++) {
                Random rnd = new Random();
                int aleatorio;
                aleatorio = rnd.Next(4);
                Ellipse ellipse = new Ellipse();
                switch (aleatorio)
                {
                    case 0:
                        ellipse = crearEllipse();
                        crearAnimacion(ellipse);
                        break;
                    case 1:
                        ellipse = crearEllipse2();
                        crearAnimacion2(ellipse);
                        break;
                    case 2:
                        ellipse = crearEllipse3();
                        crearAnimacion3(ellipse);
                        break;
                    case 3:
                        ellipse = crearEllipse4();
                        crearAnimacion4(ellipse);
                        break;
                }


            }
        }

        private void AnimacionEjeY_Completed(object sender, object e)
        {
            animacionEjeY.From = 10;
            animacionEjeY.To = 1000;
            moverEstrellas.Begin();
        }

        private void animacionColorCompleted(object sender, object e)
        {
            animacionColor.From = Colors.Red;
            animacionColor.To = Colors.Green;
            cambiarColor.Begin();
        }

        private Ellipse crearEllipse()
        {
            Ellipse ellipse = new Ellipse() ;
            Random rnd = new Random();
            ellipse.Height = 15;
            ellipse.Width = 15;
            Canvas.SetLeft(ellipse, rnd.Next(1500));
            Canvas.SetTop(ellipse, rnd.Next(500));
            ellipse.Stroke = new SolidColorBrush(Colors.Violet);
            ellipse.Fill = new SolidColorBrush(Colors.Violet);
            ellipse.Opacity = (1.0 * ellipse.Height) / 5;
            ellipse.RenderTransform = new TranslateTransform();
            return ellipse;
            
        }

        public void crearAnimacion(Ellipse ellipse) {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation translateYAnimation = new DoubleAnimation();
            translateYAnimation.From = 0;
            translateYAnimation.To = 1000;
            translateYAnimation.Duration = new Duration(TimeSpan.FromSeconds((10 * 2) / ellipse.Height));

            Storyboard.SetTarget(translateYAnimation, ellipse);
            Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

            storyboard.Children.Add(translateYAnimation);
            canvas.Children.Add(ellipse);
            storyboard.Begin();
            translateYAnimation.Completed += (Sender, e) => {
                Random rnd = new Random();
                int aleatorio;
                canvas.Children.Remove(ellipse);
                aleatorio = rnd.Next(4);
                Ellipse ellipseNueva;
                switch (aleatorio)
                {
                    case 0:
                       ellipseNueva = crearEllipse();
                       Canvas.SetTop(ellipseNueva, 0);
                       crearAnimacion(ellipseNueva);
                    break;
                    case 1:
                        ellipseNueva = crearEllipse2();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion2(ellipseNueva);
                        break;
                    case 2:
                        ellipseNueva = crearEllipse3();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion3(ellipseNueva);
                        break;
                    case 3:
                        ellipseNueva = crearEllipse4();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion4(ellipseNueva);
                        break;
                }
            };
        }

        private Ellipse crearEllipse2()
        {
            Ellipse ellipse = new Ellipse();
            Random rnd = new Random();
            ellipse.Height = 10;
            ellipse.Width = 10;
            Canvas.SetLeft(ellipse, rnd.Next(1500));
            Canvas.SetTop(ellipse, rnd.Next(500));
            ellipse.Stroke = new SolidColorBrush(Colors.Violet);
            ellipse.Fill = new SolidColorBrush(Colors.Red);
            ellipse.Opacity = (1.0 * ellipse.Height) / 5;
            ellipse.RenderTransform = new TranslateTransform();

            return ellipse;

        }

        public void crearAnimacion2(Ellipse ellipse)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation translateYAnimation = new DoubleAnimation();
            translateYAnimation.From = 0;
            translateYAnimation.To = 1000;
            translateYAnimation.Duration = new Duration(TimeSpan.FromSeconds((10 * 2) / ellipse.Height));

            Storyboard.SetTarget(translateYAnimation, ellipse);
            Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

            storyboard.Children.Add(translateYAnimation);
            canvas.Children.Add(ellipse);
            storyboard.Begin();
            translateYAnimation.Completed += (Sender, e) => {
                Random rnd = new Random();
                int aleatorio;
                canvas.Children.Remove(ellipse);
                aleatorio = rnd.Next(4);
                Ellipse ellipseNueva;
                switch (aleatorio)                
                {
                    case 0:
                        ellipseNueva = crearEllipse();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion(ellipseNueva);
                        break;
                    case 1:
                        ellipseNueva = crearEllipse2();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion2(ellipseNueva);
                        break;
                    case 2:
                        ellipseNueva = crearEllipse3();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion3(ellipseNueva);
                        break;
                    case 3:
                        ellipseNueva = crearEllipse4();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion4(ellipseNueva);
                        break;
                }
            };
        }

        private Ellipse crearEllipse3()
        {
            Ellipse ellipse = new Ellipse();
            Random rnd = new Random();
            ellipse.Height = 7;
            ellipse.Width = 7;
            Canvas.SetLeft(ellipse, rnd.Next(1500));
            Canvas.SetTop(ellipse, rnd.Next(500));
            ellipse.Stroke = new SolidColorBrush(Colors.Violet);
            ellipse.Fill = new SolidColorBrush(Colors.Yellow);
            ellipse.Opacity = (1.0 * ellipse.Height) / 5;
            ellipse.RenderTransform = new TranslateTransform();

            return ellipse;

        }

        public void crearAnimacion3(Ellipse ellipse)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation translateYAnimation = new DoubleAnimation();
            translateYAnimation.From = 0;
            translateYAnimation.To = 1000;
            translateYAnimation.Duration = new Duration(TimeSpan.FromSeconds((10 * 2) / ellipse.Height));

            Storyboard.SetTarget(translateYAnimation, ellipse);
            Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

            storyboard.Children.Add(translateYAnimation);
            canvas.Children.Add(ellipse);
            storyboard.Begin();
            translateYAnimation.Completed += (Sender, e) => {
                Random rnd = new Random();
                int aleatorio;
                canvas.Children.Remove(ellipse);
                aleatorio = rnd.Next(4);
                Ellipse ellipseNueva;
                switch (aleatorio)
                {
                    case 0:
                        ellipseNueva = crearEllipse();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion(ellipseNueva);
                        break;
                    case 1:
                        ellipseNueva = crearEllipse2();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion2(ellipseNueva);
                        break;
                    case 2:
                        ellipseNueva = crearEllipse3();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion3(ellipseNueva);
                        break;
                    case 3:
                        ellipseNueva = crearEllipse4();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion4(ellipseNueva);
                        break;
                }
            };
            
        }

        private Ellipse crearEllipse4()
        {
            Ellipse ellipse = new Ellipse();
            Random rnd = new Random();
            ellipse.Height = 3;
            ellipse.Width = 3;
            Canvas.SetLeft(ellipse, rnd.Next(1500));
            Canvas.SetTop(ellipse, rnd.Next(500));
            ellipse.Stroke = new SolidColorBrush(Colors.Violet);
            ellipse.Fill = new SolidColorBrush(Colors.White);
            ellipse.Opacity = (1.0 * ellipse.Height) / 5;
            ellipse.RenderTransform = new TranslateTransform();

            return ellipse;

        }

        public void crearAnimacion4(Ellipse ellipse)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation translateYAnimation = new DoubleAnimation();
            translateYAnimation.From = 0;
            translateYAnimation.To = 1000;
            translateYAnimation.Duration = new Duration(TimeSpan.FromSeconds((10 * 2) / ellipse.Height));

            Storyboard.SetTarget(translateYAnimation, ellipse);
            Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

            storyboard.Children.Add(translateYAnimation);
            canvas.Children.Add(ellipse);
            storyboard.Begin();
            translateYAnimation.Completed += (Sender, e) => {
                Random rnd = new Random();
                int aleatorio;
                canvas.Children.Remove(ellipse);
                aleatorio = rnd.Next(4);
                Ellipse ellipseNueva;
                switch (aleatorio)
                {
                    case 0:
                        ellipseNueva = crearEllipse();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion(ellipseNueva);
                        break;
                    case 1:
                        ellipseNueva = crearEllipse2();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion2(ellipseNueva);
                        break;
                    case 2:
                        ellipseNueva = crearEllipse3();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion3(ellipseNueva);
                        break;
                    case 3:
                        ellipseNueva = crearEllipse4();
                        Canvas.SetTop(ellipseNueva, 0);
                        crearAnimacion4(ellipseNueva);
                        break;
                }
            };
            
        }

        private void allowfocus_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.Content.KeyDown += this.vMGame.Grid_KeyDown;
            Window.Current.Content.KeyUp += this.vMGame.Grid_KeyUp;
        }


    }
}
