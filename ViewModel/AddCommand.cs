using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace todo_maui.ViewModel
{
    internal class AddCommand : ICommand
    {
        private readonly TasksVM viewModel;

        public AddCommand(TasksVM viewModel)
        {
            this.viewModel = viewModel;

            this.viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, e);
            }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            if (viewModel == null)
            {
                return;
            }
            viewModel.AddTask((Types.Task)parameter);
        }
    }
}
