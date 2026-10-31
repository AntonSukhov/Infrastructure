using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Infrastructure.Foundation.Bindings
{
    /// <summary>
    /// Базовая реализация уведомления клиентов об изменении значения их свойств.
    /// </summary>
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие <see cref="PropertyChanged"/> для уведомления об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Установка значения и уведомление об изменении.
        /// </summary>
        /// <typeparam name="T">Тип данных поля.</typeparam>
        /// <param name="field">Поле.</param>
        /// <param name="value">Устанавливаемое значение поля.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Признак установки значения свойства.</returns>
        protected virtual bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Вызов события <see cref="PropertyChanged"/> для указанного свойства.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

