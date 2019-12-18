using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model
{
    public class DayForecast : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<HourForecast> hourForecasts { get; set; } =
            new ObservableCollection<HourForecast>();

        private bool _far = false;
        private DateTime _date;
        private DateTime _sunrise;
        private DateTime _sunset;
        private DateTime _moonrise;
        private DateTime _moonset;
        private string _moon_phase;
        private int _maxtempC;
        private int _maxtempF;
        private int _mintempC;
        private int _mintempF;
        private int _uvIndex;
        private string _desc;
        private string _icon;


        public bool Far
        {
            get => _far;
            set
            {
                _far = value;
                OnPropertyChanged();
            }
        }

        public string Desc
        {
            get => _desc;
            set
            {
                _desc = value;
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

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public DateTime Sunrise
        {
            get => _sunrise;
            set
            {
                _sunrise = value;
                OnPropertyChanged();
            }
        }

        public DateTime Sunset
        {
            get => _sunset;
            set
            {
                _sunset = value;
                OnPropertyChanged();
            }
        }

        public DateTime Moonrise
        {
            get => _moonrise;
            set
            {
                _moonrise = value;
                OnPropertyChanged();
            }
        }

        public DateTime Moonset
        {
            get => _moonset;
            set
            {
                _moonset = value;
                OnPropertyChanged();
            }
        }

        public string Moon_Phase
        {
            get => _moon_phase;
            set
            {
                _moon_phase = value;
                OnPropertyChanged();
            }
        }

        public int MaxTempC
        {
            get => _maxtempC;
            set
            {
                _maxtempC = value;
                OnPropertyChanged();
            }
        }

        public int MaxTempF
        {
            get => _maxtempF;
            set
            {
                _maxtempF = value;
                OnPropertyChanged();
            }
        }

        public int MinTempC
        {
            get => _mintempC;
            set
            {
                _mintempC = value;
                OnPropertyChanged();
            }
        }

        public int MinTempF
        {
            get => _mintempF;
            set
            {
                _mintempF = value;
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
    }
}