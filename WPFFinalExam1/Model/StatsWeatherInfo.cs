using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFFinalExam1.Model
{
    public class StatsWeatherInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<string> _collectionView = new ObservableCollection<string>();

        private ObservableCollection<KeyValuePair<string, int>> _valueList =
            new ObservableCollection<KeyValuePair<string, int>>();

        private string _query;


        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> CollectionView
        {
            get => _collectionView;
            set
            {
                _collectionView = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<KeyValuePair<string, int>> ValueList
        {
            get => _valueList;
            set
            {
                _valueList = value;
                OnPropertyChanged();
            }
        }
    }
}