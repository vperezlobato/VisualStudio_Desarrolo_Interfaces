using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;

namespace MyWhiteboard.Stroke
{
    public class StrokeSynchronization
    {
        private readonly InkCanvas canvas;
        private readonly InkToolbar inkToolbar;
        private readonly object canvasChangeLock = new object();
        private readonly Dictionary<Guid, InkStroke> idToStrokeMapping;
        private readonly InkStrokeBuilder strokeBuilder;
        private readonly StrokeChangeBroker strokeChangeBroker;
        List<Point> points;
        IReadOnlyList<InkStroke> _added;

        public StrokeSynchronization(InkCanvas canvas, InkToolbar inkToolbar, StrokeChangeBroker strokeChangeBroker)
        {
            this.canvas = canvas;
            this.inkToolbar = inkToolbar;
            this.strokeChangeBroker = strokeChangeBroker;

            strokeBuilder = new InkStrokeBuilder();

            idToStrokeMapping = new Dictionary<Guid, InkStroke>();

            strokeChangeBroker.StrokeCollected += StrokeChangeBrokerOnStrokeCollected;
            strokeChangeBroker.StrokeErased += StrokeChangeBrokerOnStrokeErased;
            strokeChangeBroker.AllStrokeErased += StrokeChangeBrokerOnAllStrokeErased;
            strokeChangeBroker.ResendAllStrokesRequested += StrokeChangeBrokerOnResendAllStrokesRequested;

            inkToolbar.EraseAllClicked += InkToolbarOnEraseAllClicked;

            canvas.InkPresenter.StrokesCollected += InkPresenterOnStrokesCollected;
            canvas.InkPresenter.StrokesErased += InkPresenterOnStrokesErased;
            canvas.InkPresenter.StrokeInput.StrokeContinued += StrokeInput_StrokeContinued;
            canvas.InkPresenter.StrokeInput.StrokeStarted += StrokeInput_StrokeStarted;
            canvas.InkPresenter.StrokeInput.StrokeEnded += StrokeInput_StrokeEnded;
            canvas.InkPresenter.StrokesCollected += InkPresenter_StrokesCollected;

            points = new List<Point>();
        }

        public void StopSynchronization()
        {
            strokeChangeBroker.StrokeCollected -= StrokeChangeBrokerOnStrokeCollected;
            strokeChangeBroker.StrokeErased -= StrokeChangeBrokerOnStrokeErased;
            strokeChangeBroker.AllStrokeErased -= StrokeChangeBrokerOnAllStrokeErased;
            strokeChangeBroker.ResendAllStrokesRequested -= StrokeChangeBrokerOnResendAllStrokesRequested;

            inkToolbar.EraseAllClicked -= InkToolbarOnEraseAllClicked;

            canvas.InkPresenter.StrokesCollected -= InkPresenterOnStrokesCollected;
            canvas.InkPresenter.StrokesErased -= InkPresenterOnStrokesErased;

            canvas.InkPresenter.StrokeInput.StrokeContinued -= StrokeInput_StrokeContinued;
            canvas.InkPresenter.StrokeInput.StrokeStarted -= StrokeInput_StrokeStarted;
            canvas.InkPresenter.StrokeInput.StrokeEnded -= StrokeInput_StrokeEnded;
            canvas.InkPresenter.StrokesCollected -= InkPresenter_StrokesCollected;

            strokeChangeBroker.StopBroker();
        }

        private void InkPresenter_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
        {
            _added = args.Strokes;
        }

        private void StrokeInput_StrokeEnded(InkStrokeInput sender, PointerEventArgs args)
        {
            points = new List<Point>();
        }

        private void StrokeInput_StrokeStarted(InkStrokeInput sender, PointerEventArgs args)
        {
            //builder.BeginStroke(args.CurrentPoint);

            //line = new Line();
            //line.X1 = args.CurrentPoint.RawPosition.X;
            //line.Y1 = args.CurrentPoint.RawPosition.Y;
            //line.X2 = args.CurrentPoint.RawPosition.X;
            //line.Y2 = args.CurrentPoint.RawPosition.Y;

            //line.Stroke = new SolidColorBrush(Colors.Purple);
            //line.StrokeThickness = 4; 
        }

        private void StrokeInput_StrokeContinued(InkStrokeInput sender, PointerEventArgs args)
        {
            // Coge el punto por el que ha pasado el cursor pulsado
            Point point = new Point(args.CurrentPoint.Position.X, args.CurrentPoint.Position.Y);

            // Lo añade a la lista de puntos
            points.Add(point);

            // Si la lista tiene más de un punto
            if (points.Count > 1)
            {
                // Creau una lista de InkPoints a partir de la lista de puntos, necesaria para hacer el stroke
                List<InkPoint> inkpoints = new List<InkPoint>();

                foreach (Point p in points)
                {
                    inkpoints.Add(new InkPoint(p, 0.5f));
                }

                // Crea el stroke a partir de los inkpoints
                InkStroke stroke = strokeBuilder.CreateStrokeFromInkPoints(inkpoints, System.Numerics.Matrix3x2.Identity);

                // Copia los atributos de dibujado (color y eso) del canvas original
                InkDrawingAttributes ida = canvas.InkPresenter.CopyDefaultDrawingAttributes();
                stroke.DrawingAttributes = ida;

                // Guarda el ultimo punto
                Point ultimo = points.Last<Point>();

                // Vacía la lista de puntos y le añade el ultimo del anterior stroke, para que el dibujado no de "saltos"
                points = new List<Point>();
                points.Add(ultimo);
            }
        }

        private async void StrokeChangeBrokerOnStrokeCollected(object sender, StrokeDescription strokeDescription)
        {
            if (idToStrokeMapping.ContainsKey(strokeDescription.Id))
            {
                return;
            }

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    lock (canvasChangeLock)
                    {
                        InkDrawingAttributes inkDrawingAttributes;
                        if (strokeDescription.IsPencil)
                        {
                            inkDrawingAttributes = InkDrawingAttributes.CreateForPencil();
                            inkDrawingAttributes.PencilProperties.Opacity = strokeDescription.Opacity;
                        }
                        else
                        {
                            inkDrawingAttributes = new InkDrawingAttributes();
                            inkDrawingAttributes.DrawAsHighlighter = strokeDescription.DrawAsHighlighter;
                        }

                        inkDrawingAttributes.Color = Color.FromArgb(strokeDescription.ColorValues[0], strokeDescription.ColorValues[1], strokeDescription.ColorValues[2], strokeDescription.ColorValues[3]);
                        inkDrawingAttributes.FitToCurve = strokeDescription.FitToCurve;
                        inkDrawingAttributes.IgnorePressure = strokeDescription.IgnorePressure;
                        inkDrawingAttributes.Size = new Size(strokeDescription.SizeValues[0], strokeDescription.SizeValues[1]);

                        strokeBuilder.SetDefaultDrawingAttributes(inkDrawingAttributes);

                        var points = new List<InkPoint>(strokeDescription.PointXValues.Length);
                        for (var i = 0; i < strokeDescription.PointXValues.Length; i++)
                        {
                            points.Add(new InkPoint(new Point(strokeDescription.PointXValues[i], strokeDescription.PointYValues[i]), strokeDescription.PressureValues[i]));
                        }

                        var newStroke = strokeBuilder.CreateStrokeFromInkPoints(points, Matrix3x2.Identity);
                        idToStrokeMapping[strokeDescription.Id] = newStroke;

                        canvas.InkPresenter.StrokeContainer.AddStroke(newStroke);
                    }
                });
        }

        private async void StrokeChangeBrokerOnStrokeErased(object sender, Guid strokeId)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    lock (canvasChangeLock)
                    {
                        if (!idToStrokeMapping.ContainsKey(strokeId))
                        {
                            return;
                        }

                        idToStrokeMapping.Remove(strokeId);

                        foreach (var strokeMapping in idToStrokeMapping.ToList())
                        {
                            var newStroke = strokeMapping.Value.Clone();
                            idToStrokeMapping[strokeMapping.Key] = newStroke;
                        }

                        canvas.InkPresenter.StrokeContainer.Clear();
                        canvas.InkPresenter.StrokeContainer.AddStrokes(idToStrokeMapping.Values.ToList());
                    }
                });
        }

        private async void StrokeChangeBrokerOnAllStrokeErased(object sender, EventArgs eventArgs)
        {
            idToStrokeMapping.Clear();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    lock (canvasChangeLock)
                    {
                        canvas.InkPresenter.StrokeContainer.Clear();
                    }
                });
        }

        private void StrokeChangeBrokerOnResendAllStrokesRequested(object sender, EventArgs eventArgs)
        {
            foreach (var inkStroke in idToStrokeMapping)
            {
                strokeChangeBroker.SendStrokeCollected(inkStroke.Key, inkStroke.Value);
            }
        }

        private void InkToolbarOnEraseAllClicked(InkToolbar sender, object args)
        {
            idToStrokeMapping.Clear();

            strokeChangeBroker.SendEraseAllStrokes();
        }

        private void InkPresenterOnStrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
        {
            foreach (var stroke in args.Strokes)
            {
                var strokeId = Guid.NewGuid();

                idToStrokeMapping[strokeId] = stroke;

                strokeChangeBroker.SendStrokeCollected(strokeId, stroke);
            }
        }

        private void InkPresenterOnStrokesErased(InkPresenter sender, InkStrokesErasedEventArgs args)
        {
            foreach (var stroke in args.Strokes)
            {
                foreach (var inkStrokeMapping in idToStrokeMapping.ToList())
                {
                    if (inkStrokeMapping.Value != stroke)
                    {
                        continue;
                    }

                    var id = inkStrokeMapping.Key;
                    idToStrokeMapping.Remove(id);
                    strokeChangeBroker.SendEraseStroke(id);
                }
            }
        }
    }
}