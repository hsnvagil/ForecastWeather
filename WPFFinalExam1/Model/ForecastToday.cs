using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model
{
    public class ForecastToday : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string _city;
        private bool _derge;
        private string _query;
        private int _temp_C;
        private int _temp_F;
        private string _des;
        private DateTime _time;
        private int _visibilityMiles;
        private int _visibility;
        private int _windspeedMiles;
        private int _windspeedKmph;
        private int _barometer;
        private int _barometerInches;
        private int _humidity;
        private int _feelsLikeC;
        private int _feelsLikeF;
        private int _uvIndex;
        private int _winddirDegree;
        private string _icon;


        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged();
            }
        }

        public bool Derge
        {
            get => _derge;
            set
            {
                _derge = value;
                OnPropertyChanged();
            }
        }

        public int Temp_C
        {
            get => _temp_C;
            set
            {
                _temp_C = value;
                OnPropertyChanged();
            }
        }

        public int Temp_F
        {
            get => _temp_F;
            set
            {
                _temp_F = value;
                OnPropertyChanged();
            }
        }

        public string Des
        {
            get => _des;
            set
            {
                _des = value;
                OnPropertyChanged();
            }
        }

        public int VisibilityMiles
        {
            get => _visibilityMiles;
            set
            {
                _visibilityMiles = value;
                OnPropertyChanged();
            }
        }

        public int Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public int WindspeedMiles
        {
            get => _windspeedMiles;
            set
            {
                _windspeedMiles = value;
                OnPropertyChanged();
            }
        }

        public int WindspeedKmph
        {
            get => _windspeedKmph;
            set
            {
                _windspeedKmph = value;
                OnPropertyChanged();
            }
        }

        public int Barometer
        {
            get => _barometer;
            set
            {
                _barometer = value;
                OnPropertyChanged();
            }
        }

        public int BarometerInches
        {
            get => _barometerInches;
            set
            {
                _barometerInches = value;
                OnPropertyChanged();
            }
        }

        public int Humidity
        {
            get => _humidity;
            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        public int FeelsLikeC
        {
            get => _feelsLikeC;
            set
            {
                _feelsLikeC = value;
                OnPropertyChanged();
            }
        }

        public int FeelsLikeF
        {
            get => _feelsLikeF;
            set
            {
                _feelsLikeF = value;
                OnPropertyChanged();
            }
        }

        public int UvIndex
        {
            get => _uvIndex;
            set
            {
                _uvIndex = value;
                OnPropertyChanged();
            }
        }

        public int WinddirDegree
        {
            get => _winddirDegree;
            set
            {
                _winddirDegree = value;
                OnPropertyChanged();
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
    }
}