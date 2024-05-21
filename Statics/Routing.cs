namespace ToDoApp.Statics
{
    public static class Routing
    {
        public static void RegisterRoute(Type type)
        {
            Microsoft.Maui.Controls.Routing.RegisterRoute(type.Name, type);
        }
    }
}