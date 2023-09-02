using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace todo_maui.Model
{
    internal class Settings
    {
        private static string SettingsDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "todo_maui");

        private static string SettingsFilePath = Path.Combine(
            SettingsDirectory,
            "tasks.xml");

        public static void Save(TaskList tasks)
        {
            if (!Directory.Exists(SettingsDirectory))
            {
                Directory.CreateDirectory(SettingsDirectory);
            }

            XDocument xml = new XDocument(
                new XElement("tasks"));

            foreach (var task in tasks.Tasks)
            {
                xml.Element("tasks").Add(
                    new XElement("task",
                        new XElement("title", task.Title),
                        new XElement("description", task.Description)));
            }

            xml.Save(SettingsFilePath);
        }

        public static TaskList Load()
        {
            var output = new TaskList();
            if (!File.Exists(SettingsFilePath)) return output;

            XDocument xml = XDocument.Load(SettingsFilePath);
            foreach (var task in xml.Element("tasks").Elements())
            {
                output.AddTask(
                    new Types.Task(task.Element("title").Value, task.Element("description").Value)
                );
            }

            return output;
        }
    }
}
