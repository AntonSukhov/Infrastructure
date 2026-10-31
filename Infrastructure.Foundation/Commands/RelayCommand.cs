using System;
using System.Windows.Input;

namespace Infrastructure.Foundation.Commands
{
    /// <summary>
    /// Базовая реализация <see cref="ICommand"/> без строгой типизации.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Инициализация экземпляра <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">Действие, выполняемое при вызове команды.</param>
        /// <param name="canExecute">Функция проверки возможности выполнения команды.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="execute"/> равен null.</exception>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc/>
        public void Execute(object parameter) => _execute(parameter);

        /// <inheritdoc/>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// Принудительно уведомление подписанта о изменении состояния команды.
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
