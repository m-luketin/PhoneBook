using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoneyFlow.Mobile.Commands
{
    /// <summary>
    /// Testable async command
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AsyncCommand<TData> : ICommand
    {
        private readonly Func<TData, Task> _executeTask;
        public Task _executingTask;
        private bool _isExecuting;

        public AsyncCommand(Func<TData, Task> executeTask)
            => _executeTask = executeTask;

        public event EventHandler CanExecuteChanged;

        public TData TestParameter { private get; set; }

        public bool CanExecute(object parameter)
            => parameter is TData && !_isExecuting;

        public void Execute(object parameter)
        {
            if (!(parameter is TData convertedParameter))
                return;

            _isExecuting = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            _executingTask = _executeTask(convertedParameter);

            _executingTask.ContinueWith(_ =>
            {
                _isExecuting = false;
                Device.BeginInvokeOnMainThread(() => CanExecuteChanged?.Invoke(this, EventArgs.Empty));
            });
        }

        public TaskAwaiter GetAwaiter()
        {
            Execute(TestParameter);
            return _executingTask.GetAwaiter();
        }
    }
}
