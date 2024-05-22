using System.Windows.Input;
using ToDoApp.Entities;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
{
    public class NewTaskViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { SetProperty(ref _isCompleted, value); }
        }

        private readonly LocalDbService _localDbService;

        public ICommand SaveCommand { get; }

        public NewTaskViewModel(LocalDbService localDbService)
        {
            _localDbService = localDbService;

            SaveCommand = new Command(SaveTask);
        }

        private async void SaveTask()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description))
                return;

            var newTask = new ToDoTask { Title = Title, Description = Description, Status = IsCompleted ? 1 : 0 };

            await _localDbService.CreateTask(newTask);

            await Shell.Current.GoToAsync("..");
        }
    }
}
