using System;
using System.Globalization;
using Xamarin.Forms;

namespace BehaviorProject
{
    public class SwitchTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as ToggledEventArgs)?.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
