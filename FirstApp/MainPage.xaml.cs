using FirstApp.ViewModels;

namespace FirstApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = App.Current._services.GetRequiredService<TestViewModel>();
            InitializeComponent();
        }
    }

}
