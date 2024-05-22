using ToDoApp.Managers;
using ToDoApp.ViewModels;

namespace ToDoApp.View;

public partial class MyTasksPage : ContentPage
{
	readonly MyTasksViewModel ViewModel;

	TaskManager taskManager;

	public MyTasksPage()
	{
		InitializeComponent();
		ViewModel = App.Current.Services.GetService<MyTasksViewModel>();
		BindingContext = ViewModel;

		taskManager = App.Current.Services.GetService<TaskManager>();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ViewModel.GetTasksAsync();
	}

    private async void NewTask_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewTaskPage));
    }

    private async void EditTask_Clicked(object sender, EventArgs e)
    {
        var idTask = (int)((TappedEventArgs)e).Parameter;

        taskManager.IdTask = idTask;

        await Shell.Current.GoToAsync(nameof(EditTaskPage));
    }
}