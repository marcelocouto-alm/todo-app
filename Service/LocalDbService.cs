using SQLite;
using ToDoApp.Entities;

namespace ToDoApp.Service
{
    public class LocalDbService
    {
        private const string DB_NAME = "tasks_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<ToDoTask>();
        }

        public async Task<List<ToDoTask>> GetTasksAsync()
        {
            return await _connection.Table<ToDoTask>().ToListAsync();
        }

        public async Task<ToDoTask> GetTaskById(int id)
        {
            return await _connection.Table<ToDoTask>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateTask(ToDoTask task)
        {
            await _connection.InsertAsync(task);
        }

        public async Task UpdateTask(ToDoTask toDoTask)
        {
            await _connection.UpdateAsync(toDoTask);
        }

        public async Task DeleteTask(ToDoTask toDoTask)
        {
            await _connection.DeleteAsync(toDoTask);
        }
    }
}
