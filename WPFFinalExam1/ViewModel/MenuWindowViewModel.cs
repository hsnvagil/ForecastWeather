using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using WPFFinalExam1.Services;
using WPFFinalExam1.View;

namespace WPFFinalExam1.ViewModel {
    public class MenuWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private UserControl _currentViewModel;
        private UserControl _forecastView;
        private UserControl _historicalWeatherView;
        private bool _popupIsOpen;

        public bool PopupIsOpen {
            get => _popupIsOpen;
            set {
                _popupIsOpen = value;
                OnPropertyChanged();
            }
        }

        private string _feedback;
        private string _explainFeedback;

        public string Feedback {
            get => _feedback;
            set {
                _feedback = value;
                OnPropertyChanged();
            }
        }

        private void SendFeedback() {
            List<string> vs;
            var serializer = new JsonSerializer();

            try {
                using (var sr = new StreamReader("feedback.json")) {
                    using (var jr = new JsonTextReader(sr)) {
                        vs = serializer.Deserialize<List<string>>(jr);
                    }
                }
            } catch {
                vs = new List<string>();
            }

            vs.Add(Feedback);
            vs.Add(ExplainFeedback);

            using (var sw = new StreamWriter("feedback.json")) {
                using (var jw = new JsonTextWriter(sw)) {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, vs);
                }
            }

            Feedback = "";
            ExplainFeedback = "";
        }

        public Command Send {
            get {
                return new Command(obj => {
                    SendFeedback();
                    PopupIsOpen = false;
                    MessageBox.Show("Ok");
                }, obj => !string.IsNullOrEmpty(Feedback));
            }
        }

        public string ExplainFeedback {
            get => _explainFeedback;
            set {
                _explainFeedback = value;
                OnPropertyChanged();
            }
        }

        public UserControl CurrentViewModel {
            get => _currentViewModel;
            set {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public UserControl ForecastView {
            get => _forecastView;
            set {
                _forecastView = value;
                OnPropertyChanged();
            }
        }

        public UserControl HistoricalWeatherView {
            get => _historicalWeatherView;
            set {
                _historicalWeatherView = value;
                OnPropertyChanged();
            }
        }

        public Command OpenForecastViewCommand {
            get { return new Command(obj => { CurrentViewModel = _forecastView; }); }
        }

        public Command OpenHistoricalWeatherViewCommand {
            get { return new Command(obj => { CurrentViewModel = _historicalWeatherView; }); }
        }

        public Command OpenPopupCommand {
            get { return new Command(obj => { PopupIsOpen = true; }); }
        }

        public Command ClosePopupCommand {
            get { return new Command(obj => { PopupIsOpen = false; }); }
        }

        public MenuWindowViewModel() {
            _forecastView = new ForecastView();
            _historicalWeatherView = new HistoricalWeatherView();
            _currentViewModel = _forecastView;
        }
    }
}