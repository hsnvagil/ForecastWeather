using WPFFinalExam1.Model;

namespace WPFFinalExam1.Services {
    public interface IWeatherAPI {
        bool GetCityData(string city, WeatherInfo weatherInfo);
    }
}