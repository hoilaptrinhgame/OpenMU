using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Data;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.Models;

namespace MUnique.OpenMU.Launcher.Helpers.Converters
{
    public class PropertyNameToPropertyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                //return SettingsManager.Settings.GetType().GetProperty(name).
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}