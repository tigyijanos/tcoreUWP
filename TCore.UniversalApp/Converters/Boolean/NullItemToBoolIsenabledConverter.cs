using System;
using Windows.UI.Xaml.Data;

namespace TCore.UniversalApp.Converters.Boolean
{
    /// <summary>
    /// This class converts Null to Isenabled's bool property. (null == false)
    /// </summary>
    public class NullItemToBoolIsenabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool nValue = false;

            if (value != null)
            {
                nValue = true;
            }

            return nValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
