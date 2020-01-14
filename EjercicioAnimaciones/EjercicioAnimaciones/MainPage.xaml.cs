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
            animacionEjeY.From = 10;
            moverEstrellas.Begin();

            for (int i = 0; i < 20; i++) {
                Ellipse ellipse = new Ellipse();
                Random rnd = new Random();
                if (i <= 5)
                {
                    ellipse.Height = 10;
                    ellipse.Width = 10;
                    Canvas.SetLeft(ellipse, rnd.Next(1000));
                    Canvas.SetTop(ellipse, rnd.Next(1000));
                    ellipse.Stroke = new SolidColorBrush(Colors.Violet);
                    ellipse.Fill = new SolidColorBrush(Colors.White);
                    TranslateTransform translate = new TranslateTransform();
                    translate.Y = 0;
                    TransformGroup myTransformGroup = new TransformGroup();
                    myTransformGroup.Children.Add(translate);
                    ellipse.RenderTransform = myTransformGroup;

                    ellipse.RenderTransform = new TranslateTransform();
                    Storyboard storyboard = new Storyboard();

                    DoubleAnimation translateYAnimation = new DoubleAnimation();
                    translateYAnimation.From = 0;
                    translateYAnimation.To = 1000;
                    translateYAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(13000));

                    Storyboard.SetTarget(translateYAnimation, ellipse);
                    Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

                    storyboard.Children.Add(translateYAnimation);
                    canvas.Children.Add(ellipse);
                    translateYAnimation.Completed += animacionCompletada;                    
                    storyboard.Begin();
                }
                else
                    if (i <= 10)
                {
                    ellipse.Height = 20;
                    ellipse.Width = 20;
                    Canvas.SetLeft(ellipse, rnd.Next(1000));
                    Canvas.SetTop(ellipse, rnd.Next(1000));
                    ellipse.Stroke = new SolidColorBrush(Colors.Violet);
                    ellipse.Fill = new SolidColorBrush(Colors.White);
                    TranslateTransform translate = new TranslateTransform();
                    ellipse.RenderTransform = new TranslateTransform();
                    Storyboard storyboard = new Storyboard();

                    DoubleAnimation translateYAnimation = new DoubleAnimation();
                    translateYAnimation.From = 0;
                    translateYAnimation.To = 1000;
                    translateYAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(10000));

                    Storyboard.SetTarget(translateYAnimation, ellipse);
                    Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

                    storyboard.Children.Add(translateYAnimation);
                    canvas.Children.Add(ellipse);
                    storyboard.Begin();
                }
                else
                    if (i <= 15)
                {
                    ellipse.Height = 30;
                    ellipse.Width = 30;
                    Canvas.SetLeft(ellipse, rnd.Next(1000));
                    Canvas.SetTop(ellipse, rnd.Next(1000));
                    ellipse.Stroke = new SolidColorBrush(Colors.Violet);
                    ellipse.Fill = new SolidColorBrush(Colors.White);
                    TranslateTransform translate = new TranslateTransform();
                    ellipse.RenderTransform = new TranslateTransform();
                    Storyboard storyboard = new Storyboard();

                    DoubleAnimation translateYAnimation = new DoubleAnimation();
                    translateYAnimation.From = 0;
                    translateYAnimation.To = 1000;
                    translateYAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(7000));

                    Storyboard.SetTarget(translateYAnimation, ellipse);
                    Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

                    storyboard.Children.Add(translateYAnimation);
                    canvas.Children.Add(ellipse);
                    storyboard.Begin();

                }
                else {
                    ellipse.Height = 40;
                    ellipse.Width = 40;
                    Canvas.SetLeft(ellipse, rnd.Next(1000));
                    Canvas.SetTop(ellipse, rnd.Next(1000));
                    ellipse.Stroke = new SolidColorBrush(Colors.Violet);
                    ellipse.Fill = new SolidColorBrush(Colors.White);
                    TranslateTransform translate = new TranslateTransform();
                    ellipse.RenderTransform = new TranslateTransform();
                    Storyboard storyboard = new Storyboard();

                    DoubleAnimation translateYAnimation = new DoubleAnimation();
                    translateYAnimation.From = 0;
                    translateYAnimation.To = 1000;
                    translateYAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));

                    Storyboard.SetTarget(translateYAnimation, ellipse);
                    Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

                    storyboard.Children.Add(translateYAnimation);
                    canvas.Children.Add(ellipse);
                    storyboard.Begin();
                }                                

                
            }
        }

        private void AnimacionEjeY_Completed(object sender, object e)
        {
            animacionEjeY.From = 10;
            animacionEjeY.To = 1000;
            moverEstrellas.Begin();
        }

        private void animacionCompletada(object sender, object e)
        {
            Random rnd = new Random();
            Ellipse ellipse = new Ellipse();
            DoubleAnimation translateYAnimation = (DoubleAnimation)sender;

            translateYAnimation.From = 0;
            translateYAnimation.To = 1000;
            translateYAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(10000));
        }        

        private void allowfocus_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.Content.KeyDown += this.vMGame.Grid_KeyDown;
            Window.Current.Content.KeyUp += this.vMGame.Grid_KeyUp;
        }


    }
}
