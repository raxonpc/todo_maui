namespace todo_maui.Model
{
    internal class TaskList
    {
        public List<Types.Task> Tasks { get; set; }

        public TaskList()
        {
            this.Tasks = new List<Types.Task>();
        }

        public void AddTask(Types.Task task)
        {
            Tasks.Add(task);
        }
    }
}
