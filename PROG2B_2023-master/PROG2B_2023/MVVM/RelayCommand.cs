using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PROG2B_2023.MVVM
{
    //Contains RelayCommands for button usage
    class RelayCommand : ICommand
    {
        //instiales 
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        
        //Method to check if button command can be executed
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        //Method to execute button command
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
