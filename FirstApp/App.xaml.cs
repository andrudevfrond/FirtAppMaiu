using FirstApp.ViewModels;

namespace FirstApp
{
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider _services { get; }
        public App()
        {
            var services = new ServiceCollection();
            _services = ConfigureServices(services);
            InitializeComponent();

            MainPage = new AppShell();
        }
        private static IServiceProvider ConfigureServices(ServiceCollection services) {
            // Services
            services.AddSingleton<IFunctions, Functions>();

            // ViewModels
            services.AddTransient<TestViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
