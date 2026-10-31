using System;
using System.Windows.Input;

namespace Infrastructure.Foundation.Commands
{
    /// <summary>
    /// Типобезопасная реализация <see cref="ICommand"/>.
    /// </summary>
    /// <typeparam name="T">Тип данных аргументов команды.</typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Инициализация экземпляра <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">Действие, выполняемое при вызове команды.</param>
        /// <param name="canExecute">Функция проверки возможности выполнения команды.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="execute"/> равен null.</exception>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            if (parameter is T t)
            {
                _execute(t);
            }
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            if (parameter is T t)
                return _canExecute(t);

            return false;
        }

        /// <summary>
        /// Принудительно уведомление подписанта о изменении состояния команды.
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
