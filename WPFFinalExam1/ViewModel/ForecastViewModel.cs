using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFFinalExam1.Model;
using WPFFinalExam1.Services;

namespace WPFFinalExam1.ViewModel
{
    public class ForecastViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private IWeatherAPI _connection;
        private WeatherInfo _weather = new WeatherInfo();
        private DayForecast _daySelectedItem;
        private string _searchCity;
        private bool _derge = false;
        private int _daySelectedIndex = 0;


        public WeatherInfo Weather
        {
            get => _weather;
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }

        public int DaySelectedIndex
        {
            get => _daySelectedIndex;
            set
            {
                _daySelectedIndex = value;
                OnPropertyChanged();
            }
        }

        public DayForecast DaySelectedItem
        {
            get => _daySelectedItem;
            set
            {
                _daySelectedItem = value;
                OnPropertyChanged();
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

        private bool Derge
        {
            get => _derge;
            set
            {
                _derge = value;
                OnPropertyChanged();
            }
        }

        public ForecastViewModel()
        {
            _connection = new WeatherAPI();
            if (_connection.GetCityData("Baku", _weather))
            {
                DaySelectedItem = Weather.Forecast[0];
            }
        }

        public Command Search
        {
            get
            {
                return new Command((obj) =>
                {
                    if (_connection.GetCityData(SearchCity, _weather))
                    {
                        DaySelectedItem = _weather.Forecast[0];
                    }
                }, (obj => !string.IsNullOrEmpty(SearchCity)));
            }
        }

        public Command Refresh
        {
            get
            {
                return new Command((obj =>
                {
                    _connection.GetCityData(Weather.Today.City, _weather);
                    DaySelectedItem = _weather.Forecast[0];
                }));
            }
        }

        public Command DergeChange
        {
            get { return new Command(obj => { ChangeFar(); }, (obj) => Derge == true); }
        }

        public Command FarChange
        {
            get { return new Command(obj => { ChangeFar(); }, (obj) => Derge == false); }
        }

        private void ChangeFar()
        {
            Derge = !Derge;
            Weather.Today.Derge = !Weather.Today.Derge;
            foreach (DayForecast d in Weather.Forecast)
            {
                d.Far = !d.Far;
                foreach (HourForecast h in d.hourForecasts)
                {
                    h.Far = !h.Far;
                }
            }
        }
    }
}