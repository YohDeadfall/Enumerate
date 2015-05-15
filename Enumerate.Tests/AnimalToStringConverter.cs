using Enumerate.Tests.Properties;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Enumerate.Tests
{
    public sealed class AnimalToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            { return Resources.NotSet; }

            return Resources.ResourceManager.GetString(value.ToString(), culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
