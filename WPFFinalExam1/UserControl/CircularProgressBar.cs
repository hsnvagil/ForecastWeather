using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CircularProgressBar {
    public enum StrokeMode {
        Middle,
        Inside,
        Outside
    }

    public class CircularProgressBar : ProgressBar {
        public CircularProgressBar() {
            ValueChanged += CircularProgressBar_ValueChanged;
            SizeChanged += CircularProgressBar_SizeChanged;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e) {
            if (e.Property == RadiusProperty) Width = Height = Radius * 2;

            base.OnPropertyChanged(e);
        }

        private void CircularProgressBar_SizeChanged(object sender, SizeChangedEventArgs e) {
            Radius = Math.Min(ActualWidth, ActualHeight) / 2;
        }

        private void CircularProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            var bar = sender as CircularProgressBar;
            var currentAngle = bar.Angle;
            var targetAngle = e.NewValue / bar.Maximum * 359.999;
            var duration = Math.Abs(currentAngle - targetAngle) / 359.999 * 500;

            var anim = new DoubleAnimation(currentAngle, targetAngle,
                                           TimeSpan.FromMilliseconds(duration > 0 ? duration : 10));
            bar.BeginAnimation(AngleProperty, anim, HandoffBehavior.Compose);
        }

        private double Angle {
            get => (double) GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressBar),
                                        new PropertyMetadata(0.0));

        public double StrokeThickness {
            get => (double) GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(CircularProgressBar),
                                        new PropertyMetadata(1.0));

        public double Thickness {
            get => (double) GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register(nameof(Thickness), typeof(double), typeof(CircularProgressBar),
                                        new PropertyMetadata(10d));

        public double Radius {
            get => (double) GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(CircularProgressBar),
                                        new PropertyMetadata(50.0));

        public Brush Fill {
            get => (Brush) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register(nameof(Fill), typeof(Brush), typeof(CircularProgressBar),
                                        new PropertyMetadata(Brushes.Transparent));

        public Brush Stroke {
            get => (Brush) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register(nameof(Stroke), typeof(Brush), typeof(CircularProgressBar),
                                        new PropertyMetadata(Brushes.LightGray));

        private PenLineCap StartLineCap {
            get => (PenLineCap) GetValue(StartLineCapProperty);
            set => SetValue(StartLineCapProperty, value);
        }

        public static readonly DependencyProperty StartLineCapProperty =
            DependencyProperty.Register(nameof(StartLineCap), typeof(PenLineCap), typeof(CircularProgressBar),
                                        new PropertyMetadata(PenLineCap.Flat));

        public PenLineCap EndLineCap {
            get => (PenLineCap) GetValue(EndLineCapProperty);
            set => SetValue(EndLineCapProperty, value);
        }

        public static readonly DependencyProperty EndLineCapProperty =
            DependencyProperty.Register(nameof(EndLineCap), typeof(PenLineCap), typeof(CircularProgressBar),
                                        new PropertyMetadata(PenLineCap.Round));

        public StrokeMode StrokeMode {
            get => (StrokeMode) GetValue(StrokeModeProperty);
            set => SetValue(StrokeModeProperty, value);
        }

        public static readonly DependencyProperty StrokeModeProperty =
            DependencyProperty.Register(nameof(StrokeMode), typeof(StrokeMode), typeof(CircularProgressBar),
                                        new PropertyMetadata(StrokeMode.Middle));
    }
}