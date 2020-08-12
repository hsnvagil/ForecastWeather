using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CircularProgressBar {
    public class AngleToPointConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter,
                              CultureInfo culture) {
            var angle = (double) values[0];
            var radius = (double) values[1];
            var stroke = (double) values[2];
            var pang = angle * Math.PI / 180;

            var px = Math.Sin(pang) * (radius - stroke / 2) + radius;
            var py = -Math.Cos(pang) * (radius - stroke / 2) + radius;
            return new Point(px, py);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter,
                                    CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class AngleToIsLargeConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var angle = (double) value;

            return angle > 180;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter,
                                  CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class StrokeToStartPointConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter,
                              CultureInfo culture) {
            var radius = (double) values[0];
            var stroke = (double) values[1];
            return new Point(radius, stroke / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter,
                                    CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class RadiusToSizeConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter,
                              CultureInfo culture) {
            var radius = (double) values[0];
            var stroke = (double) values[1];

            return new Size(radius - stroke / 2, radius - stroke / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter,
                                    CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class RadiusToCenterConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var radius = (double) value;
            return new Point(radius, radius);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class RadiusToDiameter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var radius = (double) value;
            return 2 * radius;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class InnerRadiusConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter,
                              CultureInfo culture) {
            var radius = (double) values[0];
            var stroke = (double) values[1];
            var mode = (StrokeMode) values[2];

            switch (mode) {
                case StrokeMode.Inside:
                    return radius - stroke;
                case StrokeMode.Outside:
                    return radius;
                default:
                    return radius - stroke / 2;
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter,
                                    CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class StrokeLineCapConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if (values[0] is double progress && progress > 0) {
                var cap = (PenLineCap) values[1];
                return cap;
            }

            return PenLineCap.Flat;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}