﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pinturillo
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PantallaJuego : Page
    {
        public PantallaJuego()
        {
            this.InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Name = "Angela", Age = 22 });
            items.Add(new User() { Name = "Victor", Age = 20 });
            items.Add(new User() { Name = "Ivan", Age = 23 });
            listadoSalas.ItemsSource = items;

          
            inkCanvas.InkPresenter.InputDeviceTypes =
  Windows.UI.Core.CoreInputDeviceTypes.Mouse |
  Windows.UI.Core.CoreInputDeviceTypes.Pen |
  Windows.UI.Core.CoreInputDeviceTypes.Touch;
        }
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        private void BackArrow_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        //// Update ink stroke color for new strokes.
        //private void OnPenColorChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (inkCanvas != null)
        //    {
        //        InkDrawingAttributes drawingAttributes =
        //            inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();

        //        string value = ((ComboBoxItem)PenColor.SelectedItem).Content.ToString();

        //        switch (value)
        //        {
        //            case "Black":
        //                drawingAttributes.Color = Windows.UI.Colors.Black;
        //                break;
        //            case "Red":
        //                drawingAttributes.Color = Windows.UI.Colors.Red;
        //                break;
        //            default:
        //                drawingAttributes.Color = Windows.UI.Colors.Black;
        //                break;
        //        };

        //        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        //    }
        //}

    }
}
