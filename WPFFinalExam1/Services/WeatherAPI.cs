using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Windows;
using WPFFinalExam1.Converter;
using WPFFinalExam1.Model;

namespace WPFFinalExam1.Services
{
    class WeatherAPI : IWeatherAPI
    {
        private string _key;
        private string _key2;
        private string _key3;


        private WebClient _client;
        TimeConverter cv = new TimeConverter();
        IconConvert ic = new IconConvert();

        public WeatherAPI()
        {
            _key = "498843d6ae8f40a2b84172342192511";
            _key2 = "55e7c02a42fc4ccc86f7263aaa38397f";
            _key3 = "c668ae28a3e0a0c83980cd0b40442b2d";
            _client = new WebClient();
        }

        public bool GetCityData(string city, WeatherInfo weatherInfo)
        {
            dynamic jsonData;
            string resultApi;
            dynamic jsonData2;
            string resultApi2;
            dynamic jsonData3;
            string resultApi3;

            try
            {
                resultApi3 =
                    _client.DownloadString(
                        $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_key3}");
                jsonData3 = JsonConvert.DeserializeObject(resultApi3);

                resultApi2 =
                    _client.DownloadString($"https://api.weatherbit.io/v2.0/forecast/daily?city={city}&key={_key2}");
                jsonData2 = JsonConvert.DeserializeObject(resultApi2);

                resultApi = _client.DownloadString(
                    $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={_key}&q={city}&num_of_days=10&tp=1&format=json");
                jsonData = JsonConvert.DeserializeObject(resultApi);

                weatherInfo.Today.City = jsonData3.name.ToString();
                weatherInfo.Today.Query = jsonData.data.request[0].query;
                weatherInfo.Today.Time = DateTime.Now;
                weatherInfo.Today.Temp_C = jsonData.data.current_condition[0].temp_C;
                weatherInfo.Today.Temp_F = jsonData.data.current_condition[0].temp_F;
                weatherInfo.Today.Des = jsonData.data.current_condition[0].weatherDesc[0].value;
                weatherInfo.Today.WindspeedMiles = jsonData.data.current_condition[0].windspeedMiles;
                weatherInfo.Today.WindspeedKmph = jsonData.data.current_condition[0].windspeedKmph;
                weatherInfo.Today.WinddirDegree = jsonData.data.current_condition[0].winddirDegree;
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

                for (int i = 0; i < jsonData.data.weather.Count; i++)
                {
                    DayForecast today = new DayForecast();
                    today.Date = jsonData.data.weather[i].date;
                    today.Sunrise = jsonData.data.weather[i].astronomy[0].sunrise;
                    today.Sunset = jsonData.data.weather[i].astronomy[0].sunset;
                    today.Moonrise = jsonData.data.weather[i].astronomy[0].moonrise;
                    try
                    {
                        today.Moonset = jsonData.data.weather[i].astronomy[0].moonset;
                    }
                    catch
                    {
                    }

                    today.Moon_Phase = jsonData.data.weather[i].astronomy[0].moon_phase;
                    today.MaxTempC = jsonData.data.weather[i].maxtempC;
                    today.MaxTempF = jsonData.data.weather[i].maxtempF;
                    today.MinTempC = jsonData.data.weather[i].mintempC;
                    today.MinTempF = jsonData.data.weather[i].mintempF;
                    today.UvIndex = jsonData.data.weather[i].uvIndex;
                    today.Far = weatherInfo.Today.Derge ? true : false;
                    foreach (var item in jsonData2.data)
                    {
                        if (jsonData.data.weather[i].date == item.valid_date)
                        {
                            today.Desc = item.weather.description;
                            today.Icon = ic.ConverterIcon(item.weather.icon.ToString());
                        }
                    }

                    for (int j = 0; j < jsonData.data.weather[i].hourly.Count; j++)
                    {
                        today.hourForecasts.Add(new HourForecast()
                        {
                            Time = cv.ConvertHour(jsonData.data.weather[i].hourly[j].time.ToString()),
                            TempC = jsonData.data.weather[i].hourly[j].tempC,
                            TempF = jsonData.data.weather[i].hourly[j].tempF,
                            WindspeedMiles = jsonData.data.weather[i].hourly[j].windspeedMiles,
                            WindspeedKmph = jsonData.data.weather[i].hourly[j].windspeedKmph,
                            WinddirDegree = jsonData.data.weather[i].hourly[j].winddirDegree,
                            WeatherDesc = jsonData.data.weather[i].hourly[j].weatherDesc[0].value,
                            Humidity = jsonData.data.weather[i].hourly[j].humidity,
                            Far = weatherInfo.Today.Derge ? true : false
                        });
                    }

                    weatherInfo.Forecast.Add(today);
                }

                weatherInfo.Forecast.RemoveAt(0);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}