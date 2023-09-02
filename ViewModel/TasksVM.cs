using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_maui.ViewModel
{
    using Model;
    using System.Windows.Input;

    public class TasksVM : INotifyPropertyChanged
    {
        private readonly Model.TaskList tasks = Settings.Load();
        private bool hasError = false;

        private ICommand addCommand;
        public ICommand Add
        {
            get
            {
                if (addCommand == null) addCommand = new AddCommand(this);

                return addCommand;
            }
        }

        public bool HasError
        {
            get { return hasError; }
            set
            {
                if (hasError == value) return;

                hasError = value;
                onPropertyChanged(nameof(HasError));
            }
        }

        public TasksVM()
        {
            Application.Current.Windows.First().Destroying += (object sender, EventArgs e) => { Settings.Save(tasks); };
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
            if (task == null || task.Title == null || task.Title.Length == 0)
            {
                HasError = true;
                return;
            }
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
    }
}
