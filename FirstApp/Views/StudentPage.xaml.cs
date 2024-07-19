namespace FirstApp.Views;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		BindingContext = App.Current._services.GetRequiredService<StudentViewModels>();
		InitializeComponent();
	}
}