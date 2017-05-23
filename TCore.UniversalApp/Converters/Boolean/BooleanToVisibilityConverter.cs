using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TCore.UniversalApp.Converters.Boolean
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Collapsed;

            if ((bool)value)
            {
                visibility = Visibility.Visible;
            }

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
