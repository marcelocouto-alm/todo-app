using System.Collections.ObjectModel;
using ToDoApp.Entities;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
{
    public partial class MyTasksViewModel : BaseViewModel
    {
        private ObservableCollection<ToDoTask> tasks = new ObservableCollection<ToDoTask>();
        public ObservableCollection<ToDoTask>? Tasks
        {
            get { return tasks; }
            set { SetProperty(ref this.tasks, value); }
        }

        public Command GetTasksCommand { get; }

        private readonly LocalDbService _localDbService;

        public MyTasksViewModel(LocalDbService localDbService)
        {
            _localDbService = localDbService;
        }

        public async Task GetTasksAsync()
        {
            var taskList = await _localDbService.GetActiveTasksAsync();

            if (taskList is not null)
                Tasks = new ObservableCollection<ToDoTask>(taskList);
            else
                Tasks = null;
        }
    }
}
