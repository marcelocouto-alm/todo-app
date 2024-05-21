using System.Globalization;
using ToDoApp.ViewModel;

namespace ToDoApp
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public CultureInfo Culture { get; private set; }
        public App()
        {
            Services = ConfigureServices();
            Culture = CultureInfo.GetCultureInfo("pt-BR");

            InitializeComponent();

            MainPage = new AppShell();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // ViewModels
            services.AddTransient<ToDoTaskViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
