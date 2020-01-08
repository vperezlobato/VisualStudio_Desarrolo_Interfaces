using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PongSignalRUniversal
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double playerYPosition;
        double playerXPosition;
        int steps = 20;
        bool upMovement;
        bool downMovement;
        bool rightMovement;
        bool leftMovement;

        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }

        // Recognizes the KeyDown press and sets the relevant booleans to "true"
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Up)
            {
                upMovement = true;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Down)
            {
                downMovement = true;
            }
        }

        private void CompositionTarget_Rendering(object sender, object e)
        {
            playerYPosition = (double)stkJugador1.GetValue(Canvas.TopProperty);
            playerXPosition = (double)stkJugador1.GetValue(Canvas.LeftProperty);
            movePlayer();
        }

        // recognizes the KeyUp event and sets the relevant booleans to "false"
        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Up)
            {
                upMovement = false;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Down)
            {
                downMovement = false;
            }
        }

        // Calls the movement Methods of the relevant direction
        private void movePlayer()
        {
            if (upMovement)
            {
                moveUp();
            }
            if (downMovement)
            {
                moveDown();
            }
        }

        private void moveUp()
        {
            stkJugador1.SetValue(Canvas.TopProperty, playerYPosition);
        }

        private void moveDown()
        {
            stkJugador1.SetValue(Canvas.TopProperty, playerYPosition);
        }

    }
}
