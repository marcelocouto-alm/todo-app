using System.Collections.ObjectModel;
using ToDoApp.Entities;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
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

        public MyTasksViewModel()
        {
            //GetTasksCommand = new Command(async () => await GetTasksAsync());
        }

        public async Task GetTasksAsync()
        {
            var task1 = new ToDoTask { Title = "Task 1", Description = "Description1 Description 1Description 1Description1 Description 1Description 1Description 1Description 1", Status = 0 };
            var task2 = new ToDoTask { Title = "Task 2", Description = "Description 2", Status = 1 };
            var task4 = new ToDoTask { Title = "Task 4", Description = "Description 4", Status = 1 };
            var task5 = new ToDoTask { Title = "Task 5", Description = "Description 5", Status = 1 };
            var taskList = new List<ToDoTask> { task1, task2, task4, task5 };

            Tasks = new ObservableCollection<ToDoTask>(taskList);
        }

    }
}
