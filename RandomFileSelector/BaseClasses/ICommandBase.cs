using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandomFileSelector
{
    public class ICommandBase : ICommand
    {
        #region Private Variables
        private bool _canExecute;
        private Action _action;
        #endregion

        #region Public Variables
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        #endregion

        #region Default Variables
        public ICommandBase(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public ICommandBase(Action action)
        {
            _action = action;
            _canExecute = true;
        }
        #endregion

        #region Event Handlers
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
        #endregion
    }
}
