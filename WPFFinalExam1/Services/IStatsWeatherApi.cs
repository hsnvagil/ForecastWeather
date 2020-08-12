using WPFFinalExam1.Model;

namespace WPFFinalExam1.Services {
    public interface IStatsWeatherApi {
        bool GetStatsData(string city, StatsWeatherInfo statsWeather);
    }
}