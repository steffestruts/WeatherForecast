using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOSU2_Lab3_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckWeather(object sender, RoutedEventArgs e)
        {
            List<WeatherPrediction> data = new List<WeatherPrediction>();
            Random random = new Random();

            for (int i = 1; i <= sliderAmount.Value; i++)
            {
                WeatherPrediction wp = new WeatherPrediction()
                {
                    WeatherType = (WeatherType)random.Next(Enum.GetValues(typeof(WeatherType)).Length),
                    Degrees = random.Next(0, 40),
                    Humidity = ((double)random.Next(1,100))/100,
                    Wind = (((double)random.Next(1,1000))/100)*1.5,
                    WindDirection = random.Next(0,320),
                    Region = (Region)random.Next(Enum.GetValues(typeof(Region)).Length),
                    StartTime = random.Next(0, 12),
                    EndTime = random.Next(0, 12),
                    TimeLine = i,
                    Predictions = new List<WeatherPrediction>()
                };

                wp.Predictions.Add(wp.Transform(random.Next(1,5)));
                wp.Predictions.Add(wp.Transform(random.Next(1,5)));
                data.Add(wp);
            }

            DataContext = data;
        }
    }

    public class WeatherPrediction
    {
        public WeatherType WeatherType { get; set; }
        public double Degrees { get; set; }
        public double Humidity { get; set; }
        public double Wind { get; set; }
        public double WindDirection { get; set; }
        public Region Region { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int TimeLine { get; set; }
        public List<WeatherPrediction> Predictions { get; set; }

        public WeatherPrediction Transform(int Power)
        {
            Random random = new Random();

            if (random.Next(1, 3) == 2)
            {
                return new WeatherPrediction()
                {
                    Degrees = this.Degrees + Power,
                    Humidity = this.Humidity * (Power / 10),
                    Wind = this.Wind * Power,
                    WindDirection = this.WindDirection / Power
                };
            }
            else
            {
                return new WeatherPrediction()
                {
                    Degrees = this.Degrees - Power,
                    Humidity = this.Humidity * (Power * 10),
                    Wind = this.Wind / Power,
                    WindDirection = this.WindDirection / Power
                };
            }
        }
    }


    public enum Region
    {
        Göteborg,
        Borås,
        Jönköping,
        Varberg,
        Malmö,
        Linköping,
        Norrköping,
        Stockholm,
        Västerås,
        Örebro,
        Uppsala,
        Karlstad,
        Falun,
        Mora,
        Gävle,
        Sundsvall,
        Umeå,
        Skellefteå,
        Piteå,
        Luleå
    }

    public enum WeatherType
    {
        Sunny,
        Rainy,
        Cloudy,
        Stormy,
        Windy,
        Snowy
    }
}
