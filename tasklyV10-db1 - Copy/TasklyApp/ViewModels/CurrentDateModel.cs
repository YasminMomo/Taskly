using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Timers;
using System.Windows.Threading;

namespace TasklyApp.ViewModels
{
    public class CurrentDateModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _currentDate;
        public string CurrentDate
        {
            get => _currentDate;
            set
            {
                if (_currentDate != value)
                {
                    _currentDate = value;
                    OnPropertyChanged(nameof(CurrentDate));
                }
            }
        }

        public CurrentDateModel()
        {
            UpdateCurrentDate();
        }

        public void UpdateCurrentDate()
        {
            CurrentDate = DateTime.Now.ToString("dddd, MMMM dd");
        }
    }
}