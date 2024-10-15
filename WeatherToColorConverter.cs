using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OOSU2_Lab3_2
{
    public class WeatherToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object
        parameter, System.Globalization.CultureInfo culture)
        {
            var weatherType = (WeatherType)value;
            switch (weatherType)
            {
                case WeatherType.Sunny:
                    return Brushes.Yellow;
                case WeatherType.Cloudy:
                    return Brushes.Gray;
                case WeatherType.Windy:
                    return Brushes.LightBlue;
                case WeatherType.Stormy:
                    return Brushes.DodgerBlue;
                case WeatherType.Snowy:
                    return Brushes.Snow;
                case WeatherType.Rainy:
                    return Brushes.LightSkyBlue;
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
        {
            var weatherType = (WeatherType)value;
            switch (weatherType)
            {
                case WeatherType.Sunny:
                    return Brushes.Yellow;
                case WeatherType.Cloudy:
                    return Brushes.Gray;
                case WeatherType.Windy:
                    return Brushes.LightBlue;
                case WeatherType.Stormy:
                    return Brushes.DodgerBlue;
                case WeatherType.Snowy:
                    return Brushes.Snow;
                case WeatherType.Rainy:
                    return Brushes.LightSkyBlue;
            }
            return Binding.DoNothing;
        }
    }
}
