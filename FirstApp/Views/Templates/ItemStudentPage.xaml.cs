namespace FirstApp.Views.Templates;

partial class ItemStudentPage : ContentView
{
	private readonly StudentsViewModels viewModels;
	public ItemStudentPage()
	{
		try
		{
			viewModels = App.Current._services.GetRequiredService<StudentsViewModels>();
			InitializeComponent();

		}
		catch (Exception ex)
		{
			throw new ArgumentException(ex.Message);
		}
	}
}