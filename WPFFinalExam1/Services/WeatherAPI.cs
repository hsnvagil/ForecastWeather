using System;
using System.Net;
using Newtonsoft.Json;
using WPFFinalExam1.Converter;
using WPFFinalExam1.Model;

namespace WPFFinalExam1.Services {
    internal class WeatherAPI : IWeatherAPI {
        private readonly string _key;
        private readonly string _key2;
        private readonly string _key3;


        private readonly WebClient _client;
        private readonly TimeConverter _timeConverter = new TimeConverter();
        private readonly IconConvert _iconConvert = new IconConvert();

        public WeatherAPI() {
            _key = "de6091252082423590a104919201208";
            _key2 = "55e7c02a42fc4ccc86f7263aaa38397f";
            _key3 = "c668ae28a3e0a0c83980cd0b40442b2d";
            _client = new WebClient();
        }

        public bool GetCityData(string city, WeatherInfo weatherInfo) {
            try {
                var resultApi3 = _client.DownloadString(
                    $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_key3}");
                dynamic jsonData3 = JsonConvert.DeserializeObject(resultApi3);

                var resultApi2 =
                    _client.DownloadString($"https://api.weatherbit.io/v2.0/forecast/daily?city={city}&key={_key2}");
                dynamic jsonData2 = JsonConvert.DeserializeObject(resultApi2);

                var resultApi = _client.DownloadString(
                    $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={_key}&q={city}&num_of_days=10&tp=1&format=json");
                dynamic jsonData = JsonConvert.DeserializeObject(resultApi);

                weatherInfo.Today.City = jsonData3.name.ToString();
                weatherInfo.Today.Query = jsonData.data.request[0].query;
                weatherInfo.Today.Time = DateTime.Now;
                weatherInfo.Today.TempC = jsonData.data.current_condition[0].temp_C;
                weatherInfo.Today.TempF = jsonData.data.current_condition[0].temp_F;
                weatherInfo.Today.Des = jsonData.data.current_condition[0].weatherDesc[0].value;
                weatherInfo.Today.WindSpeedMiles = jsonData.data.current_condition[0].windspeedMiles;
                weatherInfo.Today.WindSpeedKm = jsonData.data.current_condition[0].windspeedKmph;
                weatherInfo.Today.WindDirDegree = jsonData.data.current_condition[0].winddirDegree;
                weatherInfo.Today.Humidity = jsonData.data.current_condition[0].humidity;
                weatherInfo.Today.VisibilityMiles = jsonData.data.current_condition[0].visibilityMiles;
                weatherInfo.Today.Visibility = jsonData.data.current_condition[0].visibility;
                weatherInfo.Today.Barometer = jsonData.data.current_condition[0].pressure;
                weatherInfo.Today.BarometerInches = jsonData.data.current_condition[0].pressureInches;
                weatherInfo.Today.FeelsLikeC = jsonData.data.current_condition[0].FeelsLikeC;
                weatherInfo.Today.FeelsLikeF = jsonData.data.current_condition[0].FeelsLikeF;
                weatherInfo.Today.UvIndex = jsonData.data.current_condition[0].uvIndex;
                weatherInfo.Today.Icon = jsonData3.weather[0].icon;


                weatherInfo.Forecast.Clear();

                for (var i = 0; i < jsonData.data.weather.Count; i++) {
                    DateTime.TryParse(jsonData.data.weather[i].astronomy[0].sunrise.ToString(), out DateTime sunrise);
                    DateTime.TryParse(jsonData.data.weather[i].astronomy[0].sunset.ToString(), out DateTime sunset);
                    DateTime.TryParse(jsonData.data.weather[i].astronomy[0].moonrise.ToString(), out DateTime moonrise);
                    var today = new DayForecast {
                        Date = jsonData.data.weather[i].date,
                        Sunrise = sunrise,
                        Sunset = sunset,
                        Moonrise = moonrise
                    };
                    try {
                        today.Moonset = jsonData.data.weather[i].astronomy[0].moonset;
                    } catch {
                        // ignored
                    }

                    today.MoonPhase = jsonData.data.weather[i].astronomy[0].moon_phase;
                    today.MaxTempC = jsonData.data.weather[i].maxtempC;
                    today.MaxTempF = jsonData.data.weather[i].maxtempF;
                    today.MinTempC = jsonData.data.weather[i].mintempC;
                    today.MinTempF = jsonData.data.weather[i].mintempF;
                    today.UvIndex = jsonData.data.weather[i].uvIndex;
                    today.Far = weatherInfo.Today.Derge;
                    if (jsonData2 != null)
                        foreach (var item in jsonData2.data) {
                            if (jsonData.data.weather[i].date != item.valid_date) continue;
                            today.Desc = item.weather.description;
                            today.Icon = _iconConvert.ConverterIcon(item.weather.icon.ToString());
                        }

                    for (var j = 0; j < jsonData.data.weather[i].hourly.Count; j++)
                        today.hourForecasts.Add(new HourForecast {
                            Time = _timeConverter.ConvertHour(jsonData.data.weather[i].hourly[j].time.ToString()),
                            TempC = jsonData.data.weather[i].hourly[j].tempC,
                            TempF = jsonData.data.weather[i].hourly[j].tempF,
                            WindSpeedMiles = jsonData.data.weather[i].hourly[j].windspeedMiles,
                            WindSpeedKm = jsonData.data.weather[i].hourly[j].windspeedKmph,
                            WindDirDegree = jsonData.data.weather[i].hourly[j].winddirDegree,
                            WeatherDesc = jsonData.data.weather[i].hourly[j].weatherDesc[0].value,
                            Humidity = jsonData.data.weather[i].hourly[j].humidity,
                            Far = weatherInfo.Today.Derge
                        });

                    weatherInfo.Forecast.Add(today);
                }

                weatherInfo.Forecast.RemoveAt(0);
                return true;
            } catch {
                return false;
            }
        }
    }
}