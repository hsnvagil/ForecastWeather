using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WPFFinalExam1.Model;
using WPFFinalExam1.Services;

namespace WPFFinalExam1.ViewModel
{
    public class HistoricalWeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public IStatsWeatherApi _connection;
        private string _searchCity;
        private StatsWeatherInfo statsWeather = new StatsWeatherInfo();


        public StatsWeatherInfo StatsWeather
        {
            get => statsWeather;
            set
            {
                statsWeather = value;
                OnPropertyChanged();
            }
        }

        public HistoricalWeatherViewModel()
        {
            _connection = new StatsWeatherApi();
            _connection.GetStatsData("Baku", statsWeather);
        }

        public Command Search
        {
            get
            {
                return new Command((obj) => { _connection.GetStatsData(SearchCity, statsWeather); },
                    (obj => !string.IsNullOrEmpty(SearchCity)));
            }
        }

        public string SearchCity
        {
            get => _searchCity;
            set
            {
                _searchCity = value;
                OnPropertyChanged();
            }
        }
    }
}