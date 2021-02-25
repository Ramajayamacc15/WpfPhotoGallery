using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _delegateAction;
        private Predicate<object> _predicateCanExecute;
        public DelegateCommand(Action<object> delegateAction)
        {
            _delegateAction = delegateAction;
        }
        public DelegateCommand(Action<object> delegateAction, Predicate<object> predicateCanExecute)
        {
            _delegateAction = delegateAction;
            _predicateCanExecute = predicateCanExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _predicateCanExecute == null ? true : _predicateCanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _delegateAction(parameter);
        }
    }
}
