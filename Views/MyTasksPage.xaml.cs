using ToDoApp.ViewModels;

namespace ToDoApp.View;

public partial class MyTasksPage : ContentPage
{
	readonly MyTasksViewModel ViewModel;

	public MyTasksPage()
	{
		InitializeComponent();
		ViewModel = App.Current.Services.GetService<MyTasksViewModel>();
		BindingContext = ViewModel;
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
}