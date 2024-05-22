using ToDoApp.ViewModels;

namespace ToDoApp.View;

public partial class NewTaskPage : ContentPage
{
    readonly NewTaskViewModel ViewModel;

    public NewTaskPage()
    {
        InitializeComponent();
        ViewModel = App.Current.Services.GetService<NewTaskViewModel>();
        BindingContext = ViewModel;
    }

    private async void NewTask_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewTaskPage));
    }
}