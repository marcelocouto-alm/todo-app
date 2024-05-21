using System.Collections.ObjectModel;
using ToDoApp.Entities;
using ToDoApp.Service;

namespace ToDoApp.ViewModel
{
    public partial class MyTasksViewModel : BaseViewModel
    {
        private ObservableCollection<ToDoTask> tasks = new ObservableCollection<ToDoTask>();
        public ObservableCollection<ToDoTask> Tasks
        {
            get { return tasks; }
            set { SetProperty(ref this.tasks, value); }
        }

        public Command GetTasksCommand { get; }

        TaskService taskService;

        public MyTasksViewModel(TaskService taskService)
        {
            this.taskService = taskService;

            //GetTasksCommand = new Command(async () => await GetTasksAsync());
        }

        public async Task GetTasksAsync()
        {
            var task1 = new ToDoTask { Title = "Task 1", Description = "Description 1", Status = 0 };
            var task2 = new ToDoTask { Title = "Task 2", Description = "Description 2", Status = 1 };
            var taskList = new List<ToDoTask> { task1, task2 };

            Tasks = new ObservableCollection<ToDoTask>(taskList);
        }

    }
}
