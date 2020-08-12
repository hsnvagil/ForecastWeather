using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model {
    public class DayForecast : INotifyPropertyChanged {
        private DateTime _date;
        private string _desc;

        private bool _far;
        private string _icon;
        private int _maxTempC;
        private int _maxTempF;
        private int _minTempC;
        private int _minTempF;
        private string _moonPhase;
        private DateTime _moonrise;
        private DateTime _moonset;
        private DateTime _sunrise;
        private DateTime _sunset;
        private int _uvIndex;

        public ObservableCollection<HourForecast> hourForecasts { get; set; } =
            new ObservableCollection<HourForecast>();


        public bool Far {
            get => _far;
            set {
                _far = value;
                OnPropertyChanged();
            }
        }

        public string Desc {
            get => _desc;
            set {
                _desc = value;
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

        public DateTime Date {
            get => _date;
            set {
                _date = value;
                OnPropertyChanged();
            }
        }

        public DateTime Sunrise {
            get => _sunrise;
            set {
                _sunrise = value;
                OnPropertyChanged();
            }
        }

        public DateTime Sunset {
            get => _sunset;
            set {
                _sunset = value;
                OnPropertyChanged();
            }
        }

        public DateTime Moonrise {
            get => _moonrise;
            set {
                _moonrise = value;
                OnPropertyChanged();
            }
        }

        public DateTime Moonset {
            get => _moonset;
            set {
                _moonset = value;
                OnPropertyChanged();
            }
        }

        public string MoonPhase {
            get => _moonPhase;
            set {
                _moonPhase = value;
                OnPropertyChanged();
            }
        }

        public int MaxTempC {
            get => _maxTempC;
            set {
                _maxTempC = value;
                OnPropertyChanged();
            }
        }

        public int MaxTempF {
            get => _maxTempF;
            set {
                _maxTempF = value;
                OnPropertyChanged();
            }
        }

        public int MinTempC {
            get => _minTempC;
            set {
                _minTempC = value;
                OnPropertyChanged();
            }
        }

        public int MinTempF {
            get => _minTempF;
            set {
                _minTempF = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}