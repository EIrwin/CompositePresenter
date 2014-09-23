using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CompositePresenter.Core
{
    public class DefaultCenterBinding : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double left = System.Convert.ToDouble(values[0]);
            double top = System.Convert.ToDouble(values[1]);

            return new Point(left, top);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}