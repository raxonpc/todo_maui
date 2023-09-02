using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_maui.Types
{
    public class Task
    {
        private string title, description;

        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }

        public Task(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }

        public static Task DummyTask { get; } =
            new Task("Task", "Description");
    }
}
