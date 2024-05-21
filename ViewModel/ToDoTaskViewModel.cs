using System.Collections.ObjectModel;
using ToDoApp.Entities;
using ToDoApp.Service;

namespace ToDoApp.ViewModel
{
    public partial class ToDoTaskViewModel : BaseViewModel
    {
        TaskService taskService;
        
        public ObservableCollection<ToDoTask> Tasks { get; } = new();

        public ToDoTaskViewModel(TaskService taskService)
        {
            this.taskService = taskService;
        }

        async Task GetTasksAsync()
        {

        }
    }
}
