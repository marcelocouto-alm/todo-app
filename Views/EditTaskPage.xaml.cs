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
}