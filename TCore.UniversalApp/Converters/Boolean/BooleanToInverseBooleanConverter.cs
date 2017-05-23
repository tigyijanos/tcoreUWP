using System;
using Windows.UI.Xaml.Data;

namespace TCore.UniversalApp.Converters.Boolean
{
    public class BooleanToInverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool newValue = false;

            if(!(bool)value)
            {
                newValue = true;
            }

            return newValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool newValue = true;

            if (!(bool)value)
            {
                newValue = false;
            }

            return newValue;
        }
    }
}
