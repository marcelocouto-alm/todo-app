namespace ToDoApp.View;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void MyTasks_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MyTasksPage));
    }
}