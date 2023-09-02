using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_maui.ViewModel
{
    using Model;

    public class TasksVM : INotifyPropertyChanged
    {
        private readonly Model.TaskList tasks = Settings.Load();
        private bool isErrorMsgShown = false;

        public bool IsErrorMsgShown
        {
            get { return isErrorMsgShown; }
            private set { isErrorMsgShown = value; }
        }

        public TasksVM()
        {
            Application.Current.Windows.First().Deactivated += (object sender, EventArgs e) => { Settings.Save(tasks); };
        }

        public List<Types.Task> Tasks
        {
            get => tasks.Tasks;
            set
            {
                tasks.Tasks = value;
                onPropertyChanged(nameof(Tasks));
            }
        }

        public void AddTask(Types.Task task)
        {
            tasks.AddTask(task);
            onPropertyChanged(nameof(Tasks));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public string TasksFormatted
        {
            get
            {
                StringBuilder formattedTasks = new StringBuilder();
                foreach (var task in Tasks)
                {
                    formattedTasks.AppendLine($"Title: {task.Title}; Description: {task.Description}");
                    formattedTasks.AppendLine(); // Add a newline to separate tasks
                }
                return formattedTasks.ToString();
            }
        }
    }
}
