using System.Collections.ObjectModel;

namespace WPFFinalExam1.Model {
    public class WeatherInfo {
        public WeatherInfo() {
            Today = new ForecastToday();
            Forecast = new ObservableCollection<DayForecast>();
        }

        public ForecastToday Today { get; set; }
        public ObservableCollection<DayForecast> Forecast { get; set; }
    }
}