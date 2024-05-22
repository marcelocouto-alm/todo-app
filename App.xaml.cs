using System.Globalization;
using ToDoApp.Service;
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
            Statics.Routing.RegisterRoute(typeof (NewTaskPage));
            Statics.Routing.RegisterRoute(typeof(EditTaskPage));

            //var taskService = new TaskService("todo_app.db");

            MainPage = new AppShell();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // ViewModels
            services.AddTransient<MyTasksViewModel>();
            services.AddTransient<NewTaskViewModel>();

            // SQLite
            services.AddSingleton<LocalDbService>();

            return services.BuildServiceProvider();
        }
    }
}
