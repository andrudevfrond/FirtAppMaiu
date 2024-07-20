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
            

            // ViewModels
            services.AddTransient<TestViewModel>();
            services.AddTransient<StudentsViewModels>();
            services.AddTransient<StudentViewModels>();

            //Views
            services.AddSingleton<ListStudentPage>();
//            services.AddSingleton<ItemStudentPage>();
            services.AddSingleton<StudentPage>();

            // Services
            services.AddTransient<IFunctions, Functions>();
            services.AddTransient<IStudents, StudentsService>();
            services.AddTransient<IDialogService, DialogService>();
            services.AddTransient<IPath, DbPath>();

            return services.BuildServiceProvider();
        }
    }
}
