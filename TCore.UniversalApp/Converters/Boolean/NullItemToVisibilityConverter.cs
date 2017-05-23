using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TCore.UniversalApp.Converters.Boolean
{
    /// <summary>
    /// This class converts Null to Visibility property. (null == Collapsed)
    /// </summary>
    public class NullItemToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var visibility = Visibility.Collapsed;

            if (value != null)
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
