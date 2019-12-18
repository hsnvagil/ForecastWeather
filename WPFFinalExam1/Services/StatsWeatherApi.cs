using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFFinalExam1.Model;

namespace WPFFinalExam1.Services
{
    class StatsWeatherApi : IStatsWeatherApi
    {
        private string _key;
        private WebClient _client;

        public StatsWeatherApi()
        {
            _key = "498843d6ae8f40a2b84172342192511";
            _client = new WebClient();
        }

        public bool GetStatsData(string city, StatsWeatherInfo statsWeather)
        {
            dynamic jsonData;
            string resultApi;

            try
            {
                resultApi = _client.DownloadString(
                    $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={_key}&q={city}&num_of_days=10&tp=1&format=json");
                jsonData = JsonConvert.DeserializeObject(resultApi);
                statsWeather.Query = jsonData.data.request[0].query;
                statsWeather.CollectionView.Clear();
                statsWeather.ValueList.Clear();

                foreach (var item in jsonData.data.ClimateAverages[0].month)
                {
                    statsWeather.CollectionView.Add(item.name.ToString());
                    int a = Decimal.ToInt32((decimal) item.avgMinTemp);
                    string str = item.name.ToString();
                    str = str.Substring(0, 3);
                    statsWeather.ValueList.Add(new KeyValuePair<string, int>(str, a));
                }

                foreach (var item in jsonData.data.ClimateAverages[0].month)
                {
                    int a = Decimal.ToInt32((decimal) item.absMaxTemp);
                    string str = item.name.ToString();
                    str = str.Substring(0, 3);
                    statsWeather.ValueList.Add(new KeyValuePair<string, int>(str, a));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}