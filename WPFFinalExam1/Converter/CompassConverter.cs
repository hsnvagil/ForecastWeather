using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFFinalExam1.Converter {
    internal class CompassConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (int) value + 90;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}