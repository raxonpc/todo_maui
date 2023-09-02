using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_maui
{
    internal class TaskListToString : IValueConverter
    {
        public static string ToString(List<Types.Task> tasks)
        {
            StringBuilder formattedTasks = new StringBuilder();
            foreach (var task in tasks)
            {
                formattedTasks.AppendLine($"Title: {task.Title}; Description: {task.Description}");
            }
            return formattedTasks.ToString();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Types.Task> listvalue = (List<Types.Task>)value;
            return ToString(listvalue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class StringsToTask : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null || values.Length != 2)
            {
                return null;
            }

            string title = values[0].ToString();
            string description = values[1].ToString();

            return new Types.Task(title, description);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
