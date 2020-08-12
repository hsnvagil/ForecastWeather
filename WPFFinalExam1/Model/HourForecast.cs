using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model {
    public class HourForecast : INotifyPropertyChanged {
        private bool _far;
        private int _humidity;
        private int _tempC;
        private int _tempF;
        private string _time;
        private string _weatherDesc;
        private int _windDirDegree;
        private int _windSpeedKm;
        private int _windSpeedMiles;

        public bool Far {
            get => _far;
            set {
                _far = value;
                OnPropertyChanged();
            }
        }

        public string Time {
            get => _time;
            set {
                _time = value;
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

        public int WindDirDegree {
            get => _windDirDegree;
            set {
                _windDirDegree = value;
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

        public string WeatherDesc {
            get => _weatherDesc;
            set {
                _weatherDesc = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}