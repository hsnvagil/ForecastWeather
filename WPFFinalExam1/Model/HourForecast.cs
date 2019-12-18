using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model
{
    public class HourForecast : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool _far = false;
        private string _time;
        private int _tempC;
        private int _tempF;
        private int _windspeedMiles;
        private int _windspeedKmph;
        private int _winddirDegree;
        private int _humidity;
        private string _weatherDesc;

        public bool Far
        {
            get => _far;
            set
            {
                _far = value;
                OnPropertyChanged();
            }
        }

        public string Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public int TempC
        {
            get => _tempC;
            set
            {
                _tempC = value;
                OnPropertyChanged();
            }
        }

        public int TempF
        {
            get => _tempF;
            set
            {
                _tempF = value;
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

        public int WinddirDegree
        {
            get => _winddirDegree;
            set
            {
                _winddirDegree = value;
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

        public string WeatherDesc
        {
            get => _weatherDesc;
            set
            {
                _weatherDesc = value;
                OnPropertyChanged();
            }
        }
    }
}