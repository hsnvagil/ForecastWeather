using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model {
    public class ForecastToday : INotifyPropertyChanged {
        private int _barometer;
        private int _barometerInches;

        private string _city;
        private bool _derge;
        private string _des;
        private int _feelsLikeC;
        private int _feelsLikeF;
        private int _humidity;
        private string _icon;
        private string _query;
        private int _tempC;
        private int _tempF;
        private DateTime _time;
        private int _uvIndex;
        private int _visibility;
        private int _visibilityMiles;
        private int _windDirDegree;
        private int _windSpeedKm;
        private int _windSpeedMiles;


        public string City {
            get => _city;
            set {
                _city = value;
                OnPropertyChanged();
            }
        }

        public string Icon {
            get => _icon;
            set {
                _icon = value;
                OnPropertyChanged();
            }
        }

        public string Query {
            get => _query;
            set {
                _query = value;
                OnPropertyChanged();
            }
        }

        public bool Derge {
            get => _derge;
            set {
                _derge = value;
                OnPropertyChanged();
            }
        }

        public int TempC {
            get => _tempC;
            set {
                _tempC = value;
                OnPropertyChanged();
            }
        }

        public int TempF {
            get => _tempF;
            set {
                _tempF = value;
                OnPropertyChanged();
            }
        }

        public string Des {
            get => _des;
            set {
                _des = value;
                OnPropertyChanged();
            }
        }

        public int VisibilityMiles {
            get => _visibilityMiles;
            set {
                _visibilityMiles = value;
                OnPropertyChanged();
            }
        }

        public int Visibility {
            get => _visibility;
            set {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public int WindSpeedMiles {
            get => _windSpeedMiles;
            set {
                _windSpeedMiles = value;
                OnPropertyChanged();
            }
        }

        public int WindSpeedKm {
            get => _windSpeedKm;
            set {
                _windSpeedKm = value;
                OnPropertyChanged();
            }
        }

        public int Barometer {
            get => _barometer;
            set {
                _barometer = value;
                OnPropertyChanged();
            }
        }

        public int BarometerInches {
            get => _barometerInches;
            set {
                _barometerInches = value;
                OnPropertyChanged();
            }
        }

        public int Humidity {
            get => _humidity;
            set {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        public int FeelsLikeC {
            get => _feelsLikeC;
            set {
                _feelsLikeC = value;
                OnPropertyChanged();
            }
        }

        public int FeelsLikeF {
            get => _feelsLikeF;
            set {
                _feelsLikeF = value;
                OnPropertyChanged();
            }
        }

        public int UvIndex {
            get => _uvIndex;
            set {
                _uvIndex = value;
                OnPropertyChanged();
            }
        }

        public int WindDirDegree {
            get => _windDirDegree;
            set {
                _windDirDegree = value;
                OnPropertyChanged();
            }
        }

        public DateTime Time {
            get => _time;
            set {
                _time = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}