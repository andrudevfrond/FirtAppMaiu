namespace FirstApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListStudentPage), typeof(ListStudentPage));
        }
    }
}
