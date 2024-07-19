
namespace FirstApp.Views;

public partial class ListStudentPage : ContentPage
{
	public ListStudentPage()
	{
		BindingContext = App.Current._services.GetRequiredService<StudentsViewModels>();
		InitializeComponent();
	}
}