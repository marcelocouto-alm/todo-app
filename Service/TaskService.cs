using System.Net.Http.Json;
using ToDoApp.Entities;

namespace ToDoApp.Service
{
    public class TaskService
    {
        HttpClient httpClient;
        List<ToDoTask> tasks;
        const string REQUEST_URL = "";

        public TaskService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<ToDoTask>> GetTasksAsync()
        {
            if (tasks?.Count > 0) 
            {
                return tasks;
            }

            var response = await httpClient.GetAsync(REQUEST_URL);

            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<ToDoTask>>();
            }

            return tasks;
        }
    }
}
