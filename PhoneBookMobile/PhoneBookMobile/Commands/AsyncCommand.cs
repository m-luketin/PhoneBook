using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyFlow.Mobile.Commands
{
    /// <summary>
    /// Testable async command
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AsyncCommand : ICommand
    {
        private readonly Func<Task> _executeTask;
        private Task _executingTask;
        private bool _isExecuting;

        public AsyncCommand(Func<Task> executeTask)
            => _executeTask = executeTask;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
            => !_isExecuting;

        public void Execute(object parameter)
        {
            _isExecuting = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            _executingTask = _executeTask();

            _executingTask.ContinueWith(_ =>
            {
                _isExecuting = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public TaskAwaiter GetAwaiter()
        {
            Execute(null);
            return _executingTask.GetAwaiter();
        }
    }
}
