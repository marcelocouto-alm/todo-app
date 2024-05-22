using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoApp.Entities;
using ToDoApp.Managers;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
{
    public partial class EditTaskViewModel : BaseViewModel
    {
        private int _idTask;
        public int IdTask
        {
            get { return _idTask; }
            set { SetProperty(ref _idTask, value); }
        }

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

        public Command GetDataCommand { get; }

        private readonly LocalDbService _localDbService;
        private readonly TaskManager _taskManager;

        public ICommand EditTaskCommand { get; }

        public EditTaskViewModel(LocalDbService localDbService, TaskManager taskManager)
        {
            _localDbService = localDbService;
            _taskManager = taskManager;

            EditTaskCommand = new Command(EditTask);
        }

        public async Task GetTasksAsync()
        {
            IdTask = _taskManager.IdTask;

            var taskData = await _localDbService.GetTaskById(IdTask);

            Title = taskData.Title;
            Description = taskData.Description;
            IsCompleted = taskData.Status == 1;
        }

        private async void EditTask()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description))
                return;

            var newTask = new ToDoTask {Id = IdTask, Title = Title, Description = Description, Status = IsCompleted ? 1 : 0 };

            await _localDbService.UpdateTask(newTask);

            await Shell.Current.GoToAsync("..");
        }
    }
}
