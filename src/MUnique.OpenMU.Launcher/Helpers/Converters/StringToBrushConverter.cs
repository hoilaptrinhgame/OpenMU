using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MUnique.OpenMU.Launcher.Helpers.Converters
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                switch (name)
                {
                    case "yellow":
                        return Brushes.Yellow;
                    case "amber":
                        return Brushes.Orange;
                    case "deeporange":
                        return Brushes.OrangeRed;
                    case "lightblue":
                        return Brushes.LightSkyBlue;
                    case "teal":
                        return Brushes.Teal;
                    case "cyan":
                        return Brushes.Cyan;
                    case "pink":
                        return Brushes.DeepPink;
                    case "green":
                        return Brushes.Green;
                    case "deeppurple":
                        return Brushes.Purple;
                    case "indigo":
                        return Brushes.Indigo;
                    case "lightgreen":
                        return Brushes.LightGreen;
                    case "blue":
                        return Brushes.Blue;
                    case "lime":
                        return Brushes.Lime;
                    case "red":
                        return Brushes.Red;
                    case "orange":
                        return Brushes.DarkOrange;
                    case "purple":
                        return Brushes.MediumPurple;
                    case "bluegrey":
                        return Brushes.DimGray;
                    case "grey":
                        return Brushes.Gray;
                    case "brown":
                        return Brushes.SaddleBrown;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
