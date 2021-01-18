using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FourFunctionCalc
{
    public class DelegateCommand : ICommand // Allows us to use ICommand (Interface Command) for our buttons, basically a Command Handler
    {
        #region Fields
        private readonly Action<object> _action; // Declares our action to accept a parameter
        private readonly bool _ranAsTask; // Checks to make sure the task is getting run
        #endregion

        #region Constructors
        public DelegateCommand(Action<object> action) // Our constructor where it should always run

            : this(action, true)
        { }

        public DelegateCommand(Action<object> action, bool runAsTask) // Full constructor for DelegateCommand
        {
            _action = action;
            _ranAsTask = runAsTask;
        }
        #endregion

        #region Execution
        public virtual void Execute(object parameter) // Our button executes it's assigned command, with its command parameter
        {
            _action(parameter); 
        }

        public bool CanExecute(object parameter) // Our button should always work
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        #endregion

    }
}