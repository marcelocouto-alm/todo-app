using System.Globalization;
using ToDoApp.View;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        public CultureInfo Culture { get; private set; }
        public App()
        {
            Services = ConfigureServices();
            Culture = CultureInfo.GetCultureInfo("pt-BR");

            InitializeComponent();

            Statics.Routing.RegisterRoute(typeof(MyTasksPage));
            Statics.Routing.RegisterRoute(typeof (EditTaskPage));

            MainPage = new AppShell();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // ViewModels
            services.AddTransient<MyTasksViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
