using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using WPFFinalExam1.Model;

namespace WPFFinalExam1.Services {
    internal class StatsWeatherApi : IStatsWeatherApi {
        private readonly string _key;
        private readonly WebClient _client;

        public StatsWeatherApi() {
            _key = "de6091252082423590a104919201208";
            _client = new WebClient();
        }

        public bool GetStatsData(string city, StatsWeatherInfo statsWeather) {
            try {
                var resultApi = _client.DownloadString(
                    $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={_key}&q={city}&num_of_days=10&tp=1&format=json");
                dynamic jsonData = JsonConvert.DeserializeObject(resultApi);
                if (jsonData != null) {
                    statsWeather.Query = jsonData.data.request[0].query;
                    statsWeather.CollectionView.Clear();
                    statsWeather.ValueList.Clear();

                    foreach (var item in jsonData.data.ClimateAverages[0].month) {
                        statsWeather.CollectionView.Add(item.name.ToString());
                        var a = decimal.ToInt32((decimal) item.avgMinTemp);
                        string str = item.name.ToString();
                        str = str.Substring(0, 3);
                        statsWeather.ValueList.Add(new KeyValuePair<string, int>(str, a));
                    }

                    foreach (var item in jsonData.data.ClimateAverages[0].month) {
                        var a = decimal.ToInt32((decimal) item.absMaxTemp);
                        string str = item.name.ToString();
                        str = str.Substring(0, 3);
                        statsWeather.ValueList.Add(new KeyValuePair<string, int>(str, a));
                    }
                }

                return true;
            } catch {
                return false;
            }
        }
    }
}