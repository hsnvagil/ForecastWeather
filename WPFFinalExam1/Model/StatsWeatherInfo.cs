using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFinalExam1.Model {
    public class StatsWeatherInfo : INotifyPropertyChanged {
        private ObservableCollection<string> _collectionView = new ObservableCollection<string>();

        private string _query;

        private ObservableCollection<KeyValuePair<string, int>> _valueList =
            new ObservableCollection<KeyValuePair<string, int>>();


        public string Query {
            get => _query;
            set {
                _query = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> CollectionView {
            get => _collectionView;
            set {
                _collectionView = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<KeyValuePair<string, int>> ValueList {
            get => _valueList;
            set {
                _valueList = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}