using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.Utilities
{
    class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Predicate<Object> _func;

        public RelayCommand(Action<object> action, Predicate<Object> func)
        {
            _action = action;
            _func = func;
        }

        public RelayCommand(Action<object> action)
        {
            _action = action;
            _func = e => true;
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_func == null || _func(parameter))
            {
                _action(parameter);
            }
        }
    }
}
