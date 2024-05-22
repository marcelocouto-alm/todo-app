using ToDoApp.ViewModels;

namespace ToDoApp.View;

public partial class EditTaskPage : ContentPage
{
	readonly EditTaskViewModel ViewModel;

	public EditTaskPage()
	{
		InitializeComponent();

		ViewModel = App.Current.Services.GetService<EditTaskViewModel>();
		BindingContext = ViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.GetTasksAsync();
    }

    private void DeleteTask(object sender, EventArgs e)
    {
        ShowDeleteConfirmation();
    }

    private async void ShowDeleteConfirmation()
    {
        bool result = await DisplayAlert("Confirmação", "Tem certeza que deseja excluir esta tarefa?", "Sim", "Cancelar");

        if (result)
        {
            ViewModel.DeleteTask();
        }
    }

}