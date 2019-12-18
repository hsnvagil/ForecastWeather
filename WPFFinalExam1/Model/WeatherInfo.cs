using System;
using System.Collections.ObjectModel;

namespace WPFFinalExam1.Model
{
    public class WeatherInfo
    {
        public ForecastToday Today { get; set; }
        public ObservableCollection<DayForecast> Forecast { get; set; }

        public WeatherInfo()
        {
            Today = new ForecastToday();
            Forecast = new ObservableCollection<DayForecast>();
        }
    }
}