
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TasklyApp.Models;

namespace AddTaskModal.ViewModels
{
    public class AddTaskModel : INotifyPropertyChanged
    {
        public ObservableCollection<DropdownOption> CourseOptions { get; set; }
        public ObservableCollection<DropdownOption> CategoryOptions { get; set; }
        public ObservableCollection<DropdownOption> ProgressOptions { get; set; }

        private DropdownOption selectedOption;
        public DropdownOption SelectedOption
        {
            get => selectedOption;
            set
            {
                selectedOption = value;
                OnPropertyChanged();
            }
        }

        public AddTaskModel()
        {
            // Initialize dropdowns
            CourseOptions = new ObservableCollection<DropdownOption>
            {
                new DropdownOption { Value = "Course A", ButtonColor = "#37CA26" },
                new DropdownOption { Value = "Course B", ButtonColor = "#FE761C" }
            };

            CategoryOptions = new ObservableCollection<DropdownOption>
            {
                new DropdownOption { Value = "Category X", ButtonColor = "#FE321C" },
                new DropdownOption { Value = "Category Y", ButtonColor = "#37CA26" },
                new DropdownOption { Value = "Category Z", ButtonColor = "#37CA26" }
            };

            ProgressOptions = new ObservableCollection<DropdownOption>
            {
                new DropdownOption { Value = "Not Started", ButtonColor = "#37CA26" },
                new DropdownOption { Value = "In Progress", ButtonColor = "#FE761C" },
                new DropdownOption { Value = "Completed", ButtonColor = "#FE321C" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
