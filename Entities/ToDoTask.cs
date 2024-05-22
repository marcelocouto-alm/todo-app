using SQLite;

namespace ToDoApp.Entities
{
    [Table("tasks")]
    public class ToDoTask
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("task_title")]
        public string Title { get; set; }

        [Column("task_Description")]
        public string Description { get; set; }

        [Column("task_status")]
        public int Status { get; set; }
    }
}